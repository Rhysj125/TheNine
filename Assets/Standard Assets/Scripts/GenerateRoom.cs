using Assets.Standard_Assets.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Game.Settings;

public class GenerateRoom : MonoBehaviour
{

    public int floorSize = 9;
    public float probabilityModifier = 0.8f;
    private List<GameObject> floorTiles;
    public GameObject walls;
    public System.Random rand = new System.Random();
    public const int ROOM_SIZE = 10;

    public NavMeshSurface surface;

    public void Start()
    {
        floorTiles = ResourceLoader.GetRoomTiles(1);

        SpawnPlayer();
        CreateRoom();

        if (Settings.SpawnEnemies)
        {
            SpawnEnemies();
        }

        Level.IsGameRunning = true;
        Time.timeScale = 1f;
    }

    private void Update()
    {
        if (Settings.SeeMapGeneration)
        {
            if (Input.anyKey)
            {
                RebuildRoom();
            }
        }
    }

    // Use this for initialization
    public void CreateRoom()
    {
        var mapGrid = mapRoom();
        BuildMap(mapGrid);
        surface.BuildNavMesh();
    }

    private int[,] mapRoom()
    {
        int[,] grid = new int[floorSize, floorSize]; ;

        //Three queues of positions
        Queue<int[]> checkedPositions = new Queue<int[]>();
        Queue<int[]> positionsToCheck = new Queue<int[]>();
        Queue<int[]> nextPassCheck = new Queue<int[]>();

        int x = grid.GetLength(0) / 2;
        int y = grid.GetLength(1) / 2;
        float probability = 1f;
        Boolean mapEnd = false;

        int[] initialPosition = { x, y };
        int loopCounter = 0;
        float decayStep = 0.2f;

        positionsToCheck.Enqueue(initialPosition);

        while (!mapEnd)
        {
            while (positionsToCheck.Count != 0)
            {
                int[] currentPosition = positionsToCheck.Dequeue();
                checkedPositions.Enqueue(currentPosition);

                x = currentPosition[0];
                y = currentPosition[1];

                if (rand.NextDouble() < probability || (x == initialPosition[0] && y == initialPosition[1]))
                {
                    grid[x, y] = 2;

                    int[][] newPositions = { x < grid.GetLength(0) - 1 ? new int[] { x + 1, y} : null,
                                            x > 0 ? new int[] { x - 1, y} : null,
                                            y < grid.GetLength(1) - 1 ? new int[] { x, y + 1} : null,
                                            y > 0 ? new int[] { x, y - 1} : null
                                            };

                    for (int i = 0; i < newPositions.Count(); i++)
                    {
                        if (newPositions[i] != null)
                        {
                            if (!checkedPositions.Any(j => j.SequenceEqual(newPositions[i])))
                            {
                                if (!positionsToCheck.Any(j => j.SequenceEqual(newPositions[i])))
                                {
                                    if (!nextPassCheck.Any(j => j.SequenceEqual(newPositions[i])))
                                    {
                                        nextPassCheck.Enqueue(newPositions[i]);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    grid[x, y] = 1;
                }
            }

            if (nextPassCheck.Count() == 0)
            {
                mapEnd = true;
            }
            else
            {
                while (nextPassCheck.Count > 0)
                {
                    positionsToCheck.Enqueue(nextPassCheck.Dequeue());
                }
            }

            probability = CalculateProbability(loopCounter, decayStep);

            loopCounter++;
        }

        return grid;
    }

    private float CalculateProbability(int loopCounter, float decayStep)
    {
        // x * 0.2(1 - e^2x) + 1
        if (loopCounter < 4)
        {
            float probability;
            float decayX = loopCounter * decayStep;
            probability = (float)(decayX * probabilityModifier * (1.0f - Math.Exp(2f * decayX)) + 1.0f);
            return probability;
        }
        return (float)rand.Next(30, 60) / 100;
    }

    private void BuildMap(int[,] grid)
    {
        for (int i = 0; i < grid.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < grid.GetLength(1) - 1; j++)
            {
                if (grid[i, j] == 2)
                {
                    GameObject component = Instantiate(getFloorTile(), new Vector3((i * ROOM_SIZE), 0, (j * ROOM_SIZE)), Quaternion.identity);
                    component.transform.parent = transform;
                }
                else if (grid[i, j] == 1)
                {
                    GameObject component = Instantiate(walls, new Vector3((i * ROOM_SIZE) - ROOM_SIZE / 2, ROOM_SIZE / 2, (j * ROOM_SIZE)), Quaternion.identity);
                    component.transform.parent = transform;
                }
            }
        }
    }

    private void SpawnPlayer()
    {
        Vector3 startingPosition;

        int mapMiddle = (ROOM_SIZE * floorSize) / 2;

        if (!Settings.SeeMapGeneration)
        {
            GameObject player = ResourceLoader.GetPlayer();

            startingPosition = new Vector3(mapMiddle, 1, mapMiddle);

            Instantiate(player, startingPosition, Quaternion.identity);
        }
        else
        {
            startingPosition = new Vector3(mapMiddle, 150, mapMiddle);
            var rotation = new Quaternion(90, 0, 0, 0);


            var camera = new GameObject().AddComponent<Camera>();

            camera.transform.position = startingPosition;
            camera.transform.rotation = Quaternion.Euler(90, 0, 0);
        }
    }

    private void SpawnEnemies()
    {
        GameObject enemyToSpawn = ResourceLoader.GetEnemies(1)[0];

        for (int i = 0; i < 10; i++)
        {
            Vector3 enemyPosition = new Vector3(rand.Next(ROOM_SIZE * floorSize), 0, rand.Next(ROOM_SIZE * floorSize));

            if (enemyToSpawn.GetComponentInChildren<Enemy>())
            {
                enemyToSpawn.GetComponentInChildren<Enemy>().Spawn(enemyToSpawn, enemyPosition, Quaternion.identity);
            }
            else
            {
            }
        }

        Level.IncrementEnemyCount();
    }

    private GameObject getFloorTile()
    {
        return floorTiles.ElementAt(rand.Next(0, floorTiles.Count()));
    }

    public void RebuildRoom()
    {
        surface.RemoveData();

        var objs = GetComponentsInParent<Transform>();

        foreach (Transform child in transform)
        {            
                GameObject.Destroy(child.gameObject);
        }

        CreateRoom();
    }
}
