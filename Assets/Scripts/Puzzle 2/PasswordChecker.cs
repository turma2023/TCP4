using UnityEngine;
using UnityEngine.Events;

public class PasswordChecker : MonoBehaviour
{
    [SerializeField] private UnityEvent OnCorrectPassword;

    private PasswordSlot[] passwordSlots = null;
    private void Start()
    {
        passwordSlots = GetComponentsInChildren<PasswordSlot>();
        foreach (PasswordSlot slot in passwordSlots) { slot.OnCharacterChange += OnSlotCharacterChange; }
    }

    private void OnSlotCharacterChange()
    {
        foreach (var slot in passwordSlots)
        {
            if (!slot.IsCharacterCorrect) return;
        }
        Debug.Log("Password Correct!");
        OnCorrectPassword?.Invoke();
    }

    private void OnDisable()
    {
        foreach (PasswordSlot slot in passwordSlots) { slot.OnCharacterChange -= OnSlotCharacterChange; }
    }
}
