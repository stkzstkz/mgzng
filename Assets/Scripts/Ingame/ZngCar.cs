using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZngCar : MonoBehaviour
{
    [SerializeField] private GameObject ZngPrefab;
    [SerializeField] private GameObject OjmPrefab;
    [SerializeField] private float interval4Zng;
    [SerializeField] private float interval4Ojm;
    private float time4Zng = 0f;
    private float time4Ojm = 0f;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float leftRightSpeed = 4f;
    [SerializeField] private float limit = 8.6f;
    private bool DirectionR = true;
    private bool OjmDirectionR = true;
    [SerializeField] private float x = 42f;

    // Start is called before the first frame update
    void Start()
    {
        interval4Ojm = Random.Range(5f,10f);
        interval4Zng = Random.Range(5f,10f);
        OjmDirectionR = Random.value > 0.5;
    }

    // Update is called once per frame
    void Update()
    {
        time4Ojm += Time.deltaTime;
        time4Zng += Time.deltaTime;
        if (time4Zng > interval4Zng)
        {
            GameObject Zng = Instantiate(ZngPrefab);
            Vector3 ZngPos = this.transform.position;
            ZngPos.y = 2.3f;
            ZngPos.z -= 15f;
            Zng.transform.position = ZngPos;
            interval4Zng = Random.Range(5f,10f);
            time4Zng = 0f;
        }
        if (time4Ojm > interval4Ojm) 
        {
            GameObject Ojm = Instantiate(OjmPrefab);
            Vector3 OjmPos = this.transform.position;
            OjmPos.y = 1.37f;
            OjmDirectionR = Random.value > 0.5;
            if (OjmDirectionR)
            {
                OjmPos.x = x;
            }else{
                OjmPos.x = -1*x;
            }
            Ojm.transform.position = OjmPos;
            interval4Ojm = Random.Range(5f,10f);
            time4Ojm = 0f;
        }
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);
        if (transform.position.x <= -limit)
        {
            DirectionR = true;
        }
        if (transform.position.x >= limit)
        {
            DirectionR = false;
        }
        if(DirectionR)
        {
            transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
        }else{
            transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
        }
    }
}