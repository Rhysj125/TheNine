using UnityEngine;
using System.Collections.Generic;
using Assets.Standard_Assets.Classes;

public class Level {

    private enum Difficulty { Easy = 1, Normal = 3, Hard = 5 }

    private enum Stage
    {
        One = 1,
        Two = 3,
        Three = 7,
        Four = 12,
        Five = 18,
        Six = 22,
        Seven = 25,
        Eight = 29,
        Nine = 35
    }

    private static readonly Level INSTANCE = new Level();

    private int NumOfEnemies = 0;

    private Level()
    {

    }

    public static Level GetInstance()
    {
        return INSTANCE;
    }

    public int GetEnemyCount()
    {
        return NumOfEnemies;
    }

    public void IncrementEnemyCount()
    {
        NumOfEnemies++;
    }

    public void DecrementEnemyCount()
    {
        --NumOfEnemies;

        if (NumOfEnemies <= 1)
        {
            //Do something to spawn portal to next room.
            GameObject.Instantiate(ResourceLoader.GetPortal(), new Vector3(45,2,45), Quaternion.identity);
        }
    }

}
