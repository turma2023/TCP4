using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ActionButtons : MonoBehaviour
{
    public Button buttonPlay;
    public Button buttonExit;
    void Start()
    {
        // buttonPlay = GetComponent<Button>();
        // buttonExit = GetComponent<Button>();

        buttonPlay.onClick.AddListener(() => SceneManager.LoadScene("CutScene"));
        buttonExit.onClick.AddListener(() => Application.Quit());
    }

}
