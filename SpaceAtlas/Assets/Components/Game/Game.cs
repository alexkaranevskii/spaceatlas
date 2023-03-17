using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : IDisposable
{
    private readonly LevelLoader _levelLoader;

    public Game(LevelLoader levelLoader)
    {
        _levelLoader = levelLoader;

    }

    public void Dispose()
    {
        
    }
}
