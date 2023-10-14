using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountZng : MonoBehaviour
{
    public TMPro.TMP_Text NofZng;
    public static CountZng Instance {get; private set; }
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        NofZng.SetText("× {0}",GameScoreStatic.Zng);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddZng()
    {
        GameScoreStatic.Zng++;
        NofZng.SetText("× {0}",GameScoreStatic.Zng);
    }
}
