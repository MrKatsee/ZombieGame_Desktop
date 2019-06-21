using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAsset : MonoBehaviour
{
    AudioSource audioSource;

    public void Init_SoundAsset()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();

        StartCoroutine(Destroy_Sound());
    }

    IEnumerator Destroy_Sound()
    {
        yield return new WaitUntil(() => !audioSource.isPlaying);

        Destroy(gameObject);
    }
}
