using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ClickButton : MonoBehaviour {
    private Button Button;
    GameObject canvas;
    public GameObject letter;

    public Inventory inventory;

    void Start()
    {
        canvas = transform.parent.gameObject;
        Debug.Log(canvas.gameObject.name);
        Button = GetComponent<Button>();
        Button.onClick.AddListener(TaskOnClick);
        gameObject.SetActive(false);
    }

    void TaskOnClick()
    {
        GameObject viewLetter = Instantiate(letter);
        viewLetter.transform.SetParent(canvas.transform, false);
        inventory.letters.Add(letter);
        Button.gameObject.SetActive(false);
    }
}