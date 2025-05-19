using UnityEngine;
using System.Collections;

public class MoveToObject : MonoBehaviour
{
    private Transform player;
    private InputController inputController;
    public float speed = 5f;
    private bool isMoving;
    private bool isMouse;

    void Start()
    {
        player = GetComponent<Transform>();
        inputController = GetComponent<InputController>();
    }

    void Update()
    {
        if (Input.touchCount > 0) isMouse = false;
        
        if (Input.GetMouseButtonDown(0)) isMouse = true;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0) && !isMoving)
        {


            Ray ray;
            if (!isMouse)
            {
                ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            }
            else
            {
                ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            }
        // if (inputController.Click.WasPressedThisFrame() && !isMoving)
        // {
        //     Debug.Log("Clique detectado");
        //     Vector2 clickPosition = inputController.Click.ReadValue<Vector2>(); // Obtém a posição do clique/toque
        //     Ray ray = Camera.main.ScreenPointToRay(clickPosition);

            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 2f);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("ClickMove"))
                {
                    StopCoroutine("MovePlayer");
                    StartCoroutine(MovePlayer(hit.collider));
                }
            }
        }
    }

    IEnumerator MovePlayer(Collider objeto)
    {
        isMoving = true;
        float distanciaSegura = 1.5f;

        Vector3 centroObjeto = objeto.bounds.center;
        Vector3 direcao = (centroObjeto - player.position).normalized;
        Vector3 distanciaObject = centroObjeto - (direcao * distanciaSegura);
        Vector3 destinoAjustado = new Vector3(distanciaObject.x, player.position.y, distanciaObject.z);


        while (Vector3.Distance(player.position, destinoAjustado) > 0.4f)
        {
            player.position = Vector3.Lerp(player.position, destinoAjustado, speed * Time.deltaTime);
            yield return null;
        }

        isMoving = false;
    }
}
