using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAIRange : MonoBehaviour
    //몬스터의 AI 인식 범위 콜라이더에 붙여진 스크립트
{
    public Monster parentMonster;
    public MonsterControl control;
    public GameObject ob;
    public PlayerData pl;

    MonsterMoveAI moveToOb;
    MonsterMoveAI moveToPl;

    void Start()
    {
        ob = PlayManager.Instance.GetTheObject();
        pl = PlayManager.Instance.GetData();
        parentMonster = GetComponentInParent<Monster>();
        control = parentMonster.GetComponent<MonsterControl>();
        
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.tag == "Player")
        {
            control.targetEntity = c.gameObject;
        }
    }

    void OnTriggerExit(Collider c)
    {
        if (c.tag == "Player")
        {
            control.targetEntity = PlayManager.Instance.GetTheObject();
            
        }
    }
}

