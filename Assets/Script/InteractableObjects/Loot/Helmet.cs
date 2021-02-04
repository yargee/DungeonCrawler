using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helmet : Loot
{
    public override bool CheckLootСompatibility(ItemSlot slot)
    {
        if (slot is HeadSlot || slot is AnySlot)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
