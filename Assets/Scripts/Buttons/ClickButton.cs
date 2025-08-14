using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ClickButton : MonoBehaviour
{
    private Button Button;
    GameObject canvas;
    public GameObject letter;

    public Inventory inventory;

    public GetLetter getLetter;

    void Start()
    {
        canvas = transform.parent.gameObject;
        Button = GetComponent<Button>();
        Button.onClick.AddListener(TaskOnClick);
        gameObject.SetActive(false);
    }

    void TaskOnClick()
    {
        GameObject viewLetter = Instantiate(letter);
        viewLetter.transform.SetParent(canvas.transform, false);
        inventory.letters.Add(viewLetter);
        Button.gameObject.SetActive(false);
        getLetter.letterColected = true;


        getLetter.gameObject.layer = 0;

        //foreach (Transform child in obj.transform)
        //{
        //    SetLayerRecursively(child.gameObject, newLayer);
        //}
    }
}