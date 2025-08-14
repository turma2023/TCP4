using UnityEngine;

public class UIController : MonoBehaviour
{
    public static UIController Instance { get; private set; }

    [SerializeField] private UIButton examineButton;
    [SerializeField] private UIButton goBackButton;
    [SerializeField] private UIButton closeButton;
    [SerializeField] private UIButton colectButton;
    [SerializeField] private UIButton openButton;
    [SerializeField] private UIButton inventoryButton;
    [SerializeField] private UIButton messageButton;
    [SerializeField] private UIButton customButton;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        DisableAllButtons();
    }

    public void DisableAllButtons()
    {
        examineButton.Disable();
        goBackButton.Disable();
        closeButton.Disable();
        customButton.Disable();
        colectButton.Disable();
        openButton.Disable();
        messageButton.Disable();
    }

    public void EnableExamineButton()
    {
        DisableAllButtons();
        examineButton.Enable();
    }
    public void EnableGoBackButton()
    {
        DisableAllButtons();
        goBackButton.Enable();
    }
    public void EnableCloseButton()
    {
        DisableAllButtons();
        closeButton.Enable();
    }
    public void EnableColectButton()
    {
        DisableAllButtons();
        colectButton.Enable();
    }
    public void EnableOpenButton()
    {
        DisableAllButtons();
        openButton.Enable();
    }
    public void EnableMessageButton(string text)
    {
        DisableAllButtons();
        messageButton.Enable();
        //messageButton.Interaction(false);
        messageButton.SetButtonText(text);
    }
    public void EnableCustomButton(string text = null)
    {
        DisableAllButtons();
        customButton.Enable();
        customButton.SetButtonText(text);
    }

}
