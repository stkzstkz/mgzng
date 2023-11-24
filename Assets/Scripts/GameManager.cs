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
    public float limit = 8.6f;
    public float jumpForce = 5f;
    public float leftRightSpeed = 8f;
    [HideInInspector] public float AppearPos = 42f;
    public float[] GameSpeed = { 5f, 8f };
    public float[] plusSpeed = { 0.1f, 0.2f };
    [HideInInspector] public Vector3 jump = new Vector3(0.0f, 1.0f, 0.0f);
    [HideInInspector][SerializeField] private GameObject ZngPrefab;
    [HideInInspector][SerializeField] private GameObject OjmPrefab;
    [HideInInspector][SerializeField] private GameObject ZngCar;
    [HideInInspector][SerializeField] private GameObject Stage;
    [HideInInspector][SerializeField] private float PosLevel0 = 582.191682f;
    [HideInInspector][SerializeField] private float PosLevel1 = 420.391682f;
    [SerializeField] private float WidthIntervalZng = 0.5f;
    [SerializeField] private float ChangeRateIntervalZng = 1f;
    [SerializeField] private float MinIntervalZng = 0.05f;
    [SerializeField] private float MaxIntervalZng = 1.5f;
    [SerializeField] private float WidthIntervalOjm = 0.5f;
    [SerializeField] private float ChangeRateIntervalOjm = 1f;
    [SerializeField] private float MinIntervalOjm = 0.5f;
    [SerializeField] private float MaxIntervalOjm = 3f;
    private float CenterIntervalZng;
    private float CenterIntervalOjm;
    private float interval4Zng;
    private float interval4Ojm;
    private float time4Zng = 0f;
    private float time4Ojm = 0f;
    private bool OjmDirectionR = true;
    private float pos;
    private Vector3 ZngPos;
    private Vector3 OjmPos;

    void Awake()
    {
        Instance = this;
        GameScoreStatic.Zng = 0;
        if (GameScoreStatic.Level == 0)
        {
            Instantiate(Stage, new Vector3(-12.42848f, 0.0f, -2.398318f), Quaternion.Euler(0.0f, 0.0f, 0.0f));
        }
        else
        {
            Instantiate(Stage, new Vector3(25.2f, 0.0f, -2.398318f), Quaternion.Euler(0.0f, -82.9f, 0.0f));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        OjmDirectionR = Random.value > 0.5;
        MakeStage();
    }
    // Update is called once per frame
    void Update()
    {
        time4Ojm += Time.deltaTime;
        time4Zng += Time.deltaTime;
        if (time4Zng > interval4Zng)
        {
            CenterIntervalZng = MaxIntervalZng - ChangeRateIntervalZng / GameSpeed[GameScoreStatic.Level];
            if (CenterIntervalZng < MinIntervalZng)
            {
                CenterIntervalZng = MinIntervalZng;
            }
            GameObject Zng = Instantiate(ZngPrefab);
            ZngPos = ZngCar.transform.position;
            ZngPos.y = 2.3f;
            ZngPos.z -= 15f;
            Zng.transform.position = ZngPos;
            interval4Zng = Random.Range(CenterIntervalZng - WidthIntervalZng, CenterIntervalZng + WidthIntervalZng);
            time4Zng = 0f;
            GameSpeed[GameScoreStatic.Level] += plusSpeed[GameScoreStatic.Level];
        }
        if (time4Ojm > interval4Ojm)
        {
            CenterIntervalOjm = MaxIntervalOjm - ChangeRateIntervalOjm / GameSpeed[GameScoreStatic.Level];
            if (CenterIntervalOjm < MinIntervalOjm)
            {
                CenterIntervalOjm = MinIntervalOjm;
            }
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
            interval4Ojm = Random.Range(CenterIntervalOjm - WidthIntervalZng, CenterIntervalOjm + WidthIntervalOjm);
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
    public void MakeStage()
    {
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
}

public static class GameScoreStatic
{
    public static int Zng = 0;
    // Level0 = easy, Level1 = nomal
    public static int Level = 0;
}