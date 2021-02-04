using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestPanel : MonoBehaviour
{
    [SerializeField] GameObject _lootContainer;
    [SerializeField] Chest _currentChest;
    [SerializeField] LootView _lootTemplate;
    [SerializeField] private Transform _draggingParent;

    private void OnDisable()
    {        
        _currentChest.ChestInteracted -= OnChestInteracted;
        _currentChest.InteractionCompleted -= OnInteractionCompleted;
    }

    public void SetCurrentChest(Chest chest)
    {
        _currentChest = chest;
        _currentChest.ChestInteracted += OnChestInteracted;
        _currentChest.InteractionCompleted += OnInteractionCompleted;
    }

    public void CleanChestPanel()
    {
        _currentChest.ChangeChestStatus();
        LootView[] tempLoot = _lootContainer.GetComponentsInChildren<LootView>();
        foreach(var loot in tempLoot)
        {            
            Destroy(loot.gameObject);
        }        
    }

    private void OnInteractionCompleted()
    {
        CleanChestPanel();
        gameObject.SetActive(false);
    }

    private void OnChestInteracted()
    {
        if (_currentChest != null && !_currentChest.LootCreated)
        {
            for (int i = 0; i < _currentChest.ItemsNumber; i++)
            {
                var newLootView = Instantiate(_lootTemplate, _lootContainer.transform);
                newLootView.Init(_draggingParent);
                newLootView.Render(_currentChest.GetItem(i));
            }
            _currentChest.ChangeChestStatus();
        }
    }
}
