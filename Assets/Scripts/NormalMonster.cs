using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMonster : Monster
    //일반 몹들
{
    float attackSpd = 1f;
    float attackCool = 0f;
    float damage = 1f;

    public void Awake()
    {
        maxHP = 3f;
        HP = 3f;
    }

    void Update()
    {
        if (attackCool > 0f)
        {
            attackCool -= Time.deltaTime;
        }   
    }


    void OnCollisionStay(Collision c)
        //부딪히면 데미지 줌
    {
        if (c.gameObject.tag == "Player")
        {
            if (attackCool <= 0f)
            {
                c.gameObject.GetComponent<CharacterData>().GetDamage(damage);
                attackCool += 1f / attackSpd;
            }
        }
        if (c.gameObject.tag == "Object")
        {
            if (attackCool <= 0f)
            {
                c.gameObject.GetComponent<Stage_1_Object>().GetDamage(damage);
                attackCool += 1f / attackSpd;
            }
        }
    }
}
