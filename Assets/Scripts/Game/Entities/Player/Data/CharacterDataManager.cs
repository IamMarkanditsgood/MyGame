public class CharacterDataManager
{
    public CharacterData ConfigureCharacterData(CharacterConfig basicCharacterConfig)
    {
        CharacterData characterData = new CharacterData();

        characterData.CharacterPrefab = basicCharacterConfig.CharacterPrefab;
        characterData.Skills = basicCharacterConfig.Skills;
        characterData.Parameters = basicCharacterConfig.Parameters;

        return characterData;

    }
}