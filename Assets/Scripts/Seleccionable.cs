using System;
using UnityEngine;

public class Seleccionable : MonoBehaviour
{
    public void Seleccionar()
    {
        Debug.Log("seleccionando " + transform.name);
        transform.GetChild(0).gameObject.SetActive(true);
    }

    public void Deseleccionar()
    {
        Debug.Log("deseleccionando " + transform.name);
        transform.GetChild(0).gameObject.SetActive(false);
    }
}