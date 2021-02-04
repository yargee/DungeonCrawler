using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    [SerializeField] private List<Exit> _exits;

    public Exit CurrentExit { get; private set; }

    public void SetCurrentExit(Exit exit)
    {
        CurrentExit = exit;
    }

    public Exit GetExit(int index)
    {
        return _exits[index];
    }   

    public void GenerateExits(int chance)
    {        
        foreach (var exit in _exits)
        {
            exit.TryBlockExit(chance);
        }
    }
}
