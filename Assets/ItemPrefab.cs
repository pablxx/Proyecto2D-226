using UnityEngine;

public class ItemPrefab : MonoBehaviour
{
    public Item itemInfo;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Inventario.Instance.AgregarItem(itemInfo);
            Destroy(gameObject);
        }
    }
}
