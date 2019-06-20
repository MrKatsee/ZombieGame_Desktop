using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage_1_Object : MonoBehaviour
{
    public Canvas uiCanvas;
    public Image hpBar;
    public Image objectBar;
    public Image oilingBar;

    private float hp;
    public float HP
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
    public float ObjectPercent
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

            if (obejctPercent == maxPercent)
            {
                LevelManager.Instance.level_1_stage = 3;
            }
        }
    }
    float maxPercent;

    private void Start()
    {
        maxHP = 100;
        HP = maxHP;
        maxPercent = 4f;
        ObjectPercent = 0f;
    }

    public void GetDamage(float damage)
    {
        HP -= damage;
    }

    public void DestroyCall()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        uiCanvas.transform.LookAt(Camera.main.transform);
        hpBar.fillAmount = HP / maxHP;
        objectBar.fillAmount = ObjectPercent / maxPercent;
        oilingBar.fillAmount = oilingPercent / maxOilPercent;
    }

    private void OnTriggerEnter(Collider c)
    {
        Debug.Log("Hello");
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
    private float maxOilPercent = 30f;
    private float oiling_Spd = 1f;

    public MobSpawner[] spawner;        

    IEnumerator WaitOilComplete()
    {
        if (ObjectPercent == 0)
        {
            LevelManager.Instance.level_1_stage = 2;
        }

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
