using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : Loot
{
    public override bool CheckLootСompatibility(ItemSlot slot)
    {
        return false;
    }
}
