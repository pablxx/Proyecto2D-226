using UnityEngine;

public class Heroe : MonoBehaviour
{
    public DatosHeroe datosHeroe;
    
    void Start()
    {
        GameObject nuevoHeroe = Instantiate(datosHeroe.prefab, transform.position, Quaternion.identity);
        nuevoHeroe.transform.SetParent(transform);


    }

}

