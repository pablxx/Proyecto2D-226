using UnityEngine;

public class PlayerBomber : MonoBehaviour
{
    [SerializeField] Rigidbody2D cuerpoBomb;
    [SerializeField] float velocidadBomb = 2f;

    [SerializeField] GameObject objBomba;
    [SerializeField] int cantidadActualBombas = 0;
    [SerializeField] int cantidadMaxBombas = 2;
    [SerializeField] bool puedoPonerBomba;

    //[SerializeField] GameObject bombaActual;
    //[SerializeField] BoxCollider2D colBombaActual;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direccionMov = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        cuerpoBomb.linearVelocity = direccionMov * velocidadBomb;

        //puedoPonerBomba = cantidadActualBombas < cantidadMaxBombas ? true : false;

        if (cantidadActualBombas < cantidadMaxBombas)
        {
            puedoPonerBomba = true;
        }
        else
        {
            puedoPonerBomba = false;
        }

        if (Input.GetKeyDown(KeyCode.Space) && puedoPonerBomba)
        {
            Instantiate(objBomba, transform.position, transform.rotation);
            //bombaActual = Instantiate(objBomba, transform.position, transform.rotation);
            //colBombaActual = bombaActual.GetComponent<BoxCollider2D>();
            cantidadActualBombas++;    
        }
    }

}
