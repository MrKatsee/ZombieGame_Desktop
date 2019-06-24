using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    //레벨을 총괄하는 싱글톤 매니저
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
        //메인 씬 호출 시, 현재 레벨에 따라 초기화를 실행함.
        Init_Player(level);
    }
    public GameObject[] objectPointer;

    IEnumerator Level_1_Routine()
    {
        //레벨 1 루틴
        SystemMessage.SystemMessageCreate("나 : 젠장... 연료가 없잖아!");

        yield return new WaitForSeconds(3f);

        SystemMessage.SystemMessageCreate("나 : 어디에 연료가 없으려나...");

        yield return new WaitForSeconds(3f);

        SystemMessage.SystemMessageCreate("자동차를 가동시키기 위해 주유소로 가서 연료통을 들고 오십시오.");
        objectPointer[0].SetActive(true);

        yield return new WaitUntil(() => level_1_stage == 1);
        objectPointer[0].SetActive(false);

        SystemMessage.SystemMessageCreate("연료통을 자동차까지 들고 가십시오.");
        objectPointer[1].SetActive(true);

        yield return new WaitUntil(() => level_1_stage == 2);
        objectPointer[1].SetActive(false);

        SystemMessage.SystemMessageCreate("주유가 완료될 때까지 자동차를 지키십시오.");

        yield return new WaitUntil(() => level_1_stage == 3);

        SystemMessage.SystemMessageCreate("나 : 좋았어! 앞으로 3번만 더 하면 가동할 수 있겠어.");

        yield return new WaitForSeconds(3f);

        SystemMessage.SystemMessageCreate("자동차의 주유를 완료하십시오.");

        yield return new WaitUntil(() => level_1_stage == 4);

        level = 2;

        //레벨 1이 끝났으므로 사이 씬 실행
        SceneManager.LoadScene("Between_map1_map2_JM");
    }

    public int level_2_stage = 0;
    IEnumerator Level_2_Routine()
    {
        //레벨 2 루틴
        SystemMessage.SystemMessageCreate("무전기로 가서 연락을 취하십시오.");
        objectPointer[2].SetActive(true);

        yield return new WaitUntil(() => level_2_stage == 1);
        objectPointer[2].SetActive(false);

        SystemMessage.SystemMessageCreate("다시 연락이 올 때까지 버티십시오.");

        yield return new WaitUntil(() => level_2_stage == 2);

        SystemMessage.SystemMessageCreate("미군 : 좋아... 잘 버텨주었군! 윗 다리의 철조망 앞으로 오게.");

        yield return new WaitForSeconds(3f);

        SystemMessage.SystemMessageCreate("철조망 앞으로 가십시오.");
        objectPointer[3].SetActive(true);

        yield return new WaitUntil(() => level_2_stage == 3);
        objectPointer[3].SetActive(false);

        //레벨 2가 끝나, 클리어
        PlayManager.Instance.GameOver();
    }

    public void Init_Player(int init_Level)
        //Init Player지만, 레벨 초기화 함수다. Restart나 Main Scene 실행 시 호출됨.
    {
        //기존에 있던 모든 코루틴을 멈추고 모든 오브젝트를 초기화하는 과정
        StopAllCoroutines();

        var zombies = FindObjectsOfType<NormalMonster>();
        foreach (var z in zombies)
        {
            z.DestroyCall(false);
        }
        var boxes = FindObjectsOfType<DropBox>();
        foreach (var b in boxes)
        {
            if (b.weapon.weapon != Weapons.JERRYCAN)
                Destroy(b.gameObject);
        }
        var sounds = FindObjectsOfType<SoundAsset>();
        foreach (var s in sounds)
        {
            Destroy(s.gameObject);
        }
        foreach (var o in objectPointer)
        {
            o.SetActive(false);
        }
        //브금 틀기
        SoundManager.Instance.PlaySound(0);

        //각 스테이지에 맞춰 초기화를 진행해준다.
        if (init_Level == 1)
        {
            level = 1;
            level_1_stage = 0;

            PlayManager.Instance.GetData().transform.position = new Vector3(4f, 0f, 0f);
            PlayManager.Instance.GetData().Init_Player();
            PlayManager.Instance.GetTheObject().GetComponent<Stage_1_Object>().StopAllCoroutines();
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
