using UnityEngine;
using UnityEngine.UI;

public class GetLetter : MonoBehaviour
{
    public GameObject letter;

    public bool letterColected;

    [SerializeField] private ClickButton button;

    private void Start()
    {
        gameObject.layer = LayerMask.NameToLayer("ClickMove");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!letterColected)
        {
            button.letter = letter;
            button.getLetter = this;
            button.gameObject.SetActive(true);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (!letterColected) {
            button.letter.SetActive(false);
            button.gameObject.SetActive(false);
        }
    }

}
