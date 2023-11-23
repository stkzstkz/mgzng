using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using Random = UnityEngine.Random;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public float limit = 8f;
    public float jumpForce = 5f;
    public float leftRightSpeed = 8f;
    public float AppearPos = 42f;
    public float[] GameSpeed = { 2f, 4f };
    public float[] plusSpeed = { 0.1f, 0.1f };
    public Vector3 jump = new Vector3(0.0f, 1.0f, 0.0f);
    [SerializeField] private GameObject ZngPrefab;
    [SerializeField] private GameObject OjmPrefab;
    [SerializeField] private GameObject ZngCar;
    [SerializeField] private GameObject Stage;
    [SerializeField] private float PosLevel0 = 582.191682f;
    [SerializeField] private float PosLevel1 = 420.391682f;
    [SerializeField] private float MinIntervalZng = 1f;
    [SerializeField] private float MaxIntervalZng = 2f;
    [SerializeField] private float MinIntervalOjm = 3f;
    [SerializeField] private float MaxIntervalOjm = 5.5f;
    private float interval4Zng;
    private float interval4Ojm;
    private float time4Zng = 0f;
    private float time4Ojm = 0f;
    private bool DirectionR = true;
    private bool OjmDirectionR = true;
    private float pos;
    private Vector3 ZngPos;
    private Vector3 OjmPos;
    private bool creatingLevel = false;
    void Awake()
    {
        Instance = this;
        GameScoreStatic.Zng = 0;
        if (GameScoreStatic.Level == 0)
        {
            // Debug.Log("0");
            // FirstStage.transform.position = new Vector3(-12.42848f, 0.0f, -2.398318f);
            // FirstStage.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            Instantiate(Stage, new Vector3(-12.42848f, 0.0f, -2.398318f), Quaternion.Euler(0.0f, 0.0f, 0.0f));
        }
        else
        {
            // Debug.Log("1");
            // FirstStage.transform.position = new Vector3(25.2f, 0.0f, -2.398318f);
            // FirstStage.transform.rotation = Quaternion.Euler(0.0f, -82.9f, 0.0f);
            Instantiate(Stage, new Vector3(25.2f, 0.0f, -2.398318f), Quaternion.Euler(0.0f, -82.9f, 0.0f));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        OjmDirectionR = Random.value > 0.5;
        MakeStage();
        Debug.Log(GameScoreStatic.Level);
    }
    // Update is called once per frame
    void Update()
    {
        // if (!creatingLevel)
        // {
        //     creatingLevel = true;
        //     StartCoroutine(GenerateLvl());
        // }
        time4Ojm += Time.deltaTime;
        time4Zng += Time.deltaTime;
        if (time4Zng > interval4Zng)
        {
            GameObject Zng = Instantiate(ZngPrefab);
            ZngPos = ZngCar.transform.position;
            ZngPos.y = 2.3f;
            ZngPos.z -= 15f;
            Zng.transform.position = ZngPos;
            interval4Zng = Random.Range(MinIntervalZng, MaxIntervalZng);
            time4Zng = 0f;
            GameSpeed[GameScoreStatic.Level] += plusSpeed[GameScoreStatic.Level];
        }
        if (time4Ojm > interval4Ojm)
        {
            GameObject Ojm = Instantiate(OjmPrefab);
            OjmPos = ZngCar.transform.position;
            OjmPos.y = 1.37f;
            OjmDirectionR = Random.value > 0.5;
            if (OjmDirectionR)
            {
                OjmPos.x = AppearPos;
            }
            else
            {
                OjmPos.x = -1 * AppearPos;
            }
            Ojm.transform.position = OjmPos;
            interval4Ojm = Random.Range(MinIntervalOjm, MaxIntervalOjm);
            time4Ojm = 0f;
            GameSpeed[GameScoreStatic.Level] += 0.1f;
        }
        if (Keyboard.current.escapeKey.isPressed)
        {
            Application.Quit();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Result");
    }
    public void MakeStage(){
        if (GameScoreStatic.Level == 0)
        {
            Instantiate(Stage, new Vector3(-12.42848f, 0.0f, PosLevel0), Quaternion.Euler(0.0f, 0.0f, 0.0f));
            PosLevel0 += 582.191682f;
        }
        else
        {
            Instantiate(Stage, new Vector3(25.2f, 0.0f, PosLevel1), Quaternion.Euler(0.0f, -82.9f, 0.0f));
            PosLevel1 += 420.391682f;
        }
    }
    // IEnumerator GenerateLvl()
    // {
    //     if (GameScoreStatic.Level == 0)
    //     {
    //         Instantiate(Stage, new Vector3(-12.42848f, 0.0f, PosLevel0), Quaternion.Euler(0.0f, 0.0f, 0.0f));
    //         PosLevel0 += 582.191682f;
    //         yield return new WaitForSeconds(20);
    //     }
    //     else
    //     {
    //         Instantiate(Stage, new Vector3(25.2f, 0.0f, PosLevel1), Quaternion.Euler(0.0f, -82.9f, 0.0f));
    //         PosLevel1 += 420.391682f;
    //         yield return new WaitForSeconds(20);
    //     }
    //     creatingLevel = false;
    // }
}

public static class GameScoreStatic
{
    public static int Zng = 0;
    // Level0 = easy, Level1 = nomal
    public static int Level = 0;
}