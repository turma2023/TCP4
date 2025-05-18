using UnityEngine;
using System.Collections;

public class MoveToObject : MonoBehaviour
{
    private Transform player;
    public float speed = 5f;
    private bool isMoving = false;

    void Start()
    {
        player = GetComponent<Transform>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isMoving)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
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
