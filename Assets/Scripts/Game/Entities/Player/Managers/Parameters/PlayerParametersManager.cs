using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParametersManager
{
    private CharacterData _characterData;

    public void Init(ref CharacterData characterData)
    {
        _characterData = characterData;
        Subscribe();
    }
    public void Disable()
    {
        UnSubscribe();
    }

    private void Subscribe()
    {
        CharacterEvents.OnPlayerParameterChanged += ModifyParameter;
    }

    private void UnSubscribe()
    {
        CharacterEvents.OnPlayerParameterChanged -= ModifyParameter;
    }

    private void ModifyParameter(PlayerParameterTypes playerParameterTypes, float amount, bool isPercent)
    {
        if(isPercent)
        {
            ModifyPercent(playerParameterTypes , amount);
            return;
        }
        ModifyAmount(playerParameterTypes, amount);
    }
    private void ModifyPercent(PlayerParameterTypes playerParameterTypes, float percent)
    {
        float parameter = _characterData.GetParameter(playerParameterTypes);
        float adjustment = parameter * (percent / 100f);

        parameter += adjustment;

        _characterData.SetParameter(playerParameterTypes, parameter);
        Debug.Log($"parameter: {playerParameterTypes} modified and now equal {parameter}");
    }
    private void ModifyAmount(PlayerParameterTypes playerParameterTypes, float amount)
    {
        float parameter = _characterData.GetParameter(playerParameterTypes);

        parameter += amount;

        _characterData.SetParameter(playerParameterTypes, parameter);
        Debug.Log($"parameter: {playerParameterTypes} modified and now equal {parameter}");
    }
}
