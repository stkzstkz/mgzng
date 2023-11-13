using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;
using TMPro;
// using rankinglist;

// namespace rankinglist
// {
//     public class Setlist
//     {
//         public string name;
//         public string score;
//         public Setlist(string name, string score)
//         {
//             this.name = name;
//             this.score = score;
//         }
//     }
// }
public class TestRanking : MonoBehaviour
{
    // System.Collections.Generic.List<rankinglist.Setlist> list = new List<Setlist>();
    // var ranking = new List<(string name, int score)>();
    public string[] num = { " 1. ", " 2. ", " 3. ", " 4. ", " 5. ", " 6. ", " 7. ", " 8. ", " 9. ", "10. " };
    private int[] score = new int[10];
    [SerializeField] private Text rankingText;
    [SerializeField] private TMP_InputField input;
    [SerializeField] private GameObject todestroy;
    // private static string name = "No Name";
    private string[] namelist = new string[10];
    private int Th = -1;
    private TextAsset csvFile;
    private List<string[]> csvData = new List<string[]>();
    private string path = @"Assets/ranking.csv";
    private int rank;
    void Start()
    {
        GetRanking();
        SetRanking(GameScoreStatic.Zng);
        ViewRanking();
    }

    // private void Compare(string a[][], string [][]){
    //     return a[][];
    // }
    // ランキング呼び出し
    private void GetRanking()
    {
        // csvFile = Resources.Load("ranking") as TextAsset;
        // StreamReader sr = new StreamReader(@"E:", Encoding.GetEncoding("Shift_JIS"));
        // StringReader reader = new StrngReader(csvFile.text);
        // while (reader.Peek() != -1)
        // {
        //     string line = reader.ReadLine(); // 1行ずつ読み込む
        //     csvData.Add(line.Split(',')); // csvDataリストに追加する
        // }
        // var c = new Comparision<string[]>(Compare);
        // csvData.Sort(c);
        StreamReader sr = new StreamReader(path);
        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();
            csvData.Add(line.Split(','));
        }
        //ランキング呼び出し
        for (int i = 0; i < csvData.Count; i++) // csvDataリストの条件を満たす値の数（全て）
        {
            // データの表示
            Debug.Log("日本語：" + csvData[i][0] + ", English：" + csvData[i][1]);
        }
        for (int i = 0; i < csvData.Count; i++)
        {
            score[i] = int.Parse(csvData[i][1]);
            namelist[i] = csvData[i][0];
        }
        
    }
    // ランキング書き込み
    private void SetRanking(int _value)
    {
        // 書き込み要素の記憶
        int value4namelist = _value;
        // 書き込み
        for (int i = 0; i < csvData.Count; i++)
        {
            //取得した値とRankingの値を比較して入れ替え
            if (_value > score[i])
            {
                var change = score[i];
                score[i] = _value;
                _value = change;
                rank = i;
                namelist[rank] = "Default";
                Debug.Log(rank);
            }
        }
    }


    // ランキング表示
    private void ViewRanking()
    {
        rankingText.text = "";
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

    // テキストボックスからの読み取り
    public void GetInput()
    {
        namelist[rank] = input.text;
        ViewRanking();
    }
}