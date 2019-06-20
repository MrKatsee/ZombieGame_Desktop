﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterData : MonoBehaviour
{
    public float hp;
    public float HP
    {
        get { return hp; }
        set
        {
            hp = value;

            if (hp <= 0f)
            {
                DestroyCall();
            }
            else if (hp > maxHP) hp = maxHP;
        }
    }
    public float maxHP;

    public virtual void GetDamage(float damage)
    {
        HP = HP - damage;
    }

    public virtual void DestroyCall()
    {
        Destroy(gameObject);
    }
}
