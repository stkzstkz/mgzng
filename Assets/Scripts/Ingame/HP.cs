using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    //　ライフゲージプレハブ
    [SerializeField] private GameObject lifeObj;
    public GameManager gm;
    public static HP Instance {get; private set; }
    public int life = 5;
    private void Awake()
    {
        Instance = this;
    }
    public void SetLifeGauge2(int damage) {
        //　最後のライフゲージを削除
        life = life - damage;
        Debug.Log(life);
        if(life <= 0)
        {
            gm.GameOver();
        }else{
            Destroy(transform.GetChild(damage).gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //　体力を一旦全削除
        for (int i = 0; i < transform.childCount; i++) {
            Destroy(transform.GetChild(i).gameObject);
        }
        //　現在の体力数分のライフゲージを作成
        for (int i = 0; i < life; i++) {
            Instantiate<GameObject>(lifeObj, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //　ライフゲージ全削除＆HP分作成(GameManagerから呼ぶ)
    // public void SetLifeGauge(int life) {
    //     //　体力を一旦全削除
    //     for (int i = 0; i < transform.childCount; i++) {
    //         Destroy(transform.GetChild(i).gameObject);
    //     }
    //     //　現在の体力数分のライフゲージを作成
    //     for (int i = 0; i < life; i++) {
    //         Instantiate<GameObject>(lifeObj, transform);
    //     }
    // }
    //　ダメージ分だけ削除(GameManagerから呼ぶ)
    // public void SetLifeGauge2(int damage) {
    //     for (int i = 0; i < damage; i++) {
    //         //　最後のライフゲージを削除
    //         Destroy(transform.GetChild(i).gameObject);
    //     }
    // }

}
