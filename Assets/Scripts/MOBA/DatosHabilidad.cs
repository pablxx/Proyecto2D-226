using UnityEngine;

[CreateAssetMenu(fileName = "Nueva Habilidad", menuName = "MOBA/Habilidad")]
public abstract class DatosHabilidad : ScriptableObject
{
    public string nombre;
    public float cooldown;
    public float duracion;
    public float rango;
    public float efecto;
    public float costo;
    public GameObject prefab;
    public Sprite imagen;
    public TipoHabilidad tipoHabilidad;
    public TipoEfecto tipoEfecto;

    public abstract void EjecutarHabilidad();
    public abstract void DetenerHabilidad();
    public abstract void HabilidadPasiva();
}

public enum TipoHabilidad
{
    Activa,
    Instantanea,
    PasivaContinua,
    PasivaTrigger
}

public enum TipoEfecto
{
    Naturaleza,
    Sombras,
    Divino,
    Cura,
    Fisico,
    Arcano
}


