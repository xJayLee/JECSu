﻿using UnityEngine;
using System;
using System.Collections.Generic;
using JECSU;
using JECSU.Components;

public class TestGameViewSystem : IInitializeSystem, IMatcherSystem<GameView>, IExecuteSystem
{
    public bool isActive
    {
        get;set;
    }

    public Matcher matcher
    {
        get;set;
    }

    public void Execute()
    {

    }

    public void Initialize()
    {
        
    }

    public void OnMatchAdded(Entity ent, Type t)
    {
        var res = ent.GetComponent<GameRes>();
        if (res != null)
        {
            var gameview = ent.GetComponent<GameView>();
            var prefab = (GameObject) Resources.Load(res.prefabID);
            var go = GameObject.Instantiate(prefab);
            gameview.view = go.GetComponent<GameViewBehavior>();
            if (gameview.view == null)
                gameview.view = go.AddComponent<GameViewBehavior>();
            gameview.view.Initialize(ent);
        }
    }

    public void OnMatchRemoved(Entity ent, Type t)
    {
       
    }
}
