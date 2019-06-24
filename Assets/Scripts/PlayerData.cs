using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : CharacterData
    //플레이어 캐릭터에 달려 있다.
{
    private Weapon main_Weapon;
    public Weapon Main_Weapon
        //메인 웨펀
    {
        get { return main_Weapon; }
        set
        {
            main_Weapon = value;
            //UI적인 부분
            PlayUIManager.Instance.ChangeWeaponUI_Main(main_Weapon);
        }
    }
    private Weapon sub_Weapon;
    public Weapon Sub_Weapon
        //서브웨펀
    {
        get
        {
            return sub_Weapon;
        }
        set
        {
            sub_Weapon = value;
            if (sub_Weapon != null)
                //서브웨펀이 들어왔을 경우
            {
                //UI를 바꿔주고
                PlayUIManager.Instance.ChangeWeaponUI_Sub(Sub_Weapon, true);

                //해당이 JERRYCAN이며, 그것이 미션 클리어에 해당할 경우, 다음 미션으로 넘어감
                if (Sub_Weapon.weapon == Weapons.JERRYCAN && LevelManager.Instance.level_1_stage == 0)
                {
                    LevelManager.Instance.level_1_stage = 1;
                }
            }
            else
            {
                //null일 경우, UI에서 null임을 표시해줌
                PlayUIManager.Instance.ChangeWeaponUI_Sub();
            }


        }
    }
    private Weapon drop_Weapon;
    public Weapon Drop_Weapon
        //땅에 떨어진 웨펀을 임시 저장하는 프로퍼티
    {
        get { return drop_Weapon; }
        set
        {
            drop_Weapon = value;
            if (drop_Weapon != null)
            {
                //땅에 떨어져 있음을 UI적으로 표시해줌
                PlayUIManager.Instance.ChangeWeaponUI_Sub(Drop_Weapon, false);
            }
            else
            {
                //null이 들어옴(drop 박스에서 벗어남)을 UI적으로 표시
                PlayUIManager.Instance.ChangeWeaponUI_Sub();

                if (Sub_Weapon == null)
                    return;

                PlayUIManager.Instance.ChangeWeaponUI_Sub(Sub_Weapon, true);
            }
        }
    }

    public void Init_Player()
        //플레이어 초기화
    {
        maxHP = 15f;
        HP = maxHP;

        //기본 무기
        Main_Weapon = new GameObject("Pistol").AddComponent<Pistol>();
        Main_Weapon.transform.parent = gameObject.transform;
        Main_Weapon.Init_Weapon();
        Sub_Weapon = null;
        PlayUIManager.Instance.ChangeWeaponUI_Main(Main_Weapon);
    }

    void Start()
    {
        Init_Player();
    }

    private void Update()
    {
        PlayUIManager.Instance.UpdateBullet(Main_Weapon);       //메인웨펀의 잔탄수를 UI적으로 표시
        Collider[] c = Physics.OverlapBox(transform.position, new Vector3(1f, 1f, 1f) * 0.5f);  
        bool alreadyGetted = false;

        //땅의 드랍박스와 겹치는지 확인
        foreach (var col in c)
        {
            if (col.gameObject.tag == "Box" && alreadyGetted == false)
            {
                //있으면 드랍웨펀에 저장
                Drop_Weapon = col.gameObject.GetComponent<DropBox>().weapon;
                alreadyGetted = true;
            }
        }

        //없으면 null
        if (alreadyGetted == false)
        {
            Drop_Weapon = null;
        }

    }

    //웨펀 체인지 버튼을 눌렀을 경우
    public void ChangeWeapon()
    {
        Collider[] c = Physics.OverlapBox(transform.position, new Vector3(1f, 1f, 1f) * 0.5f);

        //box와 겹친 경우 -> sub / drop 간 교환
        bool alreadyGetted = false;

        foreach (var col in c)
        {
            if (col.gameObject.tag == "Box" && alreadyGetted == false)
            {
                Weapon temp = col.gameObject.GetComponent<DropBox>().GetWeapon(transform);
                //이미 가지고 있는 무기일 경우 -> 장탄수 회복, 아닌 경우, 서브웨펀과 교환
                if (temp.weapon == Main_Weapon.weapon)
                {
                    Main_Weapon.ResetBullet();
                    Destroy(temp.gameObject);
                }
                else if (Sub_Weapon != null)
                {
                    if (temp.weapon == Sub_Weapon.weapon)
                    {
                        Sub_Weapon.ResetBullet();
                        Destroy(temp.gameObject);
                    }
                    else Sub_Weapon = temp;
                }
                else Sub_Weapon = temp;

                alreadyGetted = true;
                if (Sub_Weapon.weapon != Weapons.JERRYCAN)
                {
                    SoundManager.Instance.PlaySound(2);
                    Destroy(col.gameObject);
                }
                else
                {
                    col.gameObject.SetActive(false);
                    SoundManager.Instance.PlaySound(3);
                }
            }
        }

        //아닌 경우 -> main / sub 간 교환
        if (alreadyGetted == false)
        {
            if (sub_Weapon == null)
                return;
            else if (sub_Weapon.weapon == Weapons.JERRYCAN)
                return;

            SoundManager.Instance.PlaySound(2);

            Weapon temp = Main_Weapon;
            Main_Weapon = Sub_Weapon;
            Sub_Weapon = temp;
        }

        Debug.Log($"Main : {Main_Weapon.name} / Sub : {Sub_Weapon.name}");
    }

    public override void DestroyCall()
        //파괴된(HP 0인) 경우
    {
        SoundManager.Instance.PlaySound(5);
        PlayManager.Instance.GameOver();
    }

    public override void GetDamage(float damage)
    {
        base.GetDamage(damage);
        SoundManager.Instance.PlaySound(4);
    }
}
