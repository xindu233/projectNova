﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysShoot : EnemyBehaviours
{
    public AlwaysShoot(GameObject Obj,float t)
    {
        time = t;
        this.gameObject = Obj;
    }

    public override Vector3 Calculate(float Dt) {
        return new Vector3(0,0,0);
    }

    public override void Start()
    {
        
    }

    public override void Run(float Dt) {
        gameObject.GetComponent<EnemyBehaviourController>().AlwaysShoot = true;
    }

    public override void End()
    {
        
    }
}