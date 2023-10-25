using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ranking : MonoBehaviour
{
    private string[] num = { " 1. ", " 2. ", " 3. ", " 4. ", " 5. ", " 6. ", " 7. ", " 8. ", " 9. ", "10. " };
    private int[] score = new int[10];
    [SerializeField] private Text rankingText;
    [SerializeField] private TMP_InputField input;
    private static string name = "No Name";
    private string[] namelist = new string[10];
    private int Th = -1;
    void Start()
    {
        GetRanking();
        SetRanking(GameScoreStatic.Zng);

        for (int i = 0; i < score.Length; i++)
        {
            rankingText.text += num[i];
            if (score[i] == GameScoreStatic.Zng)
            {
                rankingText.text += "";
            }
            else
            {
                rankingText.text += namelist[i];
            }
            rankingText.text += score[i].ToString();
            rankingText.text += "\n";
        }
    }

    /// <summary>
    /// ランキング呼び出し
    /// </summary>
    private void GetRanking()
    {
        //ランキング呼び出し
        for (int i = 0; i < num.Length; i++)
        {
            score[i] = PlayerPrefs.GetInt(num[i]);
            namelist[i] = PlayerPrefs.GetString(i.ToString());
        }
    }
    /// <summary>
    /// ランキング書き込み
    /// </summary>
    private void SetRanking(int _value)
    {
        int value4namelist = _value;
        //書き込み用
        for (int i = 0; i < num.Length; i++)
        {
            //取得した値とRankingの値を比較して入れ替え
            if (_value > score[i])
            {
                var change = score[i];
                score[i] = _value;
                _value = change;
            }
        }
        Th = Array.IndexOf(score, value4namelist);
        if (Th == -1)
        {
            Destroy(input);
        }
        else
        {
            //入れ替えた値を保存
            for (int i = 0; i < num.Length; i++)
            {
                PlayerPrefs.SetInt(num[i], score[i]);
                PlayerPrefs.SetString(i.ToString(), namelist[i]);
            }
        }
    }

    public void InputName()
    {
        namelist[Th] = input.text;
        PlayerPrefs.SetString(Th.ToString(), namelist[Th]);
        rankingText.text = "";
        for (int i = 0; i < score.Length; i++)
        {
            rankingText.text += num[i];
            rankingText.text += namelist[i];
            rankingText.text += score[i].ToString();
            rankingText.text += "\n";
        }
    }
}