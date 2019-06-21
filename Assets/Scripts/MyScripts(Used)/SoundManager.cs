using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; } = null;
    private void Awake()
    {
        Instance = this;
    }

    public SoundAsset[] sounds;

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
    {
        if (index >= 8)
        {
            if (groanCount < maxCount)
            {
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
