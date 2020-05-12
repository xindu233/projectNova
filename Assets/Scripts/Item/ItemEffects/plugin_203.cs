﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 装填强化
public class plugin_203 : ItemEffects
{
    private readonly float rate = 1.2f;
    private Component[] w;
    private GameObject player;
    public plugin_203()
    {    
        
    }
    public override void Run()
    {
        player = GameObject.Find("Player");
        
        w = player.GetComponents(typeof(WeaponNormalGun));
        foreach (var component in w)
        {
            ((WeaponNormalGun) component).FireSpeed *= 1 / rate;
        }
    }

    public override void Update()
    {
    }

    public override void End()
    {
        foreach (var component in w)
        {
            ((WeaponNormalGun) component).FireSpeed /= 1 / rate;
        }
    }

    public override bool Condition()
    {
        return true;
    }
}
