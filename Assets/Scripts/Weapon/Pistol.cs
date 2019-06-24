using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    public override void Init_Weapon()
        //피스톨 초기화
    {
        bullet = PlayManager.Instance.bullet;
        attackSpd = 3f;
        bulletSpd = 10f;
        damage = 1.5f;
        max_bullet = 30f;
        cur_bullet = max_bullet;
        weapon = Weapons.PISTOL;
        sprite = PlayManager.Instance.LoadGunSprite(Weapons.PISTOL);
    }

    public override void Shoot(Vector3 vec)
    {
        base.Shoot(vec);
    }
}
