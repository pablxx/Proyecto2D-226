using UnityEngine;

[CreateAssetMenu(fileName = "Nuevo Personaje", menuName = "MOBA/Personaje")]
public class DatosPersonaje : ScriptableObject
{
    public string nombre;
    public string alias;
    public Faccion faccion;
    public TipoAtaque tipoAtaque;
    public AtributoPrincipal atributoPrincipal;

    public float manaBase;
    public float saludBase;

    public Estadisticas estadisticas;

    public Sprite imagen;
    public GameObject prefab;
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

