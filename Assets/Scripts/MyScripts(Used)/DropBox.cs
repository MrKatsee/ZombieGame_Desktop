using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBox : MonoBehaviour
{
    public Weapon weapon;
    Sprite[] gunSprite;

    public void Init_DropBox()
    {
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
    {
        float checker = Random.Range(0f, 1f);
        return (checker >= min) && (checker < max);
    }

    public Weapon GetWeapon(Transform parent)
    {
        //PlayerData에서 호출
        weapon.transform.parent = parent;

        return weapon;
    }

    IEnumerator DestroyCount()
    {
        yield return new WaitForSeconds(10f);

        DestroyCall();
    }

    void DestroyCall()
    {
        Destroy(gameObject);
    }
}
