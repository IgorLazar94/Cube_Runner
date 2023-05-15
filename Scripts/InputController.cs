using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private float offsetSpeed;
    [SerializeField] private float moveForwardSpeed;
    [SerializeField] GameManager gameManager;
    private bool isLoseState;
    private float dragStartPos;
    private float dragEndPos;
    private bool isDragging = false;
    private bool isTapToMove = false;

    private void Start()
    {
        isLoseState = false;
    }

    private void FixedUpdate()
    {
        if (isTapToMove && !isLoseState)
        {
            PlayerForwardMovement();
        }

        CheckInput();
        

    }

    public void SetIsTapToMove(bool value)
    {
        isTapToMove = value;
    }
    public void SetIsLoseState(bool value)
    {
        isLoseState = value;
    }

    private void CheckInput()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            StartLogic();

            if (touch.phase == TouchPhase.Began)
            {
                isDragging = true;
                dragStartPos = touch.position.x;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                isDragging = false;
            }

            if (isDragging)
            {
                PlayerOffsetX();
            }
        }
    }

    private void StartLogic()
    {
        if (!isTapToMove)
        {
            SetIsTapToMove(true);
            gameManager.ActivateStartPanel(false);
            gameObject.GetComponent<PlayerController>().warpFX.Play();
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
