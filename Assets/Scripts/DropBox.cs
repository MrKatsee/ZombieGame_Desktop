using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBox : MonoBehaviour
    //드랍 박스
{
    public Weapon weapon;
    Sprite[] gunSprite;

    float checker = 0f;

    public void Init_DropBox()
    {
        checker = Random.Range(0f, 1f);

        //드랍 박스 안에 무슨 무기 들었는지 초기화
        if (CheckRandom(0f, 0.5f))
        {
            weapon = new GameObject("Rifle").AddComponent<Rifle>();
            weapon.transform.parent = gameObject.transform.parent;
            weapon.Init_Weapon();
        }
        else if (CheckRandom(0.5f, 1f))
        {
            weapon = new GameObject("Pistol").AddComponent<Pistol>();
            weapon.transform.parent = gameObject.transform.parent;
            weapon.Init_Weapon();
        }

        StartCoroutine(DestroyCount());
    }

    bool CheckRandom(float min, float max)
        //0 ~ 1 Range의 확률 중 범위에 해당하는 지 체크
    {
        return (checker >= min) && (checker < max);
    }

    public Weapon GetWeapon(Transform parent)
        //무기를 반환해줌
    {
        //PlayerData에서 호출
        weapon.transform.parent = parent;

        return weapon;
    }

    IEnumerator DestroyCount()
        //너무 많이 쌓이면 렉 걸려서, 10초 안에 사라지게 함
    {
        yield return new WaitForSeconds(10f);

        DestroyCall();
    }

    void DestroyCall()
    {
        Destroy(gameObject);
    }
}
