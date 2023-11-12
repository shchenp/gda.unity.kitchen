using System;
using UnityEngine;

public class ObjectsInteractionTask5 : MonoBehaviour
{
    // TODO: Подпишитесь на событие ItemSpawned класса Shelf
    // TODO: Если на полке станет более трех предметов - вызовите у объекта Shelf метод Fall
    // TODO: Логика должна работать для обоих полок сцены
    [SerializeField] private Shelf[] _shelves;

    private const int MAX_ITEMS_ON_SHELF = 3;

    private void Awake()
    {
        foreach (var shelf in _shelves)
        {
            shelf.ItemSpawned += OnItemSpawned;
        }
    }

    private void OnItemSpawned(Shelf shelf)
    {
        if (shelf.ItemsCount > MAX_ITEMS_ON_SHELF)
        {
            shelf.Fall();
        }
    }

    private void OnDestroy()
    {
        foreach (var shelf in _shelves)
        {
            shelf.ItemSpawned -= OnItemSpawned;
        }
    }
}