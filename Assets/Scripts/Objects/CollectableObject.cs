using Unity.VisualScripting;
using UnityEngine;

public enum CollectableType { None, Key, Letter, Flower, Crowbar, Diary, Perfume, }
public class CollectableObject : MonoBehaviour
{
    [field: SerializeField] public string Name { get; protected set; }
    public CollectableType CollectableType {  get; protected set; }
    public bool IsCollected { get; set; }

    public void DisableObject()
    {
        gameObject.SetActive(false);
    }
    

}
