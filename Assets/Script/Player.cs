using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private IInteractable _target;    

    private void Update()
    {
        if (_target == null)
        {
            return;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _target.StartInteract();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactableObject))
        {
            _target = interactableObject;            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactableObject))
        {
            _target = null;
            interactableObject.StopInteract();
        }
    }
}
