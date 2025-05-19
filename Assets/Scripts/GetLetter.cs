using UnityEngine;
using UnityEngine.UI;

public class GetCard : MonoBehaviour
{

    public string textLetter;
    public bool letterColected;

    [SerializeField] private ClickButton button;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log($"Objeto {other.gameObject.name} entrou no Trigger de {gameObject.name}");
        button.textLetter.text = textLetter;
        button.gameObject.SetActive(true);
    }
    
    private void OnTriggerExit(Collider other)
    {
        // Debug.Log($"Objeto {other.gameObject.name} saiu do Trigger de {gameObject.name}");
        button.gameObject.SetActive(false);
    }

}
