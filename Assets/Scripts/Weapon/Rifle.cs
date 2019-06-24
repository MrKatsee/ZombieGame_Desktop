using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Weapon
{
    public override void Init_Weapon()
        //라이플 초기화
    {
        bullet = PlayManager.Instance.bullet;

        weapon = Weapons.RIFLE;

        attackSpd = 10f;
        bulletSpd = 20f;
        damage = 1f;
        max_bullet = 100f;
        cur_bullet = max_bullet;
        sprite = PlayManager.Instance.LoadGunSprite(Weapons.RIFLE);
    }

    public override void Shoot(Vector3 vec)
    {
        base.Shoot(vec);

    }
}
