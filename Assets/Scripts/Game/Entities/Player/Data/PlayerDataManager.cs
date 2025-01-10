public class PlayerDataManager
{
    public CharacterData ConfigureCharacterData(CharacterConfig basicCharacterConfig, CharacterData oldCharacterData)
    {
        CharacterData characterData = oldCharacterData;

        characterData.CharacterPrefab = basicCharacterConfig.CharacterPrefab;
        characterData.Skills = basicCharacterConfig.Skills;
        characterData.Parameters = basicCharacterConfig.Parameters;

        return characterData;

    }
}