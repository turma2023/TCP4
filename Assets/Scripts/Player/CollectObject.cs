using UnityEngine;

public class CollectObject : MonoBehaviour
{
    private bool isMouse;
    private Inventory inventory;

    private ExamineMode examineMode;



    void Start()
    {
        inventory = GetComponent<Inventory>();
        examineMode = GetComponent<ExamineMode>();
    }


    void Update()
    {
        if (!examineMode.IsExamineMode) return;

        if (Input.touchCount > 0) isMouse = false;

        if (Input.GetMouseButtonDown(0)) isMouse = true;

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetMouseButtonDown(0))
        {
            Ray ray;
            if (!isMouse)
            {
                ray = examineMode.ExamineCamera.ScreenPointToRay(Input.GetTouch(0).position);
            }
            else
            {
                ray = examineMode.ExamineCamera.ScreenPointToRay(Input.mousePosition);
            }

            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 2f);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.layer == LayerMask.NameToLayer("CollectibleObject"))
                {
                    
                    if (hit.collider.GetComponent<Key>() != null)
                    {
                        Key key = hit.collider.GetComponent<Key>();
                        if (!key.isCollected)
                        {
                            key.isCollected = true;
                            GameObject keyObject = key.gameObject;
                            inventory.keys.Add(keyObject);
                            key.gameObject.SetActive(false);
                            // Destroy(key.gameObject);

                        }
                    }
                    // else if (hit.collider.GetComponent<Letter>() != null)
                    // {
                    //     Letter letter = hit.collider.GetComponent<Letter>();
                    //     if (!letter.isCollected)
                    //     {
                    //         inventory.letters.Add(letter);
                    //         letter.isCollected = true;
                    //         Destroy(hit.collider.gameObject);
                    //         Debug.Log("Carta coletada: " + letter.name);
                    //     }
                    // }
                }
            }
        }
    }
}
