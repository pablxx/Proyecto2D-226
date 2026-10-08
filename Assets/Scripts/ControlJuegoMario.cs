using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlJuegoMario : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            SceneManager.LoadScene("EscenaMario2");
        }
    }
    
}
