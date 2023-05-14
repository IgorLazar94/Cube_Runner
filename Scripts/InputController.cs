using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private float offsetSpeed;
    [SerializeField] private float moveForwardSpeed;
    private bool isDragging = false;
    private float dragStartPos;
    private float dragEndPos;

    private void FixedUpdate()
    {
        PlayerForwardMovement();

        CheckInput();
        if (isDragging)
        {
            PlayerOffsetX();
        }

    }

    private void CheckInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                isDragging = true;
                dragStartPos = touch.position.x;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                isDragging = false;
            }
        }
    }
    private void PlayerOffsetX()
    {

        Touch touch = Input.GetTouch(0);
        dragEndPos = touch.position.x;
        float offsetValue = dragEndPos - dragStartPos;

        if (offsetValue > 0)
        {
            transform.Translate(Vector3.right * offsetSpeed * Time.deltaTime);
        }
        else if (offsetValue < 0)
        {
            transform.Translate(Vector3.left * offsetSpeed * Time.deltaTime);
        }

        dragStartPos = dragEndPos;
    }

    private void PlayerForwardMovement()
    {
        transform.Translate(Vector3.forward * moveForwardSpeed * Time.deltaTime);
    }
}
