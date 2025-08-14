using UnityEngine;

public class Diario : CollectableObject
{
    public bool isOpen;
    void Start()
    {
        CollectableType = CollectableType.Diary;
    }
}
