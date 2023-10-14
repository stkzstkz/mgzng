using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    //　ライフゲージプレハブ
    [SerializeField]
    private GameObject lifeObj;
 
    //　ライフゲージ全削除＆HP分作成(GameManagerから呼ぶ)
    public void SetLifeGauge(int life) {
        //　体力を一旦全削除
        for (int i = 0; i < transform.childCount; i++) {
            Destroy(transform.GetChild(i).gameObject);
        }
        //　現在の体力数分のライフゲージを作成
        for (int i = 0; i < life; i++) {
            Instantiate<GameObject>(lifeObj, transform);
        }
    }
    //　ダメージ分だけ削除(GameManagerから呼ぶ)
    public void SetLifeGauge2(int damage) {
        for (int i = 0; i < damage; i++) {
            //　最後のライフゲージを削除
            Destroy(transform.GetChild(i).gameObject);
            //Destroy(transform.GetChild(transform.childCount - 1 - i).gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
