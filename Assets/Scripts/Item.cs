using UnityEngine;

[System.Serializable]
public abstract class Item : ScriptableObject
{
    public string itemNombre;
    public string itemDescripcion;
    public Sprite itemIcono;
    public GameObject itemPrefab;

    public abstract void UsarItem();
    public abstract void DesecharItem();

}

