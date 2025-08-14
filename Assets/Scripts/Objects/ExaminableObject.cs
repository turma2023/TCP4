using UnityEngine;

public class ExaminableObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        UIController.Instance.EnableExamineButton();
    }
    
    private void OnTriggerExit(Collider other)
    {
        UIController.Instance.DisableAllButtons();
    }

    

}
