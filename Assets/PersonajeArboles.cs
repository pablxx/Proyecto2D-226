using UnityEngine;

public class PersonajeArboles : MonoBehaviour
{
    public Rigidbody2D cuerpo;
    public Animator animador;
    public float velocidadBase = 5f;
    public float velocidadPuntas = 0.5f;

    public bool caminando;
    public bool dePuntas;
    public bool strafing;

    //para forzar ultima direccion presionada y que no se vaya a 0,0
    Vector2 ultimaDireccion;

    private void Start()
    {
        ultimaDireccion = Vector2.zero; // Inicializa la última dirección como centro
        cuerpo = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector2 entradaJugador = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //ultimaDireccion = entradaJugador.normalized;
        ultimaDireccion = entradaJugador != Vector2.zero ? entradaJugador.normalized : ultimaDireccion;

        dePuntas = Input.GetKey(KeyCode.LeftShift) ? true : false;

        float velocidadActual = dePuntas ? velocidadBase * velocidadPuntas : velocidadBase;

        Vector2 nuevaDireccion = dePuntas? ultimaDireccion * velocidadPuntas : ultimaDireccion;

        if (entradaJugador != Vector2.zero)
        {
             // Actualiza la última dirección presionada
            caminando = true;
            cuerpo.linearVelocity = ultimaDireccion * velocidadActual;
        }
        else
        {
            caminando = false;
            cuerpo.linearVelocity = Vector2.zero;
        }
        
        
        animador.SetBool("caminando", caminando);
        animador.SetFloat("velX", nuevaDireccion.x);
        animador.SetFloat("velY", nuevaDireccion.y);
    }

}
