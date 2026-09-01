using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class ControlEscenas : MonoBehaviour
{
    public static ControlEscenas Instancia;

    public bool cambiandoEscenas;

    public GameObject objJugador;

    private void Awake()
    {
        if (Instancia != null)
            Destroy(gameObject);
        else
            Instancia = this;

        DontDestroyOnLoad(gameObject);
    }

    public void CambiarEscena(string escenaObjetivo)
    {
        if (!cambiandoEscenas)
        {
            cambiandoEscenas = true;
            StartCoroutine(RutinaCambiarEscena(escenaObjetivo));
        }
    }

    IEnumerator RutinaCambiarEscena(string escenaObjetivo)
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(escenaObjetivo);
        yield return new WaitForSeconds(2f);

        cambiandoEscenas = false;
        objJugador.transform.position = Vector3.zero;
    }
}
