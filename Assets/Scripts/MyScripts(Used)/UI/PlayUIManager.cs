using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayUIManager : MonoBehaviour
{
    public static PlayUIManager Instance { get; private set; } = null;

    private void Awake()
    {
        Instance = this;
    }

    public Image sprite_Main;
    public Image bullet_Main;

    public Image sprite_Sub;
    public Image bullet_Sub;

    public Image changeButton;

    public void ChangeWeaponUI_Main(Weapon weapon)
    {
        sprite_Main.sprite = weapon.sprite;
    }
    public void ChangeWeaponUI_Sub()
    {
        sprite_Sub.sprite = null;
        bullet_Sub.fillAmount = 0f;
        changeButton.color = new Color(255f, 255f, 255f, 0.4f);
    }
    public void ChangeWeaponUI_Sub(Weapon weapon, bool isSub)
    {
        sprite_Sub.sprite = weapon.sprite;

        float cur, max;
        cur = weapon.cur_bullet;
        max = weapon.max_bullet;
        float bullet_percentage = 1f - cur / max;
        bullet_Sub.fillAmount = bullet_percentage;

        if (isSub)
            changeButton.color = new Color(255f, 255f, 255f, 0.4f);
        else changeButton.color = new Color(125f, 0f, 0f, 0.4f);


    }
    public void UpdateBullet(Weapon weapon)
    {
        float cur, max;
        cur = weapon.cur_bullet;
        max = weapon.max_bullet;
        float bullet_percentage = 1f - cur / max;
        bullet_Main.fillAmount = bullet_percentage;
    }

    public GameObject gameOverCanvas;

    public void RestartButtonClicked()
    {
        gameOverCanvas.SetActive(false);
        pauseCanavas.SetActive(false);
        Time.timeScale = 1f;

        LevelManager.Instance.RestartCall();
    }

    public void MenuButtonClicked()
    {
        gameOverCanvas.SetActive(false);
        pauseCanavas.SetActive(false);
        Time.timeScale = 1f;

        SceneManager.LoadScene("Intro_Main_JM");
    }

    public GameObject pauseCanavas;

    public void PauseButtonClicekd()
    {
        pauseCanavas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeButtonClicked()
    {
        pauseCanavas.SetActive(false);
        Time.timeScale = 1f;
    }
}
