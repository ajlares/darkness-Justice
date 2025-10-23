using System;
using UnityEngine;
using Fusion;
public class playerMoveHard : NetworkBehaviour
{
    private CharacterController controller;
    public float moveSpeed = 2f;

    private void Awake()
    {
        gameObject.TryGetComponent(out controller);
    }

    public override void FixedUpdateNetwork()
    {
        if (GetInput<MyInput>(out var inputs) == false)
        {
            return;
        }
        Vector3 vector = new Vector3();
        
        if (inputs.buttons.IsSet(MyButtons.forward))
        {
            vector.z += 1f;
        }
        if (inputs.buttons.IsSet(MyButtons.backward))
        {
            vector.z -= 1f;
        }
        if (inputs.buttons.IsSet(MyButtons.left))
        {
            vector.x -= 1f;
        }
        if (inputs.buttons.IsSet(MyButtons.right))
        {
            vector.x += 1f;
        }
        
        controller.Move(vector * moveSpeed * Runner.DeltaTime);
        
    }
}
