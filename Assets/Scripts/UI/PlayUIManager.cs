using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayUIManager : MonoBehaviour
    //Play에서 사용되는 UI들을 총괄
{
    public static PlayUIManager Instance { get; private set; } = null;  //싱글톤 선언 및 초기화

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
        //메인웨펀 UI를 변경
    {
        sprite_Main.sprite = weapon.sprite;
    }
    public void ChangeWeaponUI_Sub()
        //서브웨펀 UI를 null로 변경
    {
        sprite_Sub.sprite = null;
        bullet_Sub.fillAmount = 0f;
        changeButton.color = new Color(255f, 255f, 255f, 0.4f);
    }
    public void ChangeWeaponUI_Sub(Weapon weapon, bool isSub)
        //서브웨펀 UI를 변경
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
        //메인웨펀 UI의 잔탄수 UI를 업데이트
    {
        float cur, max;
        cur = weapon.cur_bullet;
        max = weapon.max_bullet;
        float bullet_percentage = 1f - cur / max;
        bullet_Main.fillAmount = bullet_percentage;
    }

    public GameObject gameOverCanvas;

    public void RestartButtonClicked()
        //게임오버, 일시정지에서 재시작을 눌렀을 시, 해당 레벨부터 다시 시작함
    {
        gameOverCanvas.SetActive(false);
        pauseCanavas.SetActive(false);
        Time.timeScale = 1f;

        LevelManager.Instance.RestartCall();
    }

    public void MenuButtonClicked()
        //게임오버, 일시정지에서 메뉴 버튼을 눌렀을 시
    {
        gameOverCanvas.SetActive(false);
        pauseCanavas.SetActive(false);
        Time.timeScale = 1f;

        SceneManager.LoadScene("Intro_Main_JM");
    }

    public GameObject pauseCanavas;

    public void PauseButtonClicekd()
        //일시정지 버튼을 눌렀을 시
    {
        pauseCanavas.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeButtonClicked()
        //재개 버튼을 눌렀을 시
    {
        pauseCanavas.SetActive(false);
        Time.timeScale = 1f;
    }
}
