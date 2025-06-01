using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class InventoryGeneretor : MonoBehaviour
{

    public Inventory inventory;
    public Button buttonPrefab;
    public GameObject content;
    private List<GameObject> buttons = new List<GameObject>();


    // void Start()
    // {

    //     foreach (GameObject letter in inventory.letters)
    //     {
    //         Debug.Log("Adding letter: " + letter.name);
    //         Button newButton = Instantiate(buttonPrefab, content.transform);
    //         newButton.transform.SetParent(content.transform, false);
    //         newButton.GetComponentInChildren<TextMeshProUGUI>().text = letter.name;
    //         newButton.onClick.AddListener(() => ShowLetter(letter));
    //         buttons.Add(newButton.gameObject);
    //     }

    // }

    void Update()
    {

        if (buttons.Count != inventory.letters.Count)
        {
            UpdateButtons();
        }
                
    }

    private void UpdateButtons()
    {
        foreach (GameObject button in buttons)
        {
            Destroy(button);
        }
        buttons.Clear();

        foreach (GameObject letter in inventory.letters)
        {
            Debug.Log("Adding letter: " + letter.name);
            Button newButton = Instantiate(buttonPrefab, content.transform);
            newButton.transform.SetParent(content.transform, false);
            newButton.GetComponentInChildren<TextMeshProUGUI>().text = letter.name;
            newButton.onClick.AddListener(() => ShowLetter(letter));
            buttons.Add(newButton.gameObject);
        }
    }
    private void ShowLetter(GameObject letter)
    {

        letter.SetActive(true);
    }

}
