using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; } = null;

    private void Awake()
    {
        Instance = this;
    }

    public int level = 0;
    public int level_1_stage = 0;
    private void Start()
    {
        StartCoroutine(Level_1_Routine());
    }

    IEnumerator Level_1_Routine()
    {
        level = 1;
        level_1_stage = 0;

        SystemMessage.SystemMessageCreate("자동차를 가동시키기 위해 주유소로 가서 기름통을 들고 오세요.");

        yield return new WaitUntil(() => level_1_stage == 1);

        SystemMessage.SystemMessageCreate("기름통을 자동차까지 들고 가세요.");

        yield return new WaitUntil(() => level_1_stage == 2);

        SystemMessage.SystemMessageCreate("주유가 완료될 때까지 자동차를 지키세요.");

        yield return new WaitUntil(() => level_1_stage == 3);

        SystemMessage.SystemMessageCreate("자동차의 주유를 완료하세요.");

        yield return new WaitUntil(() => level_1_stage == 4);
    }
}
