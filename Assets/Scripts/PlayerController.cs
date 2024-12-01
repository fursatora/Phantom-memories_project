//using System.Numerics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movingSpeed = 1f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVector();

        inputVector = inputVector.normalized;
        rb.MovePosition(rb.position + inputVector * movingSpeed * Time.fixedDeltaTime);

        Debug.Log(inputVector);
    }
}
