using UnityEngine;

[CreateAssetMenu(fileName = "ItemEquipable", menuName = "Items/Equipable")]
public class ItemEquipable : Item
{
    public TipoEquipable tipoEquipable;
    public override void DesecharItem()
    {
        Debug.Log($"Desechando {itemNombre} que es un {tipoEquipable}");
    }

    public override void UsarItem()
    {

        Debug.Log($"Usando {itemNombre} que es un {tipoEquipable}");
    }

    public void Equipar()
    {
        Debug.Log($"Equipando {itemNombre} que es un {tipoEquipable}");
    }

    public void DesEquipar()
    {
        Debug.Log($"Desequipando {itemNombre} que es un {tipoEquipable}");
    }
}

public enum TipoEquipable
{
    ArmaMelee,
    ArmaRango,
    Armadura,
    Otro
}
