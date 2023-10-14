using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private float time = 0f;
    [SerializeField] private float interval = 30f;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = Random.Range(1.59f,2.41f);
        if(this.transform.position.x < 0) {
            moveSpeed = -1*moveSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        time += Time.deltaTime;
        if (time > interval){
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HP.Instance.SetLifeGauge2(1);
            Destroy(this.gameObject);
        }
    }
}