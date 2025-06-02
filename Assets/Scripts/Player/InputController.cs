using UnityEngine;
using UnityEngine.InputSystem;
public class InputController : MonoBehaviour
{

    private PlayerInput playerInput;
    public InputAction Click => playerInput.actions["Touch"];

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

}
