using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro_1_subtitle : MonoBehaviour
{
    public GameObject subtitle_1;
    public GameObject subtitle_2;
    public GameObject subtitle_3;

    float time = 0;

    // 자막이 계속 생성되지 않도록 스위치로 조절한다.
    bool bSwitch_1 = true;
    bool bSwitch_2 = true;
    bool bSwitch_3 = true;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (bSwitch_1) Make_1();
        else if (time > 3.0f && bSwitch_2) Make_2();
        else if (time > 6.0f && bSwitch_3) Make_3();
    }

    private void Make_1()
    {
        subtitle_1 = Instantiate(subtitle_1);
        bSwitch_1 = false;

    }

    private void Make_2()
    {
        Destroy(subtitle_1);
        subtitle_2 = Instantiate(subtitle_2);
        bSwitch_2 = false;
    }

    private void Make_3()
    {
        Destroy(subtitle_2);
        subtitle_3 = Instantiate(subtitle_3);
        bSwitch_3 = false;
    }
}
