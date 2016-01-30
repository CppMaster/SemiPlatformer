﻿
using UnityEngine;
using System.Collections;

public class Player : Puncher {

    [HideInInspector]
    public bool isBlocking = false;

	float speedTimeLeft = 0f;
	float powerTimeLeft = 0f;

    public float speedMultiplier = 2f;
    public float speedTime = 5f;
    public float powerMultiplier = 2f;
    public float powerTime = 5f;
    public float hpAdd = 50f;

    public static Player instance;

    void Awake()
    {
        instance = this;
    }

    protected override void Update()
    {
        base.Update();

        speedTimeLeft -= Time.deltaTime;
        powerTimeLeft -= Time.deltaTime;
    }

    void OnTriggerEnter(Collider col)
    {
        Item item = col.GetComponent<Item>();
        if(item != null)
        {
            switch(item.type)
            {
                case Item.Type.HP:
                    currentHP = Mathf.Min(maxHP, currentHP + hpAdd);
                    break;
                case Item.Type.Power:
                    powerTimeLeft = powerTime;
                    break;
                case Item.Type.Speed:
                    speedTimeLeft = speedTime;
                    break;
            }
            item.Pickup();
        }
    }

    public override float GetDamage()
    {
        return base.GetDamage() * (powerTimeLeft > 0f ? powerMultiplier : 1f);
    }

    public float GetSpeedMultiplier()
    {
        return speedTimeLeft > 0f ? speedMultiplier : 1f;
    }

    public override void Damage(Puncher puncher)
    {
        if (isBlocking && IsFacingRight() != puncher.IsFacingRight()) return;
        base.Damage(puncher);
    }
}
