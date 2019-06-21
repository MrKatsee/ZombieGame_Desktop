using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2_Mission : MonoBehaviour
{
    public MobSpawner[] spawner;

    private void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "Player" && LevelManager.Instance.level_2_stage == 0)
        {
            LevelManager.Instance.level_2_stage = 1;
            StartCoroutine(Wave1());
        }
    }

    IEnumerator Wave1()
    {
        SystemMessage.SystemMessageCreate("좀비가 몰려옵니다!!!");

        foreach (var s in spawner)
        {
            s.Init_Spawner(10, 2f, true);
        }

        yield return new WaitForSeconds(20f);

        if (LevelManager.Instance.level_2_stage == 1)
            StartCoroutine(Wave2());
    }

    IEnumerator Wave2()
    {
        SystemMessage.SystemMessageCreate("좀비가 몰려옵니다!!!");

        foreach (var s in spawner)
        {
            s.Init_Spawner(15, 2f, true);
        }

        yield return new WaitForSeconds(20f);

        if (LevelManager.Instance.level_2_stage == 1)
            StartCoroutine(Wave3());
    }

    IEnumerator Wave3()
    {
        SystemMessage.SystemMessageCreate("좀비가 몰려옵니다!!!");

        foreach (var s in spawner)
        {
            s.Init_Spawner(20, 2f, true);
        }

        yield return new WaitForSeconds(20f);

        if (LevelManager.Instance.level_2_stage == 1)
            LevelManager.Instance.level_2_stage = 2;
    }
}
