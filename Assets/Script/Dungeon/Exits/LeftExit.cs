using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftExit : Exit
{
    private void Awake()
    {
        ExitOffset = Vector2.right/2;
    }
    public override Room AddRoom(Room template)
    {       
        var newRoom = Instantiate(template, new Vector3(100, 100, 0), Quaternion.identity); 
        var exit = newRoom.GetComponentInChildren<RightExit>();
        newRoom.SetCurrentExit(exit);
        return newRoom;
    }    
}
