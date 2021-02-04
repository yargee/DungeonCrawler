using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomExit : Exit
{
    private void Awake()
    {
        ExitOffset = Vector2.up/2;
    }
    public override Room AddRoom(Room template)
    {        
        var newRoom = Instantiate(template, new Vector3(100, 100, 0), Quaternion.identity);
        var exit = newRoom.GetComponentInChildren<TopExit>();
        newRoom.SetCurrentExit(exit);
        return newRoom;
    }    
}
