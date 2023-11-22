using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// もっとちゃんと書く，もしくはGamaManagerに統合する
public class ZngCar : MonoBehaviour
{
    [SerializeField] private float leftRightSpeed = 4f;
    [SerializeField] private float limit = 8.6f;
    private bool DirectionR = true;
    private float pos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * GameManager.Instance.GameSpeed, Space.World);
        pos = transform.position.x;
        if (pos <= -limit)
        {
            DirectionR = true;
            transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
        }
        if (pos >= limit)
        {
            DirectionR = false;
            transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
        }
        if (DirectionR)
        {
            transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
        }
    }
}