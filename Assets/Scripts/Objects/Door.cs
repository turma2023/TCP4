using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{

    public int keyId;
    public bool isOpen;

    private bool onTrigger;

    public GameObject btnOpenDoor;


    void Start()
    {

    }

    void Update()
    {
        //if (onTrigger)
        //{
        //    Debug.Log("status da porta: " + isOpen);
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        onTrigger = true;
        if (!isOpen)
        {
            other.gameObject.TryGetComponent(out Inventory inventory);
            if (inventory != null)
            {
                if (inventory.keys.Count <= 0) return;

                btnOpenDoor.SetActive(true);
                Button button = btnOpenDoor.GetComponent<Button>();
                if (button != null)
                {
                    //button.onClick.RemoveAllListeners();
                    button.onClick.AddListener(() => OpenDoor(other.gameObject));
                }
            }
        }
    }

    private void OpenDoor(GameObject gameObject)
    {
        Inventory inventory = gameObject.GetComponent<Inventory>();
        if (inventory.keys.Count > 0)
        {
            foreach (GameObject key in inventory.keys)
            {
                if (key.GetComponent<Key>().keyId == keyId)
                {
                    isOpen = true;
                    btnOpenDoor.SetActive(false);
                    this.gameObject.SetActive(false);
                    return;
                }
            }

            Debug.Log("Nenhuma chave pode abrir esta porta.");

        }
        if (inventory.keys.Count == 0)
        {
            Debug.Log("Não tem chaves no inventario.");
            return;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        onTrigger = false;
        if (!isOpen)
        {
            btnOpenDoor.SetActive(false);
        }
    }
}
