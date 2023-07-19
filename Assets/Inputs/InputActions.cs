using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputActions : MonoBehaviour
{
    public FirstPersonScript player_ref;

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();

        player_ref.UpdateDirection(moveInput);
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        print("Fire");
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 lookInput = context.ReadValue<Vector2>();
        player_ref.UpdateRotation(lookInput);
    }
}
