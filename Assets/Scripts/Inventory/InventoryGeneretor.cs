using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class InventoryGeneretor : MonoBehaviour
{

    private Inventory inventory;
    public Button buttonPrefab;
    public GameObject content;
    private List<GameObject> buttons = new List<GameObject>();

    void Start()
    {
        inventory = GetComponent<Inventory>();
    }
    void Update()
    {

        if (buttons.Count != (inventory.letters.Count + inventory.keys.Count))
        {
            AllItens();
        }

    }

    public void AllItens()
    {
        DestroyButtons();

        foreach (GameObject letter in inventory.letters)
        {
            Button newButton = Instantiate(buttonPrefab, content.transform);
            newButton.transform.SetParent(content.transform, false);
            newButton.GetComponentInChildren<TextMeshProUGUI>().text = letter.name;
            newButton.onClick.AddListener(() => ShowLetter(letter));
            buttons.Add(newButton.gameObject);
        }

        foreach (GameObject key in inventory.keys)
        {
            Button newButton = Instantiate(buttonPrefab, content.transform);
            newButton.transform.SetParent(content.transform, false);
            newButton.GetComponentInChildren<TextMeshProUGUI>().text = key.name;
            // newButton.onClick.AddListener(() => ShowLetter(key));
            buttons.Add(newButton.gameObject);
        }
    }

    public void Keys()
    {
        DestroyButtons();
        foreach (GameObject key in inventory.keys)
        {
            Button newButton = Instantiate(buttonPrefab, content.transform);
            newButton.transform.SetParent(content.transform, false);
            newButton.GetComponentInChildren<TextMeshProUGUI>().text = key.name;
            // newButton.onClick.AddListener(() => ShowLetter(key));
            buttons.Add(newButton.gameObject);
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

    private void ShowLetter(GameObject letter)
    {
        letter.SetActive(true);
    }

}
