using UnityEngine;

public class Key : CollectableObject
{
    public int keyId;
    public string keyDescription;

    public void Start()
    {
        CollectableType = CollectableType.Key;
    }
}
