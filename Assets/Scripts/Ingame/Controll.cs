using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Controll : MonoBehaviour
{
    public GameManager gm;
    private float leftRightSpeed;
    private float limit;
    private Vector3 jump;
    private float jumpForce;
    public bool isGrounded;
    // [SerializeField] private PauseCanvas;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        leftRightSpeed = gm.leftRightSpeed;
        limit = gm.limit;
        jump = gm.jump;
        jumpForce = gm.jumpForce;
        rb = GetComponent<Rigidbody>();
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
        transform.Translate(Vector3.forward * Time.deltaTime * gm.GameSpeed[GameScoreStatic.Level], Space.World);
        if (Gamepad.current == null && Keyboard.current == null)
        {
            gm.GameSpeed[GameScoreStatic.Level] = 0;
            Time.timeScale = 0;
            return;
        }
        else if (Gamepad.current == null)
        {
            ForKeyBoard();
        }
        else if (Keyboard.current == null)
        {
            ForGamePad();
        }
        else
        {
            ForBoth();
        }
    }
    private void ForKeyBoard()
    {
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
        {
            if (transform.position.x > -limit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            }
        }
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
        {
            if (transform.position.x < limit)
            {
                transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
            }
        }
        if (Keyboard.current.spaceKey.isPressed && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void ForGamePad()
    {
        if (Gamepad.current.leftStick.left.isPressed || Gamepad.current.dpad.left.isPressed)
        {
            if (transform.position.x > -limit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            }
        }
        if (Gamepad.current.leftStick.right.isPressed || Gamepad.current.dpad.right.isPressed)
        {
            if (transform.position.x < limit)
            {
                transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
            }
        }
        if (isGrounded && Gamepad.current.aButton.isPressed)
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    private void ForBoth()
    {
        if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed || Gamepad.current.leftStick.left.isPressed || Gamepad.current.dpad.left.isPressed)
        {
            if (transform.position.x > -limit)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
            }
        }
        if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed || Gamepad.current.leftStick.right.isPressed || Gamepad.current.dpad.right.isPressed)
        {
            if (transform.position.x < limit)
            {
                transform.Translate(Vector3.right * Time.deltaTime * leftRightSpeed);
            }
        }
        if (Keyboard.current.spaceKey.isPressed || Gamepad.current.aButton.isPressed)
        {
            if (isGrounded)
            {
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                isGrounded = false;
            }
        }
    }
}