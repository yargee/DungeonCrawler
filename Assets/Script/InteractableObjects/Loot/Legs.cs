using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Legs : Loot
{
    public override bool CheckLootСompatibility(ItemSlot slot)
    {
        if (slot is LegsSlot || slot is AnySlot)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
