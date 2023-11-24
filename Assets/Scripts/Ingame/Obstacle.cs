using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float moveSpeed;
    private float MinSpeed;
    private float MaxSpeed;
    private float CenterSpeed;
    private float time = 0f;
    [SerializeField] private float interval = 50f;
    private float RealInterval;
    // Start is called before the first frame update
    void Start()
    {
        CenterSpeed = GameManager.Instance.GameSpeed[GameScoreStatic.Level];
        MinSpeed = CenterSpeed * (1 - GameManager.Instance.limit / GameManager.Instance.AppearPos);
        MaxSpeed = CenterSpeed * (1 + GameManager.Instance.limit / GameManager.Instance.AppearPos);
        // 速度をランダムにすることで当たる場所を変更
        // moveSpeed = Random.Range(4.374f, 6.626f); in movespeed 2
        moveSpeed = -1 * Random.Range(MinSpeed, MaxSpeed);
        if (this.transform.position.x > 0)
        {
            transform.rotation = Quaternion.Euler(0.0f, 180f, 0.0f);
        }
        RealInterval = interval / CenterSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        // プレイヤーがある程度進んだらお邪魔電通大生をDestroy(メモリリーク要調査)
        time += Time.deltaTime;
        if (time > RealInterval)
        {
            Destroy(this.gameObject);
        }
    }

    // プレイヤーに当たったらHPを減らす処理
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HP.Instance.SetLifeGauge2(1);
            Destroy(this.gameObject);
        }
    }
}