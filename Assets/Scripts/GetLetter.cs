using UnityEngine;
using UnityEngine.UI;

public class GetCard : MonoBehaviour
{
    public GameObject letter;

    public bool letterColected;

    [SerializeField] private ClickButton button;

    private void OnTriggerEnter(Collider other)
    {
        if (!letterColected)
        {
            button.letter = letter;
            button.gameObject.SetActive(true);
            letterColected = true;
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (letterColected) {
            button.letter.SetActive(false);
            button.gameObject.SetActive(false);
        }
    }

}
