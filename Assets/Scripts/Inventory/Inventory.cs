using UnityEngine;
using System;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{

    public static Inventory Instance { get; private set; }

    public List<GameObject> letters = new List<GameObject>();
    public List<GameObject> keys = new List<GameObject>();
    public List<GameObject> flor = new List<GameObject>();
    public List<GameObject> perfume = new List<GameObject>();
    public List<GameObject> diario = new List<GameObject>();



    public List<GameObject> selectedItems = new List<GameObject>();

    // Novo item para representar o item combinado (ex: Perfume com Flor)
    public GameObject combinedPerfume;
    public GameObject combinedDiario;

    private void Awake()
    {
        Instance = this;
    }
    public void SelectItem(GameObject item)
    {
        if (!selectedItems.Contains(item))
        {
            selectedItems.Add(item);
        }
    }

    public void ClearSelection()
    {
        selectedItems.Clear();
    }

    public void AddItem(CollectableObject collectable)
    {
        GameObject obj = collectable.gameObject;

        switch (collectable.CollectableType)
        {
            case CollectableType.None:
                {
                    return;
                }

            case CollectableType.Key:
                {
                    keys.Add(obj);
                    break;
                }
            case CollectableType.Letter:
                {
                    letters.Add(obj);
                    break;
                }

            case CollectableType.Perfume:
                {
                    perfume.Add(obj);
                    break;

                }

            case CollectableType.Flower:
                {
                    flor.Add(obj);
                    break;
                }

            case CollectableType.Diary:
                {
                    diario.Add(obj);
                    break;
                }

            default: { return; }

        }
    }
}