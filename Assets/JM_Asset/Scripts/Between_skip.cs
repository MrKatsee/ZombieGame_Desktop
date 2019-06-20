using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Between_skip : MonoBehaviour
{

    public void ChangeFirstScene()
    {
        SceneManager.LoadScene("Between_map1_map2_JM");
    }

    public void ChangeSecondScene()
    {

        SceneManager.LoadScene("Main");
    }


}
