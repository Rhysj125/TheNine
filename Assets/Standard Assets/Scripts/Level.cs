using Assets.Standard_Assets.Classes;
using UnityEngine;

public static class Level {

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

    public static bool IsLevelComplete { get; private set; } = false;
    public static bool IsGameRunning { get; set; } = true;

    private static int NumOfEnemies = 0;

    public static void ResetToDefault()
    {
        NumOfEnemies = 0;
        IsGameRunning = true;
        IsLevelComplete = false;
    }

    public static int GetEnemyCount()
    {
        return NumOfEnemies;
    }

    public static void IncrementEnemyCount()
    {
        NumOfEnemies++;
    }

    public static void DecrementEnemyCount()
    {
        --NumOfEnemies;

        if (NumOfEnemies <= 1)
        {
            //Do something to spawn portal to next room.
            GameObject.Instantiate(ResourceLoader.GetPortal(), new Vector3(45,2,45), Quaternion.identity);
            IsLevelComplete = true;
        }
    }

}
