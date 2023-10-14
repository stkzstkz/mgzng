using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(this.transform.position);
        Debug.Log(player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーがある程度進んだらザンギをDestroy(メモリリーク要調査)
        if (player.transform.position.z - 10f > this.transform.position.z)
        {
            // Debug.Log("DZng");
            Destroy(this.gameObject);
        }
        
    }

    // プレイヤーに当たったらの処理
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}