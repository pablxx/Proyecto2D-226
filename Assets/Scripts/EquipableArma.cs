using UnityEngine;

[CreateAssetMenu(fileName = "NuevaArma", menuName = "Items/Arma")]
public class EquipableArma : ItemEquipable
{
    public TipoArma tipoArma;
    public float daño;
    public float alcance;

}

public enum TipoArma
{
    Daga,
    Espada,
    Hacha,
    Arco,
}
