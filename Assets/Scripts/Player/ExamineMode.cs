using UnityEngine;

public class ExamineMode : MonoBehaviour
{

    public bool IsExamineMode;

    public Camera MainCamera ;
    public Camera ExamineCamera;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ActiveMode()
    {
        MainCamera.enabled = false;
        ExamineCamera.enabled = true;
        IsExamineMode = true;
        Debug.Log("ativar: " + IsExamineMode);

    }

    public void DeactiveMode()
    {
        MainCamera.enabled = true;
        ExamineCamera.enabled = false;
        IsExamineMode = false;
        Debug.Log("desativar: " + IsExamineMode);
        
    }
}
