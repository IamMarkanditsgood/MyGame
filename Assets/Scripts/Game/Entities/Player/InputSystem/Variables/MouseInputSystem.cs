using UnityEngine;

public class MouseInputSystem : IInputable
{
    public void CheckInput()
    {
        CheckMovement();
        CheckButtonsPressing();
    }

    private void CheckMovement()
    {
        Vector2 mouseMovementDirection;

        mouseMovementDirection.x = Input.GetAxis("Mouse X");
        mouseMovementDirection.y = Input.GetAxis("Mouse Y");

        InputEvents.MoveMouse(mouseMovementDirection);
    }

    private void CheckButtonsPressing()
    {
        if (Input.GetMouseButtonDown(0))// Pressed left-click.
        {
            InputEvents.SkillPressed(0);
        }

        if (Input.GetMouseButtonDown(1))// Pressed right-click
        {
            InputEvents.SkillPressed(1);
        }
    }
}