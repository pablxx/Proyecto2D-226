using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class InventarioUI : MonoBehaviour
{
    public GameObject grillaItems;

    public List<GameObject> slots;

    public GameObject inventarioUI;

    private void Start()
    {
        //Cargamos los elementos de la UI
        CargarGrillaItems();
        //Cargar los items en los slots
        CargarItemsEnSlots();

        Debug.Log("cargando inventario...");
    }

    void CargarGrillaItems()
    {
        slots = new List<GameObject>();

        for (int i = 0; i < grillaItems.transform.childCount; i++)
        {
            slots.Add(grillaItems.transform.GetChild(i).gameObject);
            
        }
    }

    void CargarItemsEnSlots()
    {
        for (int i = 0; i < Inventario.Instance.itemsInventario.Count; i++)
        {
            var itemObjetivo = Inventario.Instance.itemsInventario[i];
            
            GameObject slotObjetivo = slots[i];
            //obtenemos el objeto que contiene la imagen
            GameObject objImg = slotObjetivo.transform.GetChild(0).gameObject;
            slotObjetivo.transform.GetChild(0).GetComponent<Image>().sprite = itemObjetivo.item.itemIcono;
            objImg.SetActive(true);

            //obtenemos el objeto que tiene la cantidad del item
            GameObject objNumero = slotObjetivo.transform.GetChild(1).gameObject;
            slotObjetivo.transform.GetChild(1).GetComponent<TMP_Text>().text = itemObjetivo.cantidad.ToString();
            objNumero.SetActive(true);
        }
    }

    public void ToggleInventario()
    {
        if (inventarioUI.activeSelf)
        {
            inventarioUI.SetActive(false);
        }
        else
        {
            inventarioUI.SetActive(true);
        }
    }
}
