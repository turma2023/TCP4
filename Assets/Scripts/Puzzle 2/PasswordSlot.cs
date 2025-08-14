using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum PasswordType { Number, Letter }
public class PasswordSlot : MonoBehaviour
{
    [SerializeField] private char correctCharacter;
    [SerializeField] private PasswordType passwordType;

    private TextMeshProUGUI text;
    
    public event Action OnCharacterChange;
    private char[] possibleCharacters = null;
    private Queue<char> avaliableChars = new Queue<char>();
    public bool IsCharacterCorrect {  get; private set; }
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();  
        InitializePossibleCharacters();
        ChangeCharacter();
    }

    private void InitializePossibleCharacters()
    {
        switch (passwordType)
        {
            case PasswordType.Number:
                {
                    possibleCharacters = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
                    for (int i = 0; i < possibleCharacters.Length; i++) avaliableChars.Enqueue(possibleCharacters[i]);
                    break;
                }

            case PasswordType.Letter:
                {
                    possibleCharacters = new char[] { 'A',  'B', 'C', 'D',  'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
                        'N', 'O', 'P', 'Q', 'R',  'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'};
                    for (int i = 0; i < possibleCharacters.Length; i++) avaliableChars.Enqueue(possibleCharacters[i]);
                    break;
                }
        }
    }
    
    public void ChangeCharacter()
    {
        char character = avaliableChars.Dequeue();
        avaliableChars.Enqueue(character);
        text.text = character.ToString().ToUpper();

        IsCharacterCorrect = correctCharacter.ToString().ToUpper() == character.ToString().ToUpper();
        OnCharacterChange?.Invoke();
    }
}
