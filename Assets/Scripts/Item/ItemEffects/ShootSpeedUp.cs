﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSpeedUp : ItemEffects, IAccumulate
{
    public int Accumulate { get; }
    public ShootSpeedUp()
    {
        Accumulate = 1000;
        time = 4f;
    }
    public override void Run() {
        GameObject.Find("Player").GetComponent<CharacterControl>().WeaponSpeedChange("/",3);
    }

    public override void Update()
    { return; }

    public override void End()
    {
        GameObject.Find("Player").GetComponent<CharacterControl>().WeaponSpeedChange("*", 3);
    }

    public override bool Condition()
    {
        return true;
    }
}
