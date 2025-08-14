using UnityEngine;
using System;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    public List<GameObject> letters = new List<GameObject>();
    public List<GameObject> keys = new List<GameObject>();
    public List<GameObject> flor = new List<GameObject>();
    public List<GameObject> perfume = new List<GameObject>();
    public List<GameObject> diario = new List<GameObject>();



    public List<GameObject> selectedItems = new List<GameObject>();

    // Novo item para representar o item combinado (ex: Perfume com Flor)
    public GameObject combinedPerfume;
    public GameObject combinedDiario;


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
}