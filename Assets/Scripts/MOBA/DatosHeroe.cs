using UnityEngine;

[CreateAssetMenu(fileName = "Nuevo Heroe", menuName = "MOBA/Heroe")]
public class DatosHeroe : ScriptableObject
{
    public string nombre;
    public string alias;
    public Faccion faccion;
    public TipoAtaque tipoAtaque;
    public AtributoPrincipal atributoPrincipal;

    public float manaBase;
    public float saludBase;
    public float cadenciaAtaqueBase;
    public float rangoAtaqueBase;

    public Estadisticas estadisticas;

    public Sprite imagen;
    public GameObject prefab;

    [Header("Las 4 Habilidades Obligatorias (1, 2, 3, 6)")]
    public DatosHabilidad[] habilidades = new DatosHabilidad[4];

    private void OnValidate()
    {
        if (habilidades.Length != 4)
        {
            System.Array.Resize(ref habilidades, 4);
        }
    }
}

public enum Faccion
{
    Sentinel,
    Scourge
}

public enum TipoAtaque
{
    Rango,
    Melee
}

public enum AtributoPrincipal
{
    Fuerza,
    Agilidad,
    Inteligencia
}

