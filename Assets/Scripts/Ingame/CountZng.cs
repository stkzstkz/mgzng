using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountZng : MonoBehaviour
{
    public TMPro.TMP_Text NofZng;
    public static CountZng Instance { get; private set; }
    public AudioClip sounnd;
    AudioSource audioSource;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        NofZng.SetText("×{0}", GameScoreStatic.Zng);
        audioSource = GetComponent<AudioSource>();
    }
    // 取ったザンギの数追加
    public void AddZng()
    {
        GameScoreStatic.Zng++;
        NofZng.SetText("×{0}", GameScoreStatic.Zng);
        audioSource.PlayOneShot(sounnd);
    }
}