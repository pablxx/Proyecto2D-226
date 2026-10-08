using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public static Inventario Instance;

    public List<InventarioCantidad> itemsInventario;

    public Action OnItemAdded;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void AgregarItem(Item itemInfo)
    {
        foreach (var itemEnInventario in itemsInventario)
        {
            if (itemEnInventario.item.itemNombre == itemInfo.itemNombre)
            {
                itemEnInventario.cantidad++;
                return;
            }
        };
        InventarioCantidad nuevoItem = new InventarioCantidad(itemInfo, 1);
        itemsInventario.Add(nuevoItem);

        OnItemAdded();
    }
}

[System.Serializable]
public class InventarioCantidad
{
    public Item item;
    public int cantidad;

    public InventarioCantidad(Item nuevoItem, int cantidadItem)
    {
        item = nuevoItem;
        cantidad = cantidadItem;
    }
}