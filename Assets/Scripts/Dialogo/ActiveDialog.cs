using UnityEngine;

public class ActiveDialog : MonoBehaviour
{
    public DialogAsset dialogAsset;
    public DialogManager dialogManager;
    void Start()
    {
        dialogManager.IniciarDialogo(dialogAsset);
    }

}
