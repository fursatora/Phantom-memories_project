//using System.Numerics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movingSpeed = 1f;

    private Rigidbody2D rb;
    private Vector2 targetPosition; 
    private bool shouldMove = true; 

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        targetPosition = rb.position; 
    }

    private void FixedUpdate()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVector();

        if (shouldMove)
        {
            Vector2 direction = (targetPosition - rb.position).normalized;
            rb.MovePosition(rb.position + direction * movingSpeed * Time.fixedDeltaTime);

            if (Vector2.Distance(rb.position, targetPosition) < 0.1f)
            {
                shouldMove = false;
            }
        }
        else if (inputVector != Vector2.zero)
        {
            rb.MovePosition(rb.position + inputVector.normalized * movingSpeed * Time.fixedDeltaTime);
        }
    }

    public void SetTargetPosition(Vector2 position)
    {
        targetPosition = position;
        shouldMove = true; 
    }
}
