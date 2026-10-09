using System.Collections;
using UnityEngine;

public class ControlHuesos2D : MonoBehaviour
{
    float velocidadMov = 5f;
    public Animator animH;
    public Rigidbody2D rb;

    public GameObject objPistola;
    public bool cambiandoArma = false;

    void Start()
    {
        
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (horizontal != 0)
        {
            rb.linearVelocityX = velocidadMov * horizontal;
            animH.SetBool("corriendo", true);
        }
        else
        {
            animH.SetBool("corriendo", false);
        }


        if (transform.localScale.x > 0 && horizontal < 0 || transform.localScale.x < 0 && horizontal > 0)
        {
            Flip();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && !cambiandoArma)
        {
            if (animH.GetLayerWeight(1) == 0)
            {
                cambiandoArma = true;
                StartCoroutine(CambiarArma(1));
            }
            else
            {
                cambiandoArma = true;
                StartCoroutine(CambiarArma(0));
            }
        }
    }

    IEnumerator CambiarArma(int pesoObjetivo)
    {
        while (cambiandoArma)
        {
            float nuevoPeso = Mathf.MoveTowards(animH.GetLayerWeight(1), pesoObjetivo, Time.deltaTime * 4);
            //Debug.Log("nuevo peso: " + nuevoPeso);
            if (nuevoPeso != pesoObjetivo)
            {
                animH.SetLayerWeight(1, nuevoPeso);
            }
            else
            {
                animH.SetLayerWeight(1, pesoObjetivo);
                cambiandoArma = false;
            }
            yield return null;
        }

        if (objPistola.activeSelf)
        {
            objPistola.SetActive(false);
        }
        else
        {
            objPistola.SetActive(true);
        }
    }

void Flip() {         
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
}
