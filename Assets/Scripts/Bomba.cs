using System.Collections;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] float tiempoExplosion;
    [SerializeField] SpriteRenderer spriteBomba;
    [SerializeField] float distanciaBomba;
    [SerializeField] LayerMask capaDeteccion;

    private void Start()
    {
        StartCoroutine(ExplosionBomba());
    }

    IEnumerator ExplosionBomba()
    {
        yield return new WaitForSeconds(tiempoExplosion);
        spriteBomba.enabled = false;
        DetectarColisionesIzq();
        DetectarColisionesDer();
        DetectarColisionesUp();
        DetectarColisionesDown();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.left * distanciaBomba);
    }
    void DetectarColisionesIzq()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, Vector2.left, distanciaBomba, capaDeteccion);
        if (hit.Length > 0)
        {
           for (int i = 0; i < hit.Length; i++) {
                Debug.Log("destruyendo " + hit[i].transform.name);
                Destroy(hit[i].transform.gameObject);
            }
        }
    }
    void DetectarColisionesDown()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, Vector2.down, distanciaBomba, capaDeteccion);
        if (hit.Length > 0)
        {
            for (int i = 0; i < hit.Length; i++)
            {
                Debug.Log("destruyendo " + hit[i].transform.name);
                Destroy(hit[i].transform.gameObject);
            }
        }
    }
    void DetectarColisionesDer()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, Vector2.right, distanciaBomba, capaDeteccion);
        if (hit.Length > 0)
        {
            for (int i = 0; i < hit.Length; i++)
            {
                Debug.Log("destruyendo " + hit[i].transform.name);
                Destroy(hit[i].transform.gameObject);
            }
        }
    }
    void DetectarColisionesUp()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, Vector2.up, distanciaBomba, capaDeteccion);
        if (hit.Length > 0)
        {
            for (int i = 0; i < hit.Length; i++)
            {
                Debug.Log("destruyendo " + hit[i].transform.name);
                Destroy(hit[i].transform.gameObject);
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            boxCollider.isTrigger = false;
            
        }
    }
}
