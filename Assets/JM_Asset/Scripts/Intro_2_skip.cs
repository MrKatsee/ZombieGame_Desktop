using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro_2_skip : MonoBehaviour
{
    public void ChangeFirstScene()
    {
        SceneManager.LoadScene("Intro_1_JM");
    }

    public void ChangeSecondScene()
    {

        SceneManager.LoadScene("Intro_2_JM");
    }
}
