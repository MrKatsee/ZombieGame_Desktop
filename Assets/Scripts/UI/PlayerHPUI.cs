using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPUI : MonoBehaviour
    //플레이어 HP UI를 지속적으로 업데이트 해줌
{
    public PlayerData pData;
    public Image hpBar;

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);
        hpBar.fillAmount = pData.HP / pData.maxHP;
    }
}
