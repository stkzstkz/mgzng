using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TmpCameraMovement : MonoBehaviour
{
    [SerializeField]
    Vector3 moveVector;
    [SerializeField]
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += moveVector * speed * Time.deltaTime;
        }
    }
}
