using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage_1_Object : MonoBehaviour
    //스테이지 1, 오브젝트인 자동차에 붙어있다
{
    public Canvas uiCanvas;
    public Image hpBar;
    public Image objectBar;
    public Image oilingBar;

    private float hp;
    public float HP     //자동차의 HP, 0 이하면 파괴됨
    {
        get { return hp; }
        set
        {
            hp = value;

            if (hp <= 0f)
            {
                DestroyCall();
            }
        }
    }
    float maxHP;

    private float obejctPercent;
    public float ObjectPercent  //주유 달성률, 4가 되면 스테이지 1 클리어
    {
        get
        {
            return obejctPercent;
        }
        set
        {
            obejctPercent = value;
            if (obejctPercent != 0)
                SystemMessage.SystemMessageCreate($"주유 달성률 : {obejctPercent} / {maxPercent}");
            if (ObjectPercent == 1)
        {
            LevelManager.Instance.level_1_stage = 3;
        }
            if (obejctPercent == maxPercent)
            {
                LevelManager.Instance.level_1_stage = 4;
            }
        }
    }
    float maxPercent;

    public void Init_1_Object()         //오브젝트 1의 초기화, 레벨 초기화 단계에서 호출
    {
        foreach (var s in spawner)
        {
            s.StopAllCoroutines();
        }

        maxHP = 300;
        HP = maxHP;
        maxPercent = 4f;
        ObjectPercent = 0f;
        oilingPercent = 0f;
        maxOilPercent = 15f;
    }

    private void Start()
    {
        Init_1_Object();
    }

    public void GetDamage(float damage)
    {
        HP -= damage;
    }

    public void DestroyCall()       //파괴되면, 게임 오버 (재사용해야 하므로, Destroy는 안해줌)
    {
        PlayManager.Instance.GameOver();
    }

    private void Update()       //UI적인 부분 업데이트
    {
        uiCanvas.transform.LookAt(Camera.main.transform);
        hpBar.fillAmount = HP / maxHP;
        objectBar.fillAmount = ObjectPercent / maxPercent;
        oilingBar.fillAmount = oilingPercent / maxOilPercent;
    }

    private void OnTriggerEnter(Collider c)
        //플레이어가 연료통을 들고 왔을 때
    {

        if (c.gameObject.tag == "Player")
        {
            PlayerData pData = c.gameObject.GetComponent<PlayerData>();

            if (pData.Sub_Weapon != null)
            {
                if (pData.Sub_Weapon.weapon == Weapons.JERRYCAN)
                {
                    if (LevelManager.Instance.level_1_stage == 2)
                        LevelManager.Instance.level_1_stage = 3;

                    pData.Sub_Weapon = null;
                    StartCoroutine(WaitOilComplete());
                }
            }
        }
    }

    private float oilingPercent = 0f;
    private float maxOilPercent = 15f;
    private float oiling_Spd = 1f;

    public MobSpawner[] spawner;        

    IEnumerator WaitOilComplete()
        //주유 과정
    {
        SoundManager.Instance.PlaySound(3);

        if (ObjectPercent == 0)
        {
            LevelManager.Instance.level_1_stage = 2;
        }

        SystemMessage.SystemMessageCreate("좀비가 몰려옵니다!!!");

        //주유 중에 좀비 소환
        foreach (var s in spawner)
        {
            s.Init_Spawner(20, 2f);
        }

        //주유 완료까지 지켜야함
        while (oilingPercent <= maxOilPercent)
        {
            oilingPercent += Time.deltaTime * oiling_Spd;

            yield return null;
        }
        oilingPercent = 0f;
        ObjectPercent += 1f;
    }
}
