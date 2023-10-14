using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private float moveSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(this.transform.position);
        Debug.Log(player.transform.position);
        if(this.transform.position.x > 0) {
            moveSpeed = 2f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        Debug.Log(this.transform.position);
        Debug.Log(player.transform.position);
        // プレイヤーがある程度進んだらザンギをDestroy(メモリリーク要調査)
        if (player.transform.position.z - 10f > this.transform.position.z)
        {
            Debug.Log("DOjm");
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
