using System;

public static class CharacterEvents
{
    public static event Action<PlayerParameterTypes, float, bool> OnPlayerParameterChanged;

    public static void ModifyPlayerParameter(PlayerParameterTypes type, float amount, bool isPercent = true)
    {
        OnPlayerParameterChanged?.Invoke(type, amount, isPercent);
    }
}