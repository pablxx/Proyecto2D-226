using UnityEngine;

public class CreepManager : MonoBehaviour
{
    [SerializeField] float tiempoEntreOleadas = 5f; 
    [SerializeField] int oleadaActual = 0;

    [SerializeField] float tiempoRestante = 0f;
    [SerializeField] bool instanciandoOleada = false;
    private void Update()
    {
        if (tiempoRestante > 0)
        {
            tiempoRestante -= Time.deltaTime;
        }
        else
        {
            instanciandoOleada = true;
        }
    }

    void TryInstanciarOleada()
    {
        //sale una oleada diferente cada 4 oleadas
        if (oleadaActual % 4 == 0)
        {
            InstanciarOleadaEspecial();
        }
        else
        {
            InstanciarOleadaNormal();
            // Instanciar oleada normal
        }

    }

    void InstanciarOleadaEspecial()
    {
        // Lógica para instanciar una oleada especial
        ResetOleada();
    }

    void InstanciarOleadaNormal()
    {
        // Lógica para instanciar una oleada normal
        ResetOleada();
    }
    private void ResetOleada()
    {
        instanciandoOleada = false;
        tiempoRestante = tiempoEntreOleadas;
    }
}
