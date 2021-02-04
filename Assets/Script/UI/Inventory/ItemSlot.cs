using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] private bool _isEmpty = true;
    public bool IsEmpty => _isEmpty;
    
    public void ChangeEmptyStatus()
    {
        if (gameObject.TryGetComponent(out AnySlot anySlot))
        {            
            return;
        }
        else
        {
            _isEmpty = !_isEmpty;
        }
    }
}
