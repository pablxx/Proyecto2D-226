using System.Collections;
using UnityEngine;

public class HeroeSalud : MonoBehaviour, IDamageable
{
    [SerializeField] private float saludActual = 100f;


    //EVALUAR RESISTENCIAS Y DEMAS DATOS QUE TENGA SOLO EL HEROE, PARA APLICAR EL DAÑO CORRECTAMENTE
    public void AplicarDanoInstantaneo(float daño)
    {
        saludActual -= daño;
        if (saludActual <= 0)
        {
            // Lógica de muerte del héroe
            Debug.Log("El héroe ha muerto.");
        }
    }

    public void AplicarDOT(float duracion, float daño, float frecuencia)
    {
         StartCoroutine(RutinaDOT(duracion, daño, frecuencia));
    }

    public IEnumerator RutinaDOT(float duracion, float daño, float frecuencia)
    {
        while (Time.realtimeSinceStartup < duracion)
        {
            // Aplicar daño
            // Reducir duracion

            duracion -= Time.deltaTime;
            saludActual -= daño;
            yield return new WaitForSeconds(frecuencia);
        }
    }
}
