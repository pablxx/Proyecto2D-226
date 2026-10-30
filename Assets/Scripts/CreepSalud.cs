using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class CreepSalud : MonoBehaviour, IDamageable
{
    float saludActual = 100f;

    public Slider barraSalud;

    private void Start()
    {
        //pasarle valor negativo para dañar y positivo para curar
        AplicarDOT(4f, 10f, 5f); // Ejemplo de aplicación de DOT al inicio
    }

    public void AplicarDanoInstantaneo(float daño)
    {
        saludActual -= daño;
        if (saludActual <= 0)
        {
            // Lógica de muerte del creep
            Debug.Log("El creep ha muerto.");
        }
    }

    public void AplicarDOT(float duracion, float daño, float frecuencia)
    {
        StartCoroutine(RutinaDOT(duracion, daño, frecuencia));
    }

    public IEnumerator RutinaDOT(float duracion, float daño, float frecuencia)
    {
        while (duracion > 0)
        {
            duracion -= Time.deltaTime * 4f;
            Debug.Log("tiempo restante: " + duracion);
            saludActual -= daño;
            barraSalud.value = saludActual;
            yield return new WaitForSeconds(frecuencia);
        }
        Debug.Log("DOT terminado");

    }
}
