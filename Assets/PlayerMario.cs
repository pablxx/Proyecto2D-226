using UnityEngine;

public class PlayerMario : MonoBehaviour
{
    public Rigidbody2D cuerpo;
    public float fuerzaSalto;
    public float velocidad;
    public bool enEscalera;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float entradaX = Input.GetAxis("Horizontal");
        float entradaY = Input.GetAxis("Vertical");

        if (entradaX != 0)
        {
            cuerpo.linearVelocityX = velocidad * entradaX;
        }
        else
        {
            cuerpo.linearVelocityX = 0f;
        }

        if (Input.GetButtonDown("Jump") && !enEscalera)
        {
            cuerpo.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }

        if (enEscalera && entradaY != 0)
        {
            cuerpo.linearVelocityY = velocidad * 0.5f  * entradaY;
        }
        else if (enEscalera && entradaY == 0)
        {
            cuerpo.linearVelocityY = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("escalera"))
        {
            enEscalera = true;
            cuerpo.gravityScale = 0;
            Debug.Log("estoy en escalera");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("escalera"))
        {
            enEscalera = false;
            cuerpo.gravityScale = 1;
            Debug.Log("sali de una escalera");
        }
    }
}
