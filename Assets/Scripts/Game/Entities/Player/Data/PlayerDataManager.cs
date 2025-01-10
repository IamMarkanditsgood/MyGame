using System.Collections.Generic;

public class PlayerDataManager
{
    public CharacterData ConfigureCharacterData(CharacterConfig basicCharacterConfig, CharacterData oldCharacterData)
    {
        CharacterData characterData = oldCharacterData;

        characterData.CharacterPrefab = basicCharacterConfig.CharacterPrefab;
        characterData.Skills = new List<SkillTypes>(basicCharacterConfig.Skills);
        characterData.Parameters = new Dictionary<PlayerParameterTypes, float>(basicCharacterConfig.Parameters);

        return characterData;

    }
}