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

    public void Init_Spawner(int n, float spd)
        //초기화
    {
        mobNum = n;
        spawnSpd = spd;
        StartCoroutine(SpawnMob());
    }

    public void Init_Spawner(int n, float spd, bool targetPlayer)
        //플레이어에게 이동하게 하는 몹을 생성하는 스포너 (하드 코딩...)
    {
        mobNum = n;
        spawnSpd = spd;
        StartCoroutine(SpawnMob_TargettingPlayer());
    }

    IEnumerator SpawnMob()
        //몹을 소환 속도만큼 빠르기로 소환 수만큼 소환한다.
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
    //몹을 소환 속도만큼 빠르기로 소환 수만큼 소환한다. 몹은 플레이어를 타겟으로 쫓아다닌다.
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
