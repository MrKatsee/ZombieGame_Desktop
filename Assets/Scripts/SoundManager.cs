using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //사운드를 총괄하는 싱글톤
    public static SoundManager Instance { get; private set; } = null;
    private void Awake()
    {
        Instance = this;
    }

    public SoundAsset[] sounds;

    //그르릉 소리가 겹치면 시끄러우니까 제한을 두기 위한 변수들
    float groanCool;
    int groanCount;
    int maxCount;

    private void Start()
    {
        maxCount = 5;
        groanCount = 0;
        groanCool = 0f;
    }

    private void Update()
    {
        if (groanCount > 0)
        {
            groanCool += Time.deltaTime;
        }
        if (groanCool >= 5f)
        {
            groanCount--;
            groanCool = 0f;
        }
    }

    public void PlaySound(int index)
        //해당하는 사운드를 플레이한다.
    {
        if (index >= 8)     //8 이상부턴 groan variable이다
        {
            if (groanCount < maxCount)
            {
                //겹쳐서 소리를 내기 위하여, 게임 오브젝트를 생성하는 식으로 소리를 낸다.
                SoundAsset sound = Instantiate(sounds[index].gameObject).GetComponent<SoundAsset>();
                sound.Init_SoundAsset();
                groanCount++;
            }
        }
        else
        {
            SoundAsset sound = Instantiate(sounds[index].gameObject).GetComponent<SoundAsset>();
            sound.Init_SoundAsset();
        }

    }
}
