using UnityEngine;

public class CameraExamine : MonoBehaviour
{
    [Header("Configurações da Câmera")]
    [SerializeField] private float sensibilidadeVertical = 5f; // Ajuste a sensibilidade conforme necessário
    [SerializeField] private float limiteRotacaoVerticalInferior = -90f; // Limite inferior da rotação vertical
    [SerializeField] private float limiteRotacaoVerticalSuperior = 90f;  // Limite superior da rotação vertical

    private float rotacaoAtualVertical = 0f; // Rotação vertical atual da câmera

    void Start()
    {
        // Opcional: Travar o cursor no centro da tela e ocultá-lo no início do jogo
        // Isso é comum para jogos em primeira pessoa.
        // Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = true;
    }

    void Update()
    {
        HandleCameraRotation();
    }

    private void HandleCameraRotation()
    {
        float inputVertical = 0f;

        // Verifica o input de toque (para dispositivos móveis)
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Pega o primeiro toque

            if (touch.phase == TouchPhase.Moved)
            {
                // Usa o deltaPosition.y para o movimento vertical do toque
                inputVertical = -touch.deltaPosition.y * sensibilidadeVertical * Time.deltaTime;
            }
        }
        // Verifica o input do mouse (para testes no editor ou jogos de PC)
        else
        {
            // Usa Input.GetAxis("Mouse Y") para o movimento vertical do mouse
            // Multiplicamos por Time.deltaTime para suavizar a rotação com base no tempo de frame
            inputVertical = -Input.GetAxis("Mouse Y") * sensibilidadeVertical * Time.deltaTime;
        }

        // Atualiza a rotação vertical atual
        rotacaoAtualVertical += inputVertical;

        // Clampa (limita) a rotação vertical para evitar que a câmera dê um giro completo
        rotacaoAtualVertical = Mathf.Clamp(rotacaoAtualVertical, limiteRotacaoVerticalInferior, limiteRotacaoVerticalSuperior);

        // Aplica a rotação ao transform da câmera.
        // Quaternion.Euler cria uma rotação a partir de ângulos de Euler.
        // Mantemos a rotação Y (yaw) e Z (roll) em 0 para uma rotação puramente vertical.
        transform.localRotation = Quaternion.Euler(rotacaoAtualVertical, 0f, 0f);
    }
}