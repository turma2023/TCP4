using UnityEngine;
using System.Collections;

public class MoveToObject : MonoBehaviour
{
    private Transform player;
    private InputController inputController;
    public float speed = 50f;
    private bool isMoving;
    private bool isMouse;

    private ExamineMode examineMode;

    [field:SerializeField] public bool CanMove { get; set; } = true;

    void Start()
    {
        player = GetComponent<Transform>();
        inputController = GetComponent<InputController>();
        examineMode = GetComponent<ExamineMode>();
    }

    void LateUpdate()
    {
        if (!CanMove) return;
        if (examineMode.IsExamineMode) return;

        if (Input.touchCount > 0) isMouse = false;

        if (Input.GetMouseButtonDown(0)) isMouse = true;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0) && !isMoving)
        {


            Ray ray;
            if (!isMouse)
            {
                ray = examineMode.MainCamera.ScreenPointToRay(Input.GetTouch(0).position);
            }
            else
            {
                ray = examineMode.MainCamera.ScreenPointToRay(Input.mousePosition);
            }
            // if (inputController.Click.WasPressedThisFrame() && !isMoving)
            // {
            //     Debug.Log("Clique detectado");
            //     Vector2 clickPosition = inputController.Click.ReadValue<Vector2>(); // Obtém a posição do clique/toque
            //     Ray ray = Camera.main.ScreenPointToRay(clickPosition);

            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 2f);
            RaycastHit[] hits = Physics.RaycastAll(ray, 200);

            foreach (var hitted in hits)
            {
                if (hitted.collider.gameObject.layer == LayerMask.NameToLayer("ClickMove"))
                {
                    StopCoroutine("MovePlayer");
                    Debug.Log(hitted.collider.gameObject.name);
                    StartCoroutine(MovePlayer(hitted.collider));
                }
            }
        }
    }

    IEnumerator MovePlayer(Collider objeto)
    {
        if (!CanMove) yield break;
        isMoving = true;
        float distanciaSegura = 1.5f;
        float toleranciaRotacao = 0.05f;

        Vector3 centroObjeto = objeto.bounds.center;
        Vector3 direcaoCompleta = (centroObjeto - player.position).normalized;

        Vector3 direcaoY = new Vector3(direcaoCompleta.x, 0f, direcaoCompleta.z).normalized;

        Vector3 distanciaObject = centroObjeto - (direcaoCompleta * distanciaSegura);
        Vector3 destinoAjustado = new Vector3(distanciaObject.x, player.position.y, distanciaObject.z);

        // Rotação
        Quaternion rotacaoY = Quaternion.LookRotation(direcaoY);
        while (Quaternion.Angle(player.rotation, Quaternion.Euler(0f, rotacaoY.eulerAngles.y, 0f)) > toleranciaRotacao)
        {
            Quaternion rotacaoAtualY = Quaternion.Euler(0f, player.rotation.eulerAngles.y, 0f);
            Quaternion rotacaoFinalY = Quaternion.Euler(0f, rotacaoY.eulerAngles.y, 0f);
            player.rotation = Quaternion.Slerp(rotacaoAtualY, rotacaoFinalY, speed * Time.deltaTime);
            yield return null;
            if (!CanMove) yield break;
        }

        // Movimentação
        while (Vector3.Distance(player.position, destinoAjustado) > 0.4f)
        {
            player.position = Vector3.Lerp(player.position, destinoAjustado, speed * Time.deltaTime);
            yield return null;
        }

        objeto.gameObject.TryGetComponent(out EnableReturnButton returnButton);
        objeto.gameObject.TryGetComponent(out Door door);
        gameObject.TryGetComponent(out Inventory inventory);

        if (returnButton != null)
        {

            if (door != null)
            {
                if (inventory.keys.Count <= 0 || door.isOpen)
                {
                    returnButton.EnableReturn();
                     isMoving = false;
                    yield break;
                }
            }

            returnButton.EnableReturn();
        }



        isMoving = false;
    }

}
