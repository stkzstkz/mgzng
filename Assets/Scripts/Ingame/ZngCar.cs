using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// もっとちゃんと書く，もしくはGamaManagerに統合する
public class ZngCar : MonoBehaviour
{
    public GameManager gm;
    [SerializeField] private float leftRightSpeed;
    [SerializeField] private float limit;
    private bool DirectionR = true;
    private float pos;

    // Start is called before the first frame update
    void Start()
    {
        leftRightSpeed = gm.leftRightSpeed;
        limit = gm.limit;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * GameManager.Instance.GameSpeed[GameScoreStatic.Level], Space.World);
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