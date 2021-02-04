using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] GameObject _panel;
    [SerializeField] private bool _state;
    
    public void SwitchPanelState()
    {        
        _state = !_state;
        _panel.gameObject.SetActive(_state);
    }
}
