using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Exit : MonoBehaviour
{
    [SerializeField] private bool _isConnected;
    [SerializeField] private Wall _wall;
    [SerializeField] Collider2D _collider;

    protected Vector3 ExitOffset;
    public bool IsConnected => _isConnected;
    public Collider2D Collider => _collider;
    public void SetWall()
    {
        _wall.gameObject.SetActive(true);
    }

    public void ConnectExit()
    {
        _isConnected = true;
    }

    public void ConnectRooms(Room newRoom)
    {
        var offset = transform.position - newRoom.CurrentExit.transform.position;
        newRoom.transform.position += offset;// + ExitOffset;
        ConnectExit();
        newRoom.CurrentExit.ConnectExit();        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Wall wall))
        {
            ConnectExit();
            gameObject.SetActive(false);            
            SetWall();
        }
        
        if (collision.TryGetComponent(out Exit exit) && exit.enabled)
        {
            ConnectExit();
            exit.ConnectExit();
        }
    }

    public void TryBlockExit(int chance)
    {
        if (!IsConnected)
        {
            var chanceToBlock = Random.Range(0, 100);
            if (chanceToBlock < chance)
            {
                ConnectExit();
                gameObject.SetActive(false);                
                SetWall();
            }
        }
    }

    public abstract Room AddRoom(Room Template);
}
