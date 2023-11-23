using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip[] clips;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // 曲の変更
        audioSource.clip = clips[GameScoreStatic.Level];
        // 再生
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
