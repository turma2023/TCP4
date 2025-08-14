using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System;

public class ClickButton : MonoBehaviour {
    private Button Button;
    GameObject canvas;
    public GameObject letter;

    public Inventory inventory;

    public GetLetter getLetter;

    void Start()
    {
        canvas = transform.parent.gameObject;
        Button = GetComponent<Button>();
        gameObject.SetActive(false);
        Button.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        GameObject viewLetter = Instantiate(letter);
        viewLetter.transform.SetParent(canvas.transform, false);
        inventory.letters.Add(viewLetter);
        Button.gameObject.SetActive(false);
        getLetter.letterColected = true;

        if (getLetter.letterColected == true)
        {
            getLetter.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast"); 

            foreach (Transform child in getLetter.gameObject.transform)
            {
                child.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
            }
        }
        
    }
}