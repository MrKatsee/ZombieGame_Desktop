using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalMonster : Monster
{
    float attackSpd = 1f;
    float attackCool = 0f;
    float damage = 1f;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        HP = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackCool > 0f)
        {
            attackCool -= Time.deltaTime;
        }   
    }


    void OnCollisionStay(Collision c)
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
