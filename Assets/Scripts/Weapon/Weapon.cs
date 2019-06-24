using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Weapons
{
    PISTOL, RIFLE, JERRYCAN
}

public abstract class Weapon : MonoBehaviour
//모든 무기의 부모 클래스
{
    //모든 무기의 모든 변수들
    public GameObject bullet;
    public Sprite sprite;

    public Weapons weapon;

    public float max_bullet;
    public float cur_bullet;
    public float damage;
    public float attackSpd;     //초당 발사 개수
    public float bulletSpd;

    public float attackCool = 0f;

    public abstract void Init_Weapon();     //무기 초기화 메서드

    public virtual void Shoot(Vector3 vec)
        //발사 명령 시, 호출됨
    {
        if (attackCool > 0f || cur_bullet <= 0f)
            return;     //쿨타임 중이거나 총알이 없으면 리턴

        SetCool();

        SoundManager.Instance.PlaySound(1);

        cur_bullet -= 1f;

        //총알 생성
        GameObject temp = Instantiate(bullet, PlayManager.Instance.GetData().transform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
        temp.GetComponent<Bullet>().Init_Bullet(vec, damage, bulletSpd);
    }
    
    public void ResetBullet()
    {
        cur_bullet = max_bullet;
    }

    public void SetCool()
        //쿨타임 설정
    {
        attackCool = 1f/attackSpd;
    }

    public virtual void Update()
    {
        if (attackCool > 0f)
            attackCool -= Time.deltaTime;
    }
}
