// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;
// using System.Collections.Generic;

// public class InventoryGeneretor : MonoBehaviour
// {

//     private Inventory inventory;
//     public Button buttonPrefab;
//     public GameObject content;
//     private List<GameObject> buttons = new List<GameObject>();

//     void Start()
//     {
//         inventory = GetComponent<Inventory>();
//     }
//     void Update()
//     {

//         // if (buttons.Count != (inventory.letters.Count + inventory.keys.Count))
//         // {
//         //     UpdateButtons();
//         // }

//     }

//     public void AllItens()
//     {

//         if (inventory == null)
//         {
//             Debug.LogWarning("Iventario nulo");
//         }

//         DestroyButtons();

//         foreach (GameObject letter in inventory.letters)
//         {
//             Button newButton = Instantiate(buttonPrefab, content.transform);
//             newButton.transform.SetParent(content.transform, false);
//             newButton.GetComponentInChildren<TextMeshProUGUI>().text = letter.name;
//             newButton.onClick.AddListener(() => ShowLetter(letter));
//             buttons.Add(newButton.gameObject);
//         }

//         foreach (GameObject key in inventory.keys)
//         {
//             Button newButton = Instantiate(buttonPrefab, content.transform);
//             newButton.transform.SetParent(content.transform, false);
//             newButton.GetComponentInChildren<TextMeshProUGUI>().text = key.name;
//             // newButton.onClick.AddListener(() => ShowLetter(key));
//             buttons.Add(newButton.gameObject);
//         }

//         foreach (GameObject perfume in inventory.perfume)
//         {
//             Button newButton = Instantiate(buttonPrefab, content.transform);
//             newButton.transform.SetParent(content.transform, false);
//             newButton.GetComponentInChildren<TextMeshProUGUI>().text = perfume.name;
//             // newButton.onClick.AddListener(() => ShowLetter(key));
//             buttons.Add(newButton.gameObject);
//         }

//         foreach (GameObject flor in inventory.flor)
//         {
//             Button newButton = Instantiate(buttonPrefab, content.transform);
//             newButton.transform.SetParent(content.transform, false);
//             newButton.GetComponentInChildren<TextMeshProUGUI>().text = flor.name;
//             // newButton.onClick.AddListener(() => ShowLetter(key));
//             buttons.Add(newButton.gameObject);
//         }

//     }

//     public void Keys()
//     {
//         DestroyButtons();
//         foreach (GameObject key in inventory.keys)
//         {
//             Button newButton = Instantiate(buttonPrefab, content.transform);
//             newButton.transform.SetParent(content.transform, false);
//             newButton.GetComponentInChildren<TextMeshProUGUI>().text = key.name;
//             // newButton.onClick.AddListener(() => ShowLetter(key));
//             buttons.Add(newButton.gameObject);
//         }
//     }


//     private void DestroyButtons()
//     {
//         foreach (GameObject button in buttons)
//         {
//             Destroy(button);
//         }
//         buttons.Clear();
//     }

//     private void ShowLetter(GameObject letter)
//     {
//         letter.SetActive(true);
//     }

// }


using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine.Events;

public class InventoryGeneretor : MonoBehaviour
{
    private Inventory inventory;
    public Button buttonPrefab;
    public GameObject content;
    private List<GameObject> buttons = new List<GameObject>();


    public Button combineButton;
    public TextMeshProUGUI selectedItemsText;


    public Color normalColor = Color.white;
    public Color selectedColor = Color.yellow;

    void Start()
    {
        inventory = GetComponent<Inventory>();
        if (combineButton != null)
        {
            combineButton.onClick.AddListener(CombineItems);
        }
    }

    public void AllItensInterative()
    {

        if (inventory == null)
        {
            Debug.LogWarning("Iventario nulo");
        }

        DestroyButtons();

        Letters();
        Keys();
        Perfume();
        Flor();
        Diario();
    }
    private void Letters()
    {
        // foreach (GameObject letter in inventory.letters)
        // {
        //     Button newButton = Instantiate(buttonPrefab, content.transform);
        //     newButton.transform.SetParent(content.transform, false);
        //     newButton.GetComponentInChildren<TextMeshProUGUI>().text = letter.name;
        //     newButton.onClick.AddListener(() => letter.SetActive(true));
        //     buttons.Add(newButton.gameObject);
        // }
        foreach (GameObject letter in inventory.letters)
        {
            CreateItemButton(letter, () => letter.SetActive(true));
        }
    }
    private void Keys()
    {
        // foreach (GameObject key in inventory.keys)
        // {
        //     Button newButton = Instantiate(buttonPrefab, content.transform);
        //     newButton.transform.SetParent(content.transform, false);
        //     newButton.GetComponentInChildren<TextMeshProUGUI>().text = key.name;
        //     // newButton.onClick.AddListener(() => ShowLetter(key));
        //     buttons.Add(newButton.gameObject);
        // }
        foreach (GameObject key in inventory.keys)
            CreateItemButton(key);
    }
    private void Perfume()
    {
        // foreach (GameObject perfume in inventory.perfume)
        // {
        //     Button newButton = Instantiate(buttonPrefab, content.transform);
        //     newButton.transform.SetParent(content.transform, false);
        //     newButton.GetComponentInChildren<TextMeshProUGUI>().text = perfume.name;
        //     // newButton.onClick.AddListener(() => ShowLetter(key));
        //     buttons.Add(newButton.gameObject);
        // }
        foreach (GameObject perfume in inventory.perfume)
            CreateItemButton(perfume);
    }
    private void Flor()
    {
        // foreach (GameObject flor in inventory.flor)
        // {
        //     Button newButton = Instantiate(buttonPrefab, content.transform);
        //     newButton.transform.SetParent(content.transform, false);
        //     newButton.GetComponentInChildren<TextMeshProUGUI>().text = flor.name;
        //     // newButton.onClick.AddListener(() => ShowLetter(key));
        //     buttons.Add(newButton.gameObject);
        // }
        foreach (GameObject flor in inventory.flor)
            CreateItemButton(flor);
    }
    private void Diario()
    {
        // foreach (GameObject diario in inventory.diario)
        // {
        //     Button newButton = Instantiate(buttonPrefab, content.transform);
        //     newButton.transform.SetParent(content.transform, false);
        //     newButton.GetComponentInChildren<TextMeshProUGUI>().text = diario.name;
        //     // newButton.onClick.AddListener(() => ShowLetter(key));
        //     buttons.Add(newButton.gameObject);
        // }
        foreach (GameObject diario in inventory.diario)
            CreateItemButton(diario);
    }

    public void AllItemsCombine()
    {
        DestroyButtons();

        List<GameObject> allItems = new List<GameObject>();
        allItems.AddRange(inventory.letters);
        allItems.AddRange(inventory.keys);
        allItems.AddRange(inventory.perfume);
        allItems.AddRange(inventory.flor);
        allItems.AddRange(inventory.diario);

        foreach (GameObject item in allItems)
        {
            Button newButton = Instantiate(buttonPrefab, content.transform);
            CreateItemButton(item, () => OnItemClick(item, newButton), newButton);
        }

        UpdateSelectedItemsUI();
    }

    private void CreateItemButton(GameObject item, UnityAction action = null, Button newButton = null)
    {
        if (newButton == null)
            newButton = Instantiate(buttonPrefab, content.transform);

        newButton.GetComponentInChildren<TextMeshProUGUI>().text = item.name;

        Image buttonImage = newButton.GetComponent<Image>();
        if (inventory.selectedItems.Contains(item))
        {
            buttonImage.color = selectedColor;
        }
        else
        {
            buttonImage.color = normalColor;
        }

        // newButton.onClick.AddListener(() => OnItemClick(item, newButton));
        newButton.onClick.AddListener(action);

        buttons.Add(newButton.gameObject);
    }

    private void OnItemClick(GameObject item, Button clickedButton)
    {
        Image buttonImage = clickedButton.GetComponent<Image>();

        if (inventory.selectedItems.Contains(item))
        {
            inventory.selectedItems.Remove(item);
            buttonImage.color = normalColor;
        }
        else
        {
            inventory.selectedItems.Add(item);
            buttonImage.color = selectedColor;
        }

        UpdateSelectedItemsUI();
    }

    private void UpdateSelectedItemsUI()
    {
        string selectedNames = "Itens selecionados: ";
        foreach (var item in inventory.selectedItems)
        {
            selectedNames += item.name + ", ";
        }
        if (selectedItemsText != null)
        {
            selectedItemsText.text = selectedNames.TrimEnd(',', ' ');
        }
    }

    public void CombineItems()
    {
        if (inventory.selectedItems.Count == 2)
        {
            GameObject item1 = inventory.selectedItems[0];
            GameObject item2 = inventory.selectedItems[1];

            if ((item1.name.Contains("Perfume") && item2.name.Contains("Flor")) ||
                (item1.name.Contains("Flor") && item2.name.Contains("Perfume")))
            {
                RemoveItemInventory(item1);
                RemoveItemInventory(item2);

                if (inventory.combinedPerfume != null)
                {
                    inventory.combinedPerfume.name = "Flor Perfumada";
                    inventory.combinedPerfume.GetComponent<Flor>().isPerfumed = true;
                    inventory.flor.Add(inventory.combinedPerfume); // Exemplo: Adiciona o item combinado na lista de flor
                }

                inventory.ClearSelection();
                AllItemsCombine();
            }
            else if ((item1.name.Contains("Diario") && item2.name.Contains("Flor Perfumada")) ||
                     (item1.name.Contains("Flor Perfumada") && item2.name.Contains("Diario")))
            {
                RemoveItemInventory(item1);
                RemoveItemInventory(item2);

                if (inventory.combinedDiario != null)
                {
                    inventory.combinedDiario.name = "Diario Aberto";
                    inventory.combinedDiario.GetComponent<Diario>().isOpen = true;
                    inventory.diario.Add(inventory.combinedDiario);
                }

                inventory.ClearSelection();
                AllItemsCombine();
            }
            else
            {
                Debug.Log("Esses itens não podem ser combinados.");
                inventory.ClearSelection();
                UpdateSelectedItemsUI();
            }
        }
        else
        {
            Debug.Log("Selecione exatamente 2 itens para combinar.");
            inventory.ClearSelection();
        }
    }


    private void DestroyButtons()
    {
        foreach (GameObject button in buttons)
        {
            Destroy(button);
        }
        buttons.Clear();
    }

    // public void Keys()
    // {
    //     DestroyButtons();
    //     foreach (GameObject key in inventory.keys)
    //     {
    //         CreateItemButton(key);
    //     }
    // }

    private void RemoveItemInventory(GameObject item)
    {
        if (inventory.letters.Contains(item)) inventory.letters.Remove(item);
        else if (inventory.keys.Contains(item)) inventory.keys.Remove(item);
        else if (inventory.perfume.Contains(item)) inventory.perfume.Remove(item);
        else if (inventory.flor.Contains(item)) inventory.flor.Remove(item);
        else if (inventory.diario.Contains(item)) inventory.diario.Remove(item);
    }
}