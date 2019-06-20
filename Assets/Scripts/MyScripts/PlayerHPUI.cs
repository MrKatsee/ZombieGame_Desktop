using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPUI : MonoBehaviour
{
    public PlayerData pData;
    public Image hpBar;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);
        hpBar.fillAmount = pData.HP / pData.maxHP;
    }
}
