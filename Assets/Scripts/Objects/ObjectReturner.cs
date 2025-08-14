using UnityEngine;
using UnityEngine.UI;

public class ObjectReturner : MonoBehaviour
{
    public Button button;

    public void EnableReturnButton()
    {
        button.gameObject.SetActive(true);
    }

    public void DisableReturnButton()
    {
        button.gameObject.SetActive(false);
    }
}
