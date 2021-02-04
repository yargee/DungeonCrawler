using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boots : Loot
{
    public override bool CheckLootСompatibility(ItemSlot slot)
    {
        if (slot is BootsSlot || slot is AnySlot)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
