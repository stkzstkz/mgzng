using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class ToScene : MonoBehaviour
{
    Scene scene;
    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.isPressed)
        {
            Application.Quit();
        }
        if (scene.name == "Ranking" && Keyboard.current.anyKey.isPressed)
        {
            ToTitle();
        }
    }
    public void ToIngame(int level)
    {
        GameScoreStatic.Level = level;
        SceneManager.LoadScene("Ingame");
    }
    public void ToGameOver()
    {
        SceneManager.LoadScene("Result");
    }
    public void ToTitle()
    {
        SceneManager.LoadScene("Title");
    }
    public void ToRanking()
    {
        SceneManager.LoadScene("Ranking");
    }
}
