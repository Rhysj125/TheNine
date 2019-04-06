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

    private int NumOfEnemies;

    private Level()
    {

    }

    public static Level GetInstance()
    {
        return INSTANCE;
    }

    public void IncrementEnemyCount()
    {
        NumOfEnemies++;
    }

    public void DecrementEnemyCount()
    {
    //    NumOfEnemies--;

    //    if (NumOfEnemies <= 0)
    //    {
    //        //Do something to spawn portal to next room.
    //        //GameObject.Instantiate(ResourceLoader.);
    //    }
    }

}
