using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
    //플레이 매니저 싱글톤

    public static PlayManager Instance { get; private set; } = null;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        //GameObject.Find("DropBox").GetComponent<DropBox>().Init_DropBox();
    }

    public GameObject player;
    public GameObject dropBox;
    public GameObject theObject;
    public GameObject bullet;
    public GameObject stage2_Object;

    public PlayerControl GetControl()
        //플레이어 컨트롤 반환
    {
        return player.GetComponent<PlayerControl>();
    }

    public PlayerData GetData()
        //플레이어 데이터 반환
    {
        return player.GetComponent<PlayerData>();
    }
    public GameObject GetStage2_Object()
        //스테이지 2의 오브젝트 반환...
    {
        return stage2_Object;
    }
    public GameObject GetTheObject()
        //레벨 별 오브젝트(지켜야 할 것) 반환...
    {
        if (LevelManager.level == 1)
            return theObject;
        else if (LevelManager.level == 2)
            return player;
        return player;
    }

    public GameObject systemMessageCanvas;
    public GameObject GetSystemMessageCanvas()
    {
        return systemMessageCanvas;
    }

    public void InstantiateDropBox(Vector3 pos)
        //위치에 드랍박스 생성
    {
        DropBox dB = Instantiate(dropBox, pos, Quaternion.identity).GetComponent<DropBox>();
        dB.Init_DropBox();
    }
    public void InstantiateDropBox(Vector3 pos, float percent)
        //몇 퍼센트 확률로 드랍박스 생성
    {
        float randomPercent = Random.Range(0f, 1f);
        if (randomPercent > percent)
        {
            DropBox dB = Instantiate(dropBox, pos, Quaternion.identity).GetComponent<DropBox>();
            dB.Init_DropBox();
        }
    }

    public Sprite[] gunSprites;

    public Sprite LoadGunSprite(Weapons weapon)
        //weapon 식별자에 해당하는 스프라이트를 반환
    {
        switch (weapon)
        {
            case Weapons.PISTOL:
                return gunSprites[0];
            case Weapons.RIFLE:
                return gunSprites[1];
            case Weapons.JERRYCAN:
                return gunSprites[2];
        }

        throw new System.Exception("Invalid Weapon!");
    }

    public GameObject gameOverCanvas;

    public void GameOver()
        //게임오버
    {
        gameOverCanvas.SetActive(true);
    }
}
