using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Monster : CharacterData
{
    public MonsterControl monsterControl;
    public Animator enemyAnimator; // 애니메이터 컴포넌트
    private NavMeshAgent pathFinder; // 경로계산 AI 에이전트

    public virtual void Start()
    {
        monsterControl = GetComponent<MonsterControl>();
        enemyAnimator = GetComponent<Animator>();
        pathFinder = GetComponent<NavMeshAgent>();

        StartCoroutine(GroanSound());
    }

    public MonsterControl GetControl()
    {
        return monsterControl;
    }

    bool drop_On = true;

    public override void DestroyCall()
    {
        SoundManager.Instance.PlaySound(7);
        StartCoroutine(DestroyEnemyRoutine());
    }

    public override void GetDamage(float damage)
    {
        base.GetDamage(damage);
        SoundManager.Instance.PlaySound(6);
    }
    bool alreadyDead = false;

    public void DestroyCall(bool canDrop)
        //드랍박스를 떨구지 않을 수도 있어서 만든 파괴 함수
    {
        drop_On = canDrop;
        if (!alreadyDead)
            StartCoroutine(DestroyEnemyRoutine());
    }

    private IEnumerator DestroyEnemyRoutine()
        //몹이 죽었을 때 호출된다.
    {
        if (drop_On)
            //만약 드랍박스를 떨굴 수 있는 몹이면 해당 위치에 생성함
            PlayManager.Instance.InstantiateDropBox(transform.position + new Vector3(0f, 0.5f, 0f), 0.1f);

        alreadyDead = true;

        Collider[] enemyColliders = GetComponents<Collider>();
        for (int i = 0; i < enemyColliders.Length; i++)
        {
            enemyColliders[i].enabled = false;
        }

        // AI 추적을 중지하고 내비메쉬 컴포넌트를 비활성화
        pathFinder.isStopped = true;
        pathFinder.enabled = false;
        monsterControl.StopAllCoroutines();

        // 사망 애니메이션 재생
        enemyAnimator.SetTrigger("Die");

        yield return new WaitForSeconds(5f);

        Destroy(gameObject);
    }

    IEnumerator GroanSound()
        //소리를 냄 으르렁
    {
        float count = 5f;
        float randomCount = Random.Range(10f, 30f);
        int randomIndex = (int)Random.Range(8f, 10.99f);

        while(true)
        {
            if (count >= randomCount)
            {
                count = 0;
                SoundManager.Instance.PlaySound(randomIndex);
            }

            count += Time.deltaTime;
            yield return null;
        }
    }

}
