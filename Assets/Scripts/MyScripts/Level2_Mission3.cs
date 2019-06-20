using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2_Mission3 : MonoBehaviour
{
    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player" && LevelManager.Instance.level_2_stage == 2)
        {
            LevelManager.Instance.level_2_stage = 3;
        }
    }
}
