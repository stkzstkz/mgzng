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
    private string path = @"Assets/unchi.csv";
    private Setlist setlist = new Setlist();
    void Start()
    {
        GetRanking();
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
            rankingText.text += i+1;
            rankingText.text += ". ";
            rankingText.text += list[i].names;
            rankingText.text += list[i].scores;
            rankingText.text += " ";
            rankingText.text += "\n";
        }
    }

    // テキストボックスからの読み取り
    public void GetInput()
    {
        setlist.names = input.text;
        ViewRanking(rankingLength);
    }
}