using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
    //총알에 붙여진 스크립트
{
    float damage;
    float spd;

    Vector3 vec;

    public void Init_Bullet(Vector3 _vec, float _damage, float _spd)
        //총알을 초기화한다.
    {
        vec = _vec.normalized;
        damage = _damage;
        //spd = _spd;

        //StartCoroutine(Move());
        transform.rotation = Quaternion.LookRotation(vec, Vector3.up);
        transform.position = transform.position + new Vector3(0f, 0.3f, 0f);
        StartCoroutine(DestroyBullet());
    }

    IEnumerator DestroyBullet()
        //5초 후에 총알을 파괴
    {
        float timer = 0f;

        while (true)
        {
            if (timer >= 5f)
            {
                break;
            }

            timer += MyTime.deltaTime;
            yield return null;
        }

        DestroyCall();
    }
    /*
    IEnumerator Move()
    {
        float timer = 0f;

        while(true)
        {
            if(timer >= 5f)
            {
                break;
            }

            transform.Translate(vec * spd * MyTime.deltaTime);

            timer += MyTime.deltaTime;
            yield return null;
        }

        DestroyCall();
    }
    */
    public void DestroyCall()
    {
        StopAllCoroutines();
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider c)
        //적에게 데미지를 줌
    {
        if (c.tag == "Enemy")
        {
            c.GetComponent<Monster>().GetDamage(damage);
            DestroyCall();
        }
    }
}
