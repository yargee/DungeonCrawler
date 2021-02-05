using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class LootView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image _iconView;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _effectValue;
    [SerializeField] private Loot _loot;
    [SerializeField] private InventoryContainer _currentContainer;

    private Transform _draggingParent;
    private Transform _previousParent;

    public Loot Loot => _loot;

    public event UnityAction<LootView> TakenFromChest;
    public event UnityAction<LootView> PuttedIntoChest;

    public void OnBeginDrag(PointerEventData eventData)
    {
        _previousParent = transform.parent;
        transform.SetParent(_draggingParent);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var result = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, result);

        foreach (var item in result)
        {
            //Debug.Log(item);

            if (item.gameObject.TryGetComponent(out InventoryContainer container) && container.ItemSlot.IsEmpty)
            {
                if (Loot.CheckLootСompatibility(container.ItemSlot))
                {
                    _currentContainer.ItemSlot.ChangeEmptyStatus(); //освобождаем контейнер из которого перетащили предмет(сундук статус не меняет, он всегда "пуст")
                    transform.SetParent(container.Container); // назначаем родителем новый контейнер 
                    if (_currentContainer.ItemSlot is AnySlot) // если контейнер был сундуком, вызываем событие на удаление предмета из содержимого
                    {
                        TakenFromChest?.Invoke(this);
                    }

                    _currentContainer = container;   // назначаем новый контейнер текущим

                    container.ItemSlot.ChangeEmptyStatus(); // меняем статус контейнера на "занят"(сундук статус не меняет, он всегда "пуст")

                    if (_currentContainer.ItemSlot is AnySlot)  // если новый контейнер - сундук, вызываем событие на добавление предмета 
                    {
                        PuttedIntoChest?.Invoke(this);
                    }
                    return;
                }
            }
            transform.SetParent(_previousParent);
        }
    }

    public void Init(Transform parentTransform)
    {
        _draggingParent = parentTransform;
        _currentContainer = GetComponentInParent<InventoryContainer>();
    }

    public void Render(Loot loot)
    {
        _loot = loot;
        _iconView.sprite = loot.Icon.sprite;
        _name.text = loot.Name;
        _effectValue.text = loot.EffectValue.ToString();
    }
}
