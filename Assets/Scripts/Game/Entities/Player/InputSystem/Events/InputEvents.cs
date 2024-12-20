using System;
using UnityEngine;

public static class InputEvents
{
    public static event Action<Vector2> OnMovementPressed;
    public static event Action<Vector2> OnMouseMoved;
    public static event Action OnMainSkillPressed;
    public static event Action OnSupportSkillPressed;
    public static event Action OnJumpPressed;
    public static event Action OnSprintPressed;
    public static event Action OnCrouchPressed;
    public static event Action OnInteractPressed;

    public static void MainSkillPressed()
    {
        OnMainSkillPressed?.Invoke();
    }
    public static void SupportSkillPressed()
    {
        OnSupportSkillPressed?.Invoke();
    }
    public static void JumpPressed()
    {
        OnJumpPressed?.Invoke();
    }
    public static void SprintPressed()
    {
        OnSprintPressed?.Invoke();
    }
    public static void CrouchPressed()
    {
        OnCrouchPressed?.Invoke();
    }
    public static void InteractPressed()
    {
        OnInteractPressed?.Invoke();
    }
    public static void MovementPressed(Vector2 movementDirection)
    {
        OnMovementPressed?.Invoke(movementDirection);
    }
    public static void MoveMouse(Vector2 movementDirection)
    {
        OnMouseMoved?.Invoke(movementDirection);
    }
}