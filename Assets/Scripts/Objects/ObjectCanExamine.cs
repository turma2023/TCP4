using UnityEngine;

public class ObjectCanExamine : MonoBehaviour
{

    public GameObject btnOpenExamine;

    private void OnTriggerEnter(Collider other)
    {
        btnOpenExamine.gameObject.SetActive(true);
    }
    
    private void OnTriggerExit(Collider other)
    {
        btnOpenExamine.gameObject.SetActive(false);
    }

    

}
