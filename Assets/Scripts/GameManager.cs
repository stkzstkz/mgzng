using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject EndPoint1;
    [SerializeField]
    GameObject EndPoint2;
    [SerializeField]
    GameObject PlayerObject;

    void Awake()
    {
        GameScoreStatic.Zng = 0;
    }

    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if (PlayerObject.transform.position.z >= EndPoint1.transform.position.z || PlayerObject.transform.position.x >= EndPoint2.transform.position.x)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Result");
    }
}

public static class GameScoreStatic
{
    public static int Zng = 0;
    public static int Level = 0;
}