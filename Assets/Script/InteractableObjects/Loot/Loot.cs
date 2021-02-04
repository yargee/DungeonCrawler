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

    //public event UnityAction<Loot> ITakenFromChest;
    //public event UnityAction<Loot> IPuttedIntoChest;

    public Image Icon => _icon;
    public string Name => _name;
    public int EffectValue => _effectValue;
       

    public virtual bool CheckLootСompatibility(ItemSlot slot)
    {
        return true;
    }

    private void Awake()
    {
        _lootView.TakenFromChest += OnTaken;
        _lootView.PuttedIntoChest += OnPutted;
    }

    private void OnDisable()
    {
        _lootView.TakenFromChest -= OnTaken;
        _lootView.PuttedIntoChest -= OnPutted;
    }
    public void OnTaken()
    {
        Debug.Log("View вызвало событие Taken");
        //ITakenFromChest?.Invoke(this);
    }

    public void OnPutted()
    {
        Debug.Log("View вызвало событие Taken");
        //IPuttedIntoChest?.Invoke(this);
    }
}
