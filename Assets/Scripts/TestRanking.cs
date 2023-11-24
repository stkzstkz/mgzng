using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;
using TMPro;
using System.Linq;
using System.Text;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Setlist
{
    public string names { get; set; }
    public int scores { get; set; }
}
public class TestRanking : MonoBehaviour
{
    public int rankingLength = 10;
    [SerializeField] private Text rankingText;
    [SerializeField] private TMP_InputField input;
    private List<Setlist> list = new List<Setlist>();
    private List<string[]> csvData = new List<string[]>();
    private string path = @"./unchi.csv";
    private Setlist setlist = new Setlist();
    void Awake()
    {
        if (!File.Exists(path))
        {
            int i = 0;
            using (FileStream fs = File.Create(path)) ;
            while (i < 10)
            {
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    sw.WriteLine("Default,0");
                }
                i++;
            }
        }
    }
    void Start()
    {
        GetRanking();
        // RankingシーンとResultシーンの選り分け
        if (SceneManager.GetActiveScene().name == "Ranking")
        {
            list.Sort((a, b) => (a.scores - b.scores));
            list.Reverse();
            ViewRanking(list.Count);
        }
        else
        {
            SetRanking(GameScoreStatic.Zng);
            ViewRanking(rankingLength);
        }
    }

    // ランキング呼び出し
    private void GetRanking()
    {
        StreamReader sr = new StreamReader(path);
        int i = 0;
        while (!sr.EndOfStream)
        {
            Setlist setlist4get = new Setlist();
            string line = sr.ReadLine();
            csvData.Add(line.Split(','));
            setlist4get.names = csvData[i][0];
            setlist4get.scores = Int32.Parse(csvData[i][1]);
            list.Add(setlist4get);
            i++;
        }
    }
    // ランキング書き込み
    private void SetRanking(int value)
    {
        setlist.names = "Default";
        setlist.scores = value;
        list.Add(setlist);
        list.Sort((a, b) => (a.scores - b.scores));
        list.Reverse();
    }

    // ボタンが押されたときにcsvファイルに出力
    public async void SetCsv()
    {
        using (StreamWriter sw = new StreamWriter(path, true))
        {
            sw.WriteLine(setlist.names + "," + setlist.scores);
        }
    }

    // ランキング表示
    private void ViewRanking(int length)
    {
        rankingText.text = "";
        for (int i = 0; i < length; i++)
        {
            if (i < 9)
            {
                rankingText.text += "  ";
            }
            rankingText.text += i + 1;
            rankingText.text += ". ";
            for (int scorelength = Digit(list[i].scores); scorelength < 3; scorelength++)
            {
                rankingText.text += "  ";
            }
            rankingText.text += list[i].scores;
            rankingText.text += ": ";
            rankingText.text += list[i].names;
            rankingText.text += "\n";
        }
    }

    // テキストボックスからの読み取り
    public void GetInput()
    {
        setlist.names = input.text;
        ViewRanking(rankingLength);
    }
    public int Digit(int num)
    {
        // Mathf.Log10(0)はNegativeInfinityを返すため、別途処理する。
        if (num == 0)
        {
            return 1;
        }
        else
        {
            return (int)Mathf.Log10(num) + 1;
        }
        // return (num == 0) ? 1 : ((int)Mathf.Log10(num) + 1);
    }
}