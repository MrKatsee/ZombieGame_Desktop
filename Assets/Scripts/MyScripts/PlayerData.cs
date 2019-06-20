using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : CharacterData
{
    private Weapon main_Weapon;
    public Weapon Main_Weapon
    {
        get { return main_Weapon; }
        set
        {
            main_Weapon = value;
            PlayUIManager.Instance.ChangeWeaponUI_Main(main_Weapon);
        }
    }
    private Weapon sub_Weapon;
    public Weapon Sub_Weapon
    {
        get { return sub_Weapon; }
        set
        {
            sub_Weapon = value;
            PlayUIManager.Instance.ChangeWeaponUI_Sub(sub_Weapon, true);
        }
    }
    private Weapon drop_Weapon;
    public Weapon Drop_Weapon
    {
        get { return drop_Weapon; }
        set
        {
            drop_Weapon = value;
            if (drop_Weapon != null)
            {
                PlayUIManager.Instance.ChangeWeaponUI_Sub(Drop_Weapon, false);
            }
            else
            {
                PlayUIManager.Instance.ChangeWeaponUI_Sub();

                if (Sub_Weapon == null)
                    return;

                PlayUIManager.Instance.ChangeWeaponUI_Sub(Sub_Weapon, true);
            }
        }
    }

    void Start()
    {
        //기본 무기
        Main_Weapon = new GameObject("Pistol").AddComponent<Pistol>();
        Main_Weapon.transform.parent = gameObject.transform;
        Main_Weapon.Init_Weapon();
        PlayUIManager.Instance.ChangeWeaponUI_Main(Main_Weapon);
    }

    //플레이어 hp ui, 드랍박스 아이템을 체인지 창에 띄워주는 거

    private void Update()
    {
        PlayUIManager.Instance.UpdateBullet(Main_Weapon);
        Collider[] c = Physics.OverlapBox(transform.position, new Vector3(1f, 1f, 1f) * 0.5f);
        bool alreadyGetted = false;

        foreach (var col in c)
        {
            if (col.gameObject.tag == "Box" && alreadyGetted == false)
            {
                Drop_Weapon = col.gameObject.GetComponent<DropBox>().weapon;
                alreadyGetted = true;
            }
        }
        if (alreadyGetted == false)
        {
            Drop_Weapon = null;
        }

    }

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
                //이미 가지고 있는 무기일 경우 -> 장탄수 회복
                if (temp == Sub_Weapon)
                {
                    Sub_Weapon.ResetBullet();
                    Destroy(temp.gameObject);
                }
                else if (temp == Main_Weapon)
                {
                    Main_Weapon.ResetBullet();
                    Destroy(temp.gameObject);
                }
                else Sub_Weapon = temp;
                alreadyGetted = true;
                Destroy(col.gameObject);
            }
        }

        //아닌 경우 -> main / sub 간 교환
        if (alreadyGetted == false)
        {
            if (sub_Weapon == null)
                return;

            Weapon temp = Main_Weapon;
            Main_Weapon = Sub_Weapon;
            Sub_Weapon = temp;
        }

        Debug.Log($"Main : {Main_Weapon.name} / Sub : {Sub_Weapon.name}");
    }
}
