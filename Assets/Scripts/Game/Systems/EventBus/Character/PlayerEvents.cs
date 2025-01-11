using System;
using UnityEngine;

public static class PlayerEvents
{
    public static event Action<PlayerParameterTypes, float, bool> OnPlayerParameterChanged;
    public static event Action<Vector3> OnDirectionModified;

    public static void ModifyPlayerParameter(PlayerParameterTypes type, float amount, bool isPercent = true)
    {
        OnPlayerParameterChanged?.Invoke(type, amount, isPercent);
    }
    public static void ModifyDirection(Vector3 direction)
    {
        OnDirectionModified?.Invoke(direction);
    }
}