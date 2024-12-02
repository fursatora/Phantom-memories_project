//using System.Numerics;
using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instanse { get; private set; }

    [SerializeField] private float movingSpeed = 1f;

    private Rigidbody2D rb;
    private float minMovingSpeed = 0.01f;
    private bool isRunning = false;
    private Vector2 targetPosition;
    private bool shouldMove = true;

    private void Awake()
    {
        Instanse = this;
        rb = GetComponent<Rigidbody2D>();
        targetPosition = rb.position;
    }

    private void FixedUpdate()
    {
        HandleMove();
    }

    public void SetTargetPosition(Vector2 position)
    {
        targetPosition = position;
        shouldMove = true;
    }

    private void MoveByTabs(Vector2 inputVector)
    {
        rb.MovePosition(rb.position + inputVector.normalized * movingSpeed * Time.fixedDeltaTime);
        Debug.Log(inputVector);
    }

    private void MoveByClick()
    {
        Vector2 direction = (targetPosition - rb.position).normalized;
        if (Vector2.Distance(rb.position, targetPosition) >= 0.1f)
        {
            isRunning = true; 
            rb.MovePosition(rb.position + direction * movingSpeed * Time.fixedDeltaTime);
        }
        else
        {
            isRunning = false; 
            shouldMove = false;
        }
    }

    private void HandleMove()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVector();

        if (shouldMove)
        {
            MoveByClick();
        }
        else if (inputVector != Vector2.zero)
        {
            MoveByTabs(inputVector);
        }

        if (Math.Abs(inputVector.x) > minMovingSpeed || Math.Abs(inputVector.y) > minMovingSpeed)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }
    }

    public bool IsRunning()
    {
        return isRunning;
    }


}
