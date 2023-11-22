using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controll : MonoBehaviour
{
    [SerializeField] private float leftRightSpeed = 8f;
    [SerializeField] private float limit = 8f;
    [SerializeField] private Vector3 jump;
    [SerializeField] private float jumpForce = 5.0f;
    [SerializeField] private InputAction Jump;
    // [SerializeField] private Vector3 player = new Vector3(-237f, 1.81f, 29f);
    private bool isGrounded;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        // if (GameScoreStatic.Level != 0)
        // {
        //     transform.position = player;
        // }
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 1.0f, 0.0f);
    }

    private void OnCollisionStay()
    {
        isGrounded = true;
    }

    private void OnCollisionExit()
    {
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * GameManager.Instance.GameSpeed, Space.World);
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (transform.position.x > -limit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * GameManager.Instance.GameSpeed*2);
            }
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.x < limit)
            {
                transform.Translate(Vector3.right * Time.deltaTime * GameManager.Instance.GameSpeed*2);
            }
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
}