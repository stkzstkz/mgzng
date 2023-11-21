using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private float time = 0f;
    [SerializeField] private float interval = 30f;

    // Update is called once per frame
    void Update()
    {
        // プレイヤーがある程度進んだらザンギをDestroy(メモリリーク要調査)
        time += Time.deltaTime;
        if (time > interval)
        {
            Destroy(this.gameObject);
        }
    }

    // プレイヤーに当たったらの処理
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            // 取ったザンギの数追加
            CountZng.Instance.AddZng();
        }
    }
}