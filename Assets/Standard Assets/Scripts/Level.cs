using UnityEngine;
using System.Collections.Generic;

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

    private readonly Level INSTANCE = new Level();

    private Level()
    {

    }

    public Level GetInstance()
    {
        return INSTANCE;
    }

}
