using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject EndPoint;
    [SerializeField]
    GameObject PlayerObject;

    void Awake() {
        GameScoreStatic.Zng=0;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        if(PlayerObject.transform.position.z >= EndPoint.transform.position.z)
        {
            GameOver();
        }
    }

    public void GameOver(){
        SceneManager.LoadScene("Result");
    }
}
