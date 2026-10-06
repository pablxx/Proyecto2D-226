using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public List<InventarioCantidad> itemsInventario;
    public GameObject inventarioUI;



}

[System.Serializable]
public class InventarioCantidad
{
    public Item item;
    public int cantidad;
}