using UnityEngine;

public class EnemyBomber : MonoBehaviour
{
    [SerializeField] Rigidbody2D cuerpoEnemy;
    [SerializeField] Direcciones direccionActual;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //direccionActual = Direcciones.Random.Range(0, 4);
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 direccionMov = Vector2.zero;
        switch (direccionActual)
        {
            case Direcciones.L:
                direccionMov = Vector2.left;
                break;
            case Direcciones.R:
                direccionMov = Vector2.right;
                break;
            case Direcciones.U:
                direccionMov = Vector2.up;
                break;
            case Direcciones.D:
                direccionMov = Vector2.down;
                break;
        }


        cuerpoEnemy.linearVelocity = direccionMov * 3f;
    }
}

public enum Direcciones
{
    L, R, U, D
}
