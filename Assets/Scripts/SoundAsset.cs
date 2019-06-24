using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAsset : MonoBehaviour
    //사운드 에셋에 붙어있는 스크립트
{
    AudioSource audioSource;

    public void Init_SoundAsset()
        //초기화한다.
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();

        StartCoroutine(Destroy_Sound());
    }

    IEnumerator Destroy_Sound()
        //플레이가 끝나면 파괴한다.
    {
        yield return new WaitUntil(() => !audioSource.isPlaying);

        Destroy(gameObject);
    }
}
