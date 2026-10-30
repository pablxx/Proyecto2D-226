using System;
using UnityEngine;

public class HeroeCombate : MonoBehaviour
{
    [SerializeField] EstadoCombate estadoActual;
    [SerializeField] HeroeMovimiento heroeMovimiento;

    [SerializeField] float cadenciaAtaqueBase;
    [SerializeField] float cadenciaAtaqueActual;
    [SerializeField] float rangoAtaqueBase;
    [SerializeField] float rangoAtaqueActual;

    public void CambiarEstadoHeroe(EstadoCombate estadoObjetivo)
    {
        estadoActual = estadoObjetivo;

        switch (estadoObjetivo)
        {
            case EstadoCombate.Estuneado:
                break;
            case EstadoCombate.Ralentizado:
                RalentizarHeroe();
                break;
            case EstadoCombate.Silenciado:
                break;
            case EstadoCombate.Dormido:
                break;
            case EstadoCombate.DOTeado:
                break;
            default:
                break;
        }
    }

    private void RalentizarHeroe()
    {
        //heroeMovimiento.Ralentizar(0.5f); // Ralentiza al héroe al 50% de su velocidad
    }

    private void SilenciarHeroe()
    {
        //heroeMovimiento.Silenciar(); // Silencia al héroe, impidiendo que use habilidades
    }

    private void EstunearHeroe()
    {
        //heroeMovimiento.Estunear(); // Estunea al héroe, impidiendo que se mueva o use habilidades
    }
}

public enum EstadoCombate
{
    Normal,
    Estuneado,
    Ralentizado,
    Silenciado,
    Dormido,
    DOTeado
}
