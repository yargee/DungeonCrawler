using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health;
    
    public void SetDamage(int value)
    {
        _health -= value;

        if(_health<=0)
        {
            Destroy(gameObject);
        }
    }
}
