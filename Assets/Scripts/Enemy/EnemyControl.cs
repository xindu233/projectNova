﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//控制敌人的类。所有敌人都需使用该类。
public class EnemyControl : MonoBehaviour
{
    public float HP = 10;
    public float maxHP = 10;

    public string DestoryEffect;

    public bool IsNotRecycled = true;

    List<WeaponControlEnemy> weaponControls = new List<WeaponControlEnemy>();
    List<WeaponNew> weaponNews = new List<WeaponNew>();
    public List<GameObject> shootPoints = new List<GameObject>();

    public List<string> WeaponName = new List<string>();

    public virtual void Hitted(float hp)
    {
        HP -= hp;
        if (HP <= 0 && IsNotRecycled) {
            RecycleNow();
            IsNotRecycled = false;
        }
    }

    public void Awake()
    {
        HP = maxHP;
        IsNotRecycled = true;

        /*for (int i = 0; i < WeaponName.Count; i++)
        {
            weaponControls.Add(gameObject.AddComponent<WeaponControlEnemy>());
            weaponControls[i].WeaponName = WeaponName[i];
            weaponControls[i].LoadWeapon(WeaponName[i]);
        }*/
        //WeaponLoader weaponLoader = new WeaponLoader();
        for (int i = 0; i < WeaponName.Count; i++)
        {
            weaponNews.Add(WeaponLoader.LoadWeaponAndAttachToGO(WeaponName[i], gameObject));
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<CharacterControl>().DecHP();
            RecycleNow();
        }
    }

    public void RecycleNow()
    {
        Destroy(gameObject);
        try
        {
            Camera.main.GetComponent<StageIniter>().KilledOneEnemy();
        }
        catch {
            Debug.Log("一个敌人被消灭。如果此消息不在波次测试中出现，请检查代码bug");
        }
        ScoreData.Instance.levelScore++;
    }

    public void Shoot(Vector3 dir)
    {
        //for (int i = 0; i < weaponControls.Count; i++)
        //    weaponControls[i].Shoot(shootPoints[i].transform.position, dir);
        for (int i = 0; i < weaponNews.Count; i++)
        {
            weaponNews[i].Shoot(shootPoints[i].transform.position, Vector3.down);
        }
    }
}
