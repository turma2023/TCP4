using UnityEngine;
using UnityEngine.UI;

public class EnableReturnButton : MonoBehaviour
{
    public Button button;
    public void EnableReturn()
    {
        button.gameObject.SetActive(true);
    }
}
