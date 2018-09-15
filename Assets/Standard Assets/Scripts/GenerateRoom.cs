using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;

public class GenerateRoom : MonoBehaviour {

	public int[,] grid = new int[9,9];
	public float probabilityModifier = 0.8f;
	public List<GameObject> floorTiles;
	public GameObject walls;
	private System.Random rand = new System.Random();

	// Use this for initialization
	public void CreateRoom () {
		mapRoom();
        buildMap();
	}

	private void mapRoom()
	{

		Queue<int[]> checkedPositions = new Queue<int[]>();
		Queue<int[]> positionsToCheck = new Queue<int[]>();
		Queue<int[]> nextPassCheck = new Queue<int[]>();

		int x = 4;
		int y = 4;
		float probability = 1;
		Boolean mapEnd = false;

		int[] initialPosition = { x, y };

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
					grid[x, y] = 1;

					int[][] newPositions = { x < 8 ? new int[] { x + 1, y} : null,
											x > 0 ? new int[] { x - 1, y} : null,
											y < 8 ? new int[] { x, y + 1} : null,
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
					grid[x, y] = 0;
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


			probability *= probabilityModifier;

		}
	}

    private void buildMap()
    {
        for (int i = 0; i < grid.GetLength(0) - 1; i++)
        {
            for (int j = 0; j < grid.GetLength(1) - 1; j++)
            {
                if (grid[i, j] == 1)
                {
                    GameObject component = (GameObject) Instantiate(getFloorTile(), new Vector3((i * 10), 0, (j * 10)), Quaternion.identity);
                    component.transform.parent = transform;
                }
                else
                {
                    GameObject component = (GameObject) Instantiate(walls, new Vector3((i * 10) - 5, 5, (j * 10)), Quaternion.identity);
                    component.transform.parent = transform;
                }
            }
        }
    }

	private GameObject getFloorTile()
	{
		return floorTiles.ElementAt(rand.Next(0, floorTiles.Count()));
	}
}
