using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Loot
{
    public override bool CheckLootСompatibility(ItemSlot slot)
    {
        if (slot is RightHandSlot || slot is LeftHandSlot || slot is AnySlot)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
