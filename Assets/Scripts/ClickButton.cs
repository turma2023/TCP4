using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ClickButton : MonoBehaviour {
	private Button Button;
    
    public GameObject letter;
    public TMP_Text textLetter;

    void Start()
    {
        Button = GetComponent<Button>();
        Button.onClick.AddListener(TaskOnClick);
        textLetter = letter.GetComponentInChildren<TMP_Text>();
        gameObject.SetActive(false);
        letter.SetActive(false);
	}

	void TaskOnClick(){
        letter.SetActive(true);
        Button.gameObject.SetActive(false);
	}
}