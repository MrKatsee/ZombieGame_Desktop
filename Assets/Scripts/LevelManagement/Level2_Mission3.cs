using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2_Mission3 : MonoBehaviour
{
    //미션 3(철조망 앞으로 가시오)에 붙어 있는 스크립트
    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player" && LevelManager.Instance.level_2_stage == 2)
        {
            LevelManager.Instance.level_2_stage = 3;
        }
    }
}
