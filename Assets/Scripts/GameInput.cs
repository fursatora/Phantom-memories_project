using UnityEngine;

public class GameInput : MonoBehaviour
{
    public static GameInput Instance { get; private set; }

    private PlayerInputActions playerInputActions;

    private void Awake()
    {
        Instance = this;
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();

        playerInputActions.PlayerActionMap.MoveByClick.performed += OnMouseClick;
    }

    private void OnDestroy()
    {
        playerInputActions.PlayerActionMap.MoveByClick.performed -= OnMouseClick;
    }

    public Vector2 GetMovementVector()
    {
        return playerInputActions.PlayerActionMap.Move.ReadValue<Vector2>();
    }

    private void OnMouseClick(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        Vector2 mousePosition = UnityEngine.InputSystem.Mouse.current.position.ReadValue();
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        PlayerController playerController = Object.FindFirstObjectByType<PlayerController>();
        if (playerController != null)
        {
            playerController.SetTargetPosition(new Vector2(worldPosition.x, worldPosition.y));
        }
    }
}

