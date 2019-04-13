using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.AI;
using Assets.Standard_Assets.Classes;
using Assets.Standard_Assets.Scripts;

public class GenerateRoom : MonoBehaviour {

    public int floorSize = 9;
    public bool[,] grid;
	public float probabilityModifier = 0.8f;
	private List<GameObject> floorTiles;
	public GameObject walls;
	public System.Random rand = new System.Random();
    public const int ROOM_SIZE = 10;

    public NavMeshSurface surface;

    public void Start()
    {
        floorTiles = ResourceLoader.GetRoomTiles(1);
        CreateRoom();
        surface.BuildNavMesh();
        SpawnEnemies();
    }

    // Use this for initialization
    public void CreateRoom()
    {
        grid = new bool[floorSize, floorSize];

        mapRoom();
        buildMap();
    }

    private void mapRoom()
	{

		Queue<int[]> checkedPositions = new Queue<int[]>();
		Queue<int[]> positionsToCheck = new Queue<int[]>();
		Queue<int[]> nextPassCheck = new Queue<int[]>();

		int x = grid.GetLength(0) / 2;
		int y = grid.GetLength(1) / 2;
		float probability = 1;
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

                if (rand.NextDouble() < probability)
                {
                    grid[x, y] = true;

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
                    grid[x, y] = false;
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
    }

    private float CalculateProbability(int loopCounter, float decayStep)
    {
        // x * 0.2(1 - e^2x) + 1
        float probability;
        float decayX = loopCounter * decayStep;
        probability = (float)(decayX * 0.2f * (1.0f - Math.Exp(2f * decayX)) + 1.0f);
        return probability;
    }

    private void buildMap()
    {
        for (int i = 0; i < grid.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < grid.GetLength(1) - 1; j++)
            {
                if (grid[i, j])
                {
                    GameObject component = Instantiate(getFloorTile(), new Vector3((i * ROOM_SIZE), 0, (j * ROOM_SIZE)), Quaternion.identity);
                    component.transform.parent = transform;
                }
                else
                {
                    GameObject component = Instantiate(walls, new Vector3((i * ROOM_SIZE) - ROOM_SIZE/2, ROOM_SIZE/2, (j * ROOM_SIZE)), Quaternion.identity);
                    component.transform.parent = transform;
                }
            }
        }
    }

    private void SpawnEnemies()
    {
        GameObject enemyToSpawn = ResourceLoader.GetEnemies(1)[1];

        for (int i = 0; i < 10; i++)
        {
            if (enemyToSpawn.GetComponentInChildren<Enemy>())
            {
                enemyToSpawn.GetComponentInChildren<Enemy>().Spawn(enemyToSpawn, Vector3.zero, Quaternion.identity);
            }
            else
            {
                Debug.Log("Cannot find type: \"enemy\" on given object");
            }
        }

        //Instantiate(ResourceLoader.GetEnemies(1)[1], Vector3.zero, Quaternion.identity);
        //Instantiate(ResourceLoader.GetEnemies(1)[1], Vector3.zero, Quaternion.identity);
        //Instantiate(ResourceLoader.GetEnemies(1)[1], Vector3.zero, Quaternion.identity);
        //Instantiate(ResourceLoader.GetEnemies(1)[1], Vector3.zero, Quaternion.identity);
        //Instantiate(ResourceLoader.GetEnemies(1)[1], Vector3.zero, Quaternion.identity);
        //Instantiate(ResourceLoader.GetEnemies(1)[1], Vector3.zero, Quaternion.identity);
        //Instantiate(ResourceLoader.GetEnemies(1)[1], Vector3.zero, Quaternion.identity);
        //Instantiate(ResourceLoader.GetEnemies(1)[1], Vector3.zero, Quaternion.identity);
        //Instantiate(ResourceLoader.GetEnemies(1)[1], Vector3.zero, Quaternion.identity);
        //Instantiate(ResourceLoader.GetEnemies(1)[1], Vector3.zero, Quaternion.identity);
        //Instantiate(ResourceLoader.GetEnemies(1)[1], Vector3.zero, Quaternion.identity);
        //Instantiate(ResourceLoader.GetEnemies(1)[1], Vector3.zero, Quaternion.identity);
        //Instantiate(ResourceLoader.GetEnemies(1)[1], Vector3.zero, Quaternion.identity);
        //Instantiate(ResourceLoader.GetEnemies(1)[1], Vector3.zero, Quaternion.identity);
        //Instantiate(ResourceLoader.GetEnemies(1)[1], Vector3.zero, Quaternion.identity);
        //Instantiate(ResourceLoader.GetEnemies(1)[1], Vector3.zero, Quaternion.identity);
        //Instantiate(ResourceLoader.GetEnemies(1)[1], Vector3.zero, Quaternion.identity);
        Level.GetInstance().IncrementEnemyCount();
    }

	private GameObject getFloorTile()
	{
		return floorTiles.ElementAt(rand.Next(0, floorTiles.Count()));
	}
}
