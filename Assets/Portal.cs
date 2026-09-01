using UnityEngine;

public class Portal : MonoBehaviour
{
    [SerializeField] string escenaObjetivo;

    private void Awake()
    {
        escenaObjetivo = gameObject.name;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            //le avisamos al control de puertas que nos mueva
            ControlEscenas.Instancia.CambiarEscena(escenaObjetivo);
        }
    }
}
