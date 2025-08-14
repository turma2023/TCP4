using UnityEngine;

public class Flor : CollectableObject
{

    public bool isPerfumed = false;
    private ParticleSystem particles;
    void Start()
    {
        particles = GetComponent<ParticleSystem>();
        CollectableType = CollectableType.Flower;
    }

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
