﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WingmanAction : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Transform firePos;
    private WeaponControlWingman weaponControlWingman;
    private Wingman wingman;
    // Start is called before the first frame update

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        weaponControlWingman = GetComponent<WeaponControlWingman>();
    }
    /// <summary>
    /// 移动至目标点坐标
    /// </summary>
    /// <param name="targetPos">目标点的二维坐标</param>
    public void Move(Vector2 targetPos)    
    {
        rigidBody.MovePosition(targetPos);
    }
    /// <summary>
    /// 向前发射子弹
    /// </summary>
    public void Attack()
    {
        weaponControlWingman.Shoot(transform.position, Vector3.up);
    }
}