using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Loot : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private string _name;
    [SerializeField] private int _effectValue;
    [SerializeField] private int _id;
    [SerializeField] protected LootView _lootView;    

    public Image Icon => _icon;
    public string Name => _name;
    public int EffectValue => _effectValue;
    public LootView LootView => _lootView;        

    public virtual bool CheckLootСompatibility(ItemSlot slot)
    {
        return true;
    }
}
