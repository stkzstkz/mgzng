using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ranking : MonoBehaviour
{
    public string[] num = { " 1. ", " 2. ", " 3. ", " 4. ", " 5. ", " 6. ", " 7. ", " 8. ", " 9. ", "10. " };
    private int[] score = new int[10];
    [SerializeField] private Text rankingText;
    [SerializeField] private TMP_InputField input;
    [SerializeField] private GameObject todestroy;
    // private static string name = "No Name";
    private string[] namelist = new string[10];
    private int Th = -1;
    void Start()
    {
        GetRanking();
        SetRanking(GameScoreStatic.Zng);
        ViewRanking();
    }

    // ランキング呼び出し
    private void GetRanking()
    {
        //ランキング呼び出し
        for (int i = 0; i < num.Length; i++)
        {
            score[i] = PlayerPrefs.GetInt(num[i]);
            namelist[i] = PlayerPrefs.GetString(i.ToString());
        }
    }
    // ランキング書き込み
    private void SetRanking(int _value)
    {
        // 書き込み要素の記憶
        int value4namelist = _value;
        //書き込み
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
        // 書き込み確認 
        if (Th == -1)
        {
            // 書き込まれていない => プレイヤー書き込み欄消去
            Destroy(todestroy);
        }
        else
        {
            // 書き込まれた => 保存
            for (int i = 0; i < num.Length; i++)
            {
                PlayerPrefs.SetInt(num[i], score[i]);
                PlayerPrefs.SetString(i.ToString(), namelist[i]);
            }
        }
    }

    // ランキング表示
    private void ViewRanking()
    {
        for (int i = 0; i < score.Length; i++)
        {
            rankingText.text += num[i];
            if (score[i] != GameScoreStatic.Zng)
            {
                rankingText.text += namelist[i];
            }
            rankingText.text += " ";
            rankingText.text += score[i].ToString();
            rankingText.text += "\n";
        }
    }
}