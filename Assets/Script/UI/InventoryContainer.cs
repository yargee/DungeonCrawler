using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryContainer : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private ItemSlot _itemSlot;   

    public Transform Container => _container;
    public ItemSlot ItemSlot => _itemSlot;    

    
}