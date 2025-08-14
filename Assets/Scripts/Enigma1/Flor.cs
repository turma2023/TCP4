using UnityEngine;

public class Flor : MonoBehaviour
{

    public bool isPerfumed = false;
    public bool isCollected = false;
    public string nome = "Flor";
    private ParticleSystem particles;
    void Start()
    {
        particles = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPerfumed && Input.GetKeyDown(KeyCode.P))
        {
            particles.Play();
        }
    }

    public void Borrifar()
    {
        isPerfumed = true;
        Debug.Log("Flor borrifada com perfume!");
    }

}
