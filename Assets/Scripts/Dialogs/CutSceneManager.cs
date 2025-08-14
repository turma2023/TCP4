using UnityEngine;
using UnityEngine.SceneManagement;

public class CutSceneManager : MonoBehaviour
{
    // private Animator animator;
    public DialogManager dialogManager;

    public DialogAsset dialogoChegada;
    public DialogAsset dialogoJantar;
    public DialogAsset dialogoQuarto;

    public bool isDialogoChegada = true;
    public bool isDialogoJantar;
    public bool isDialogoQuarto;

    private bool SceneLoaded;

    void Start()
    {
        // animator = GetComponent<Animator>();
        dialogManager = GetComponent<DialogManager>();
        
    }

    void Update()
    {
        if (isDialogoChegada)
        {
            Debug.Log("ta entrando aqui");
            dialogManager.animator.SetBool("FadeInChegada", true);
            if (dialogManager.animator.GetCurrentAnimatorStateInfo(0).IsName("FadeInChegada"))
            {
                dialogManager.IniciarDialogo(dialogoChegada, "FadeInChegada", "FadeOutChegada");
                isDialogoChegada = false;
            }
        }
        if (isDialogoJantar)
        {
            dialogManager.animator.SetBool("FadeInJantar", true);
            if (dialogManager.animator.GetCurrentAnimatorStateInfo(0).IsName("FadeInJantar"))
            {
                dialogManager.IniciarDialogo(dialogoJantar, "FadeInJantar", "FadeOutJantar");
                isDialogoJantar = false;
            }
        }
        if (isDialogoQuarto)
        {
            dialogManager.animator.SetBool("FadeInQuarto", true);
            if (dialogManager.animator.GetCurrentAnimatorStateInfo(0).IsName("FadeInQuarto"))
            {
                dialogManager.IniciarDialogo(dialogoQuarto, "FadeInQuarto", "FadeOutQuarto");
                isDialogoQuarto = false;
            }
        }
        if (dialogManager.animator.GetCurrentAnimatorStateInfo(0).IsName("FadeOutQuarto"))
        {
            if (dialogManager.animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f && !SceneLoaded)
            {
                SceneLoaded = true;
                SceneManager.LoadScene("PrototypeScene");
            }
        }
    }
}
