using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Between_subtitle : MonoBehaviour
{
    public GameObject subtitle_1;
    public GameObject subtitle_2;
    public GameObject subtitle_3;
    public GameObject subtitle_4;
    public GameObject subtitle_5;
    public GameObject subtitle_6;

    float time = 0;
    bool bSwitch_1 = true;
    bool bSwitch_2 = true;
    bool bSwitch_3 = true;
    bool bSwitch_4 = true;
    bool bSwitch_5 = true;
    bool bSwitch_6 = true;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (bSwitch_1) Make_1();
        else if (time > 4.0f && bSwitch_2) Make_2();
        else if (time > 8.0f && bSwitch_3) Make_3();
        else if (time > 12.0f && bSwitch_4) Make_4();
        else if (time > 16.0f && bSwitch_5) Make_5();
        else if (time > 20.0f && bSwitch_6) Make_6();
        else if (time > 22.0f) ChangeSecondScene();

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

    private void Make_4()
    {
        Destroy(subtitle_3);
        subtitle_4 = Instantiate(subtitle_4);
        bSwitch_4 = false;
    }

    private void Make_5()
    {
        Destroy(subtitle_4);
        subtitle_5 = Instantiate(subtitle_5);
        bSwitch_5 = false;
    }

    private void Make_6()
    {
        subtitle_6 = Instantiate(subtitle_6);
        bSwitch_6 = false;
    }




    public void ChangeFirstScene()
    {
        SceneManager.LoadScene("Between_map1_map2_JM");
    }


 

    public void ChangeSecondScene()
    {

        SceneManager.LoadScene("Main");

    }





}
