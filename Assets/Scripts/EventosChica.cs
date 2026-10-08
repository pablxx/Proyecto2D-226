using UnityEngine;

public class EventosChica : MonoBehaviour
{
    public ControlChica ctrlChica;

    public void IniciarDisparo()
    {
        ctrlChica.Disparar();
    }

    public void FinalizarDisparo()
    {
        ctrlChica.disparando = false;
        ctrlChica.luzPistola.enabled = false;
    }

    public void IniciarDesliz()
    {
        Debug.Log("evento desliz");
        ctrlChica.IniciarDesliz();
    }

    public void FinalizarDesliz()
    {
        ctrlChica.FinalizarDesliz();
    }
}
