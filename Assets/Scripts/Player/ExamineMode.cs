using UnityEngine;

public class ExamineMode : MonoBehaviour
{

    public bool IsExamineMode;

    public Camera MainCamera ;
    public Camera ExamineCamera;


    public void ActiveMode()
    {
        MainCamera.enabled = false;
        ExamineCamera.enabled = true;
        IsExamineMode = true;

    }

    public void DeactiveMode()
    {
        MainCamera.enabled = true;
        ExamineCamera.enabled = false;
        IsExamineMode = false;
        
    }
}
