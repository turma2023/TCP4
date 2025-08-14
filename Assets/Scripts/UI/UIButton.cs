using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIButton : MonoBehaviour
{
    public TextMeshProUGUI Text { get; private set; }
    private Button button;
    void Start()
    {
        Text = GetComponentInChildren<TextMeshProUGUI>();
        button = GetComponent<Button>();
    }

    public void SetButtonText(string text)
    {
        if (Text != null) Text.text = text;
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public void Interaction(bool activte)
    {
        button.enabled = activte;
    }
}
