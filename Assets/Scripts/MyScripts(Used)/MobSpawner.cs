using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    public GameObject mob;
    public int mobNum = 10;      //소환할 몹 개수
    public float spawnSpd = 1f;

    private void Start()
    {
        //StartCoroutine(SpawnMob());
    }

    //Init 함수 만들어야함
    public void Init_Spawner(int n, float spd)
    {
        mobNum = n;
        spawnSpd = spd;
        StartCoroutine(SpawnMob());
    }

    public void Init_Spawner(int n, float spd, bool targetPlayer)
    {
        mobNum = n;
        spawnSpd = spd;
        StartCoroutine(SpawnMob_TargettingPlayer());
    }

    IEnumerator SpawnMob()
    {
        int count = 0;

        while(true)
        {
            if (mobNum == count)
                break;

            GameObject temp = Instantiate(mob, transform.position + new Vector3(Random.Range(3f, -3f), 0f, Random.Range(3f, -3f)), Quaternion.identity);

            count++;

            yield return new WaitForSeconds(1f * (1f/spawnSpd) + Random.Range(0.5f, -0.5f));
        }

    }

    IEnumerator SpawnMob_TargettingPlayer()
    {
        int count = 0;

        while (true)
        {
            if (mobNum == count)
                break;

            GameObject temp = Instantiate(mob, transform.position + new Vector3(Random.Range(3f, -3f), 0f, Random.Range(3f, -3f)), Quaternion.identity);
            temp.GetComponent<MonsterControl>().targetEntity = PlayManager.Instance.GetData().gameObject;

            count++;

            yield return new WaitForSeconds(1f * (1f / spawnSpd) + Random.Range(0.5f, -0.5f));
        }

    }
}
