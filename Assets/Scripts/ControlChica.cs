using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class ControlChica : MonoBehaviour
{
    [SerializeField] private float velocidad = 4f;
    [SerializeField] private float fuerzaSalto = 6f;
    [SerializeField] private bool pisando;
    [SerializeField] private bool muerto;
    [SerializeField] public bool disparando;

    [SerializeField] Rigidbody2D miCuerpo;

    [SerializeField] Animator miAnimador;

    //Logica de disparo
    //[SerializeField] ProyectilChica proyectil;
    [SerializeField] GameObject proyectilObj;
    [SerializeField] Transform puntaPistola;
    [SerializeField] public Light2D luzPistola;


    //variables para el salto
    [SerializeField] LayerMask capaPiso;
    [SerializeField] float distanciaRayo;
    [SerializeField] Transform posPies;

    [SerializeField] Collider2D colNormal;
    [SerializeField] Collider2D colDeslizar;
    [SerializeField] bool deslizando;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (muerto)
            return;

        float entradaX = Input.GetAxis("Horizontal");
        //Debug.Log("el jugador esta presionando " + entradaX);
        //Debug.Log("tiempo delta " + Time.deltaTime);

        //verificando si el jugador quiere moverse
        if (entradaX != 0 && !disparando)
        {
            //transform.Translate(new Vector2(entradaX * Time.deltaTime * velocidad, 0));
            miCuerpo.linearVelocityX = entradaX * velocidad;

            miAnimador.SetBool("corriendo", true);

            if (transform.localScale.x > 0 && entradaX < 0 || transform.localScale.x < 0 && entradaX > 0)
            {
                GirarPersonaje();
            }
        }
        else
        {
            miAnimador.SetBool("corriendo", false);
        }
        //leyendo la tecla de salto
        if (Input.GetButtonDown("Jump") && pisando)
        {
            //impulse = fuerza instantanea, Force = fuerza continua
            miCuerpo.AddForceY(fuerzaSalto, ForceMode2D.Impulse);
        }

        if (Input.GetButtonDown("Fire1") && !disparando)
        {
            miAnimador.SetTrigger("disparo");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Deslizando");
            deslizando = true;
            miAnimador.SetBool("deslizando", deslizando);
        }

        //actualizamos variables de salto en el animador
        miAnimador.SetBool("pisando", pisando);
        miAnimador.SetFloat("velY", miCuerpo.linearVelocityY);
    }

    public void Disparar()
    {
        luzPistola.enabled = true;
        disparando = true;
        GameObject nuevoProyectil = Instantiate(proyectilObj, puntaPistola.position, puntaPistola.rotation);
        nuevoProyectil.GetComponent<ProyectilChica>().AplicarFuerza(Mathf.Sign(transform.localScale.x));
    }

    void GirarPersonaje()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1f,
                                            transform.localScale.y,
                                            transform.localScale.z);
    }

    private void FixedUpdate()
    {
        DetectarPiso();
    }

    private void DetectarPiso()
    {
        RaycastHit2D hit = Physics2D.Raycast(posPies.position, Vector2.down, distanciaRayo, capaPiso);

        if (hit)
            pisando = true;
        else
            pisando = false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawRay(posPies.position, Vector2.down * distanciaRayo);
    }

    public void IniciarDesliz()
    {
        Debug.Log("iniciando desliz");
        deslizando = true;
        colNormal.enabled = false;
        colDeslizar.enabled = true;
    }

    public void FinalizarDesliz()
    {
        deslizando = false;
        colNormal.enabled = true;
        colDeslizar.enabled = false;
    }

}
