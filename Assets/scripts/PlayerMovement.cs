using Fusion;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : NetworkBehaviour
{
    public CharacterController characterController;
    public float speed = 5.0f;
    public InputSystem_Actions inputActions;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
        inputActions.playermovement.Enable();
        gameObject.TryGetComponent(out characterController);
    }

    public override void FixedUpdateNetwork()
    {
        InputSystem.Update();
        Vector2 moveInput = inputActions.playermovement.move.ReadValue<Vector2>();
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y) * Runner.DeltaTime * speed;

        characterController.Move(move);

        if(move == Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
    }
}
