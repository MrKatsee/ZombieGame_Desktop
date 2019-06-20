using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour
{
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
    {
        return player.GetComponent<PlayerControl>();
    }

    public PlayerData GetData()
    {
        return player.GetComponent<PlayerData>();
    }
    public GameObject GetStage2_Object()
    {
        return stage2_Object;
    }
    public GameObject GetTheObject()
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
    {
        DropBox dB = Instantiate(dropBox, pos, Quaternion.identity).GetComponent<DropBox>();
        dB.Init_DropBox();
    }
    public void InstantiateDropBox(Vector3 pos, float percent)
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
    {
        gameOverCanvas.SetActive(true);
    }
}
