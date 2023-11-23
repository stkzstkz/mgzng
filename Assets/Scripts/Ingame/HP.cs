using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP : MonoBehaviour
{
    //　ライフゲージプレハブ
    [SerializeField] private GameObject lifeObj;
    public GameManager gm;
    public static HP Instance { get; private set; }
    public int life = 5;
    public AudioClip sounnd;
    AudioSource audioSource;
    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //　体力を一旦全削除
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        //　現在の体力数分のライフゲージを作成
        for (int i = 0; i < life; i++)
        {
            Instantiate<GameObject>(lifeObj, transform);
        }
    }
    
    public void SetLifeGauge2(int damage)
    {
        //ライフゲージを削除
        life = life - damage;
        if (life <= 0)
        {
            gm.GameOver();
        }
        else
        {
            audioSource.PlayOneShot(sounnd);
            Destroy(transform.GetChild(damage).gameObject);
        }
    }
}
