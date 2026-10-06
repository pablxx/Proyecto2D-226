using UnityEngine;


[CreateAssetMenu(fileName = "ItemConsumible", menuName = "Items/Consumible")]
public class ItemConsumible : Item
{
    
    public TipoConsumible tipoConsumible;
    public int precioItem;
    public int cantidadEfecto;

    public override void DesecharItem()
    {
        Debug.Log($"Desechando {itemNombre} que es un {tipoConsumible}");
    }

    public override void UsarItem()
    {
        Debug.Log($"Usando {itemNombre} que es un {tipoConsumible} y tiene un efecto de {cantidadEfecto}");
    }

    public void Combinar()
    {
        Debug.Log($"Combinando {itemNombre} que es un {tipoConsumible} y tiene un efecto de {cantidadEfecto}");
    }
}

public enum TipoConsumible
{
    Salud,
    Energia,
    Pocion,
    Otro
}
