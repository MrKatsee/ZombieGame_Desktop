using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; } = null;

    private void Awake()
    {
        Instance = this;
    }

    public GameObject[] jerryCan;

    public static int level = 1;
    public int level_1_stage = 0;
    private void Start()
    {
        Init_Player(level);
    }

    IEnumerator Level_1_Routine()
    {

        SystemMessage.SystemMessageCreate("자동차를 가동시키기 위해 주유소로 가서 기름통을 들고 오십시오.");

        yield return new WaitUntil(() => level_1_stage == 1);

        SystemMessage.SystemMessageCreate("기름통을 자동차까지 들고 가십시오.");

        yield return new WaitUntil(() => level_1_stage == 2);

        SystemMessage.SystemMessageCreate("주유가 완료될 때까지 자동차를 지키십시오.");

        yield return new WaitUntil(() => level_1_stage == 3);

        SystemMessage.SystemMessageCreate("자동차의 주유를 완료하십시오.");

        yield return new WaitUntil(() => level_1_stage == 4);

        level = 2;
        SceneManager.LoadScene("Between_map1_map2_JM");
    }

    public int level_2_stage = 0;
    IEnumerator Level_2_Routine()
    {
        SystemMessage.SystemMessageCreate("무전기로 가서 연락을 취하십시오.");

        yield return new WaitUntil(() => level_2_stage == 1);

        SystemMessage.SystemMessageCreate("다시 연락이 올 때까지 버티십시오.");

        yield return new WaitUntil(() => level_2_stage == 2);

        SystemMessage.SystemMessageCreate("철조망 앞으로 가십시오.");

        yield return new WaitUntil(() => level_2_stage == 3);

        PlayManager.Instance.GameOver();
    }

    public void Init_Player(int init_Level)
    {
        var zombies = FindObjectsOfType<NormalMonster>();
        foreach (var z in zombies)
        {
            z.DestroyCall(false);
        }

        if (init_Level == 1)
        {
            level = 1;
            level_1_stage = 0;

            PlayManager.Instance.GetData().transform.position = new Vector3(4f, 0f, 0f);
            PlayManager.Instance.GetData().Init_Player();
            PlayManager.Instance.GetTheObject().GetComponent<Stage_1_Object>().Init_1_Object();
            StartCoroutine(Level_1_Routine());
            foreach (var j in jerryCan)
            {
                j.SetActive(true);
            }
        }
        else if (init_Level == 2)
        {
            level = 2;
            level_2_stage = 0;

            PlayManager.Instance.GetData().transform.position = new Vector3(105f, 0f, -30f);
            PlayManager.Instance.GetData().Init_Player();
            PlayManager.Instance.GetStage2_Object().GetComponent<Level2_Mission>().StopAllCoroutines();
            StartCoroutine(Level_2_Routine());
        }
    }
    public void RestartCall()
    {
        Init_Player(level);
    }
}
