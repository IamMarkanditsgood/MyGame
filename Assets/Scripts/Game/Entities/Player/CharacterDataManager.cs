public class CharacterDataManager
{
    public CharacterData ConfigureCharacterData(BasicCharacterConfig basicCharacterConfig)
    {
        CharacterData characterData = new CharacterData();

        characterData.CharacterPrefab = basicCharacterConfig.CharacterPrefab;
        characterData.MovementSpeed = basicCharacterConfig.MovementSpeed;
        characterData.RotationSpeed = basicCharacterConfig.RotationSpeed;

        return characterData;

    }
}