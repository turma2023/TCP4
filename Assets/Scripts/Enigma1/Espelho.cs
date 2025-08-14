using UnityEngine;

public class Espelho : MonoBehaviour
{

    private int numClicks = 0;

    [SerializeField] private GameObject flor;

    void Update()
    {
        // if (numClicks > 0) Debug.Log("Numero de cliques: " + numClicks);

        if (numClicks > 3)
        {
            // Debug.Log("Espelho rachou!");
        }

        if (numClicks > 5 && !flor.GetComponent<Flor>().IsCollected)
        {
            // Debug.Log("Espelho quebrou!");
            flor.SetActive(true);
        }

    }

    public void OnTouch()
    {
        numClicks++;
    }

}
