using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Chest : MonoBehaviour, IInteractable
{
    [SerializeField] private List<Loot> _chestContent;
    [SerializeField] private List<Loot> _availableLoot;
    [SerializeField] private ChestPanel _chestPanel;

    public int ItemsNumber { get; private set; }
    public bool LootCreated { get; private set; }

    public event UnityAction ChestInteracted;
    public event UnityAction InteractionCompleted;


    private void Awake()
    {
        _chestContent = new List<Loot>();
        ItemsNumber = Random.Range(0, 6);
        for (int i = 0; i < ItemsNumber; i++)
        {
            Loot loot = _availableLoot[Random.Range(0, _availableLoot.Count)];            
            _chestContent.Add(loot);
            
        }
    }

    public void RemoveItem(Loot loot)
    {
        _chestContent.Remove(loot);
    }
    public void AddItem(Loot loot)
    {
        _chestContent.Add(loot);
    }

    public void ChangeItemNumber(int value)
    {
        ItemsNumber += value;
    }

    public void ChangeChestStatus()
    {
        LootCreated = !LootCreated;
    }

    public Loot GetItem(int index)
    {
        return _chestContent[index];
    }

    public void Init(ChestPanel chestPanel)
    {
        _chestPanel = chestPanel;
    }

    public void StartInteract()
    {
        _chestPanel.gameObject.SetActive(true);
        _chestPanel.transform.position = transform.position + new Vector3(800, 400);
        _chestPanel.SetCurrentChest(this);
        ChestInteracted?.Invoke();
    }

    public void StopInteract()
    {
        InteractionCompleted?.Invoke();
    }
}
