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

    private void Subscribe()
    {
        CharacterEvents.OnPlayerParameterChanged += ModifyParameter;
    }

    public void UnSubscribe()
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

    }
    private void ModifyAmount(PlayerParameterTypes playerParameterTypes, float percent)
    {
        
    }
}
