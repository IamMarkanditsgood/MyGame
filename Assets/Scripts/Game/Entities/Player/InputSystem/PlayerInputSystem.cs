using System.Collections.Generic;

public class PlayerInputSystem
{
    private List<IInputable> _inputSystems = new List<IInputable>();

    public void Init()
    {
        DeclareInputSystems();
    }

    public void CheckInput()
    {
        foreach (var system in _inputSystems)
        {
            system.CheckInput();
        }
    }

    private void DeclareInputSystems()
    {
        _inputSystems.Add(new KeyboardInputSystem());
        _inputSystems.Add(new MouseInputSystem());
    }
}