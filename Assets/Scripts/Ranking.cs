using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    public static Ranking Instance { get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    string[] num = { " 1. ", " 2. ", " 3. ", " 4. ", " 5. ", " 6. ", " 7. ", " 8. ", " 9. ", "10. "};
    int[] score = new int[10];
    [SerializeField] private Text rankingText;
    string sscore;

    void Start()
    {
        GetRanking();
        SetRanking(GameScoreStatic.Zng);

        for (int i = 0; i < score.Length; i++)
        {
            rankingText.text += num[i];
            rankingText.text += score[i].ToString();
            rankingText.text += "\n";
        }
    }

    /// <summary>
    /// ランキング呼び出し
    /// </summary>
    void GetRanking()
    {
        //ランキング呼び出し
        for (int i = 0; i < num.Length; i++)
        {
            score[i] = PlayerPrefs.GetInt(num[i]);
        }
    }
    /// <summary>
    /// ランキング書き込み
    /// </summary>
    void SetRanking(int _value)
    {
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

        //入れ替えた値を保存
        for (int i = 0; i < num.Length; i++)
        {
            PlayerPrefs.SetInt(num[i], score[i]);
        }
    }
}