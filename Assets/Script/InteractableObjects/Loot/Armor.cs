using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor : Loot
{
    public override bool CheckLootСompatibility(ItemSlot slot)
    {
        if (slot is ArmorSlot || slot is AnySlot)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
