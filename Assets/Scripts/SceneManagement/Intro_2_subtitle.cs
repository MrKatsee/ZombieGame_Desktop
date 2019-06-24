using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro_2_subtitle : MonoBehaviour
{
    public GameObject subtitle_1;
    public GameObject subtitle_2;
    public GameObject subtitle_3;
    public GameObject subtitle_4;
    public GameObject subtitle_5;

    float time = 0;
    bool bSwitch_1 = true;
    bool bSwitch_2 = true;
    bool bSwitch_3 = true;
    bool bSwitch_4 = true;
    bool bSwitch_5 = true;

 

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (bSwitch_1) Make_1();
        else if (time > 3.0f && bSwitch_2) Make_2();
        else if (time > 6.0f && bSwitch_3) Make_3();
        else if (time > 9.0f && bSwitch_4) Make_4();
        else if (time > 12.0f && bSwitch_5) Make_5();
        else if (time > 14.0f) ChangeSecondScene();
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
        subtitle_5 = Instantiate(subtitle_5);
        bSwitch_5 = false;
    }



    
    public void ChangeFirstScene()
    {
        SceneManager.LoadScene("Intro_2_JM");
    }


    // 다음 넘어갈 씬을 넣으시면 됩니다!!!!

    public void ChangeSecondScene()
    {
        SceneManager.LoadScene("Main");
    }
}
