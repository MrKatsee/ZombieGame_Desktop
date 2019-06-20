using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JerryCan : Weapon
{
    private void Start()
    {

        Init_Weapon();
    }
    public override void Init_Weapon()
    {
        weapon = Weapons.JERRYCAN;
        max_bullet = 1f;
        cur_bullet = 1f;

        sprite = PlayManager.Instance.LoadGunSprite(Weapons.JERRYCAN);
    }

    
}
