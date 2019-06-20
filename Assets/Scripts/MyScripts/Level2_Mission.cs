using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2_Mission : MonoBehaviour
{
    public MobSpawner[] spawner;

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player" && LevelManager.Instance.level == 0)
        {
            LevelManager.Instance.level_2_stage = 1;
            StartCoroutine(Wave1());
        }
    }

    IEnumerator Wave1()
    {
        foreach (var s in spawner)
        {
            s.Init_Spawner(10, 2f, true);
        }

        yield return new WaitForSeconds(20f);

        StartCoroutine(Wave2());
    }

    IEnumerator Wave2()
    {
        foreach (var s in spawner)
        {
            s.Init_Spawner(15, 2f, true);
        }

        yield return new WaitForSeconds(20f);

        StartCoroutine(Wave3());
    }

    IEnumerator Wave3()
    {
        foreach (var s in spawner)
        {
            s.Init_Spawner(20, 2f, true);
        }

        yield return new WaitForSeconds(20f);

        LevelManager.Instance.level_2_stage = 2;
    }
}
