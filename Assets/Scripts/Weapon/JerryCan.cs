using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerryCan : Weapon
    //연료통, 무기는 아니지만 서브웨펀에 들어가야하므로, Weapon 상속
{
    private void Awake()
    {
        weapon = Weapons.JERRYCAN;
    }

    private void Start()
    {
        Init_Weapon();
    }
    public override void Init_Weapon()
        //초기화
    {
        weapon = Weapons.JERRYCAN;
        max_bullet = 1f;
        cur_bullet = 1f;

        sprite = PlayManager.Instance.LoadGunSprite(Weapons.JERRYCAN);
    }

    
}
