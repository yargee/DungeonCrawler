using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class DungeonExit : MonoBehaviour
{
    [SerializeField] private GameObject _winPanel;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.gameObject.TryGetComponent(out Player player))
        {            
            _winPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
