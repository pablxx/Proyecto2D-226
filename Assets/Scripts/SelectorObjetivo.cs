using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class SelectorObjetivo : MonoBehaviour
{

    InputSystem_Actions inputActions;
    public LayerMask capaUnidades;

    public GameObject objetivoActual;
    //public GameObject objetivoAnterior;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        inputActions.Player.OnClick.performed += OnClick;
    }

    private void OnDisable()
    {
        inputActions.Enable();
        inputActions.Player.Move.performed += OnClick;
    }

    private void OnClick(InputAction.CallbackContext context)
    {

        Vector2 posicionPantalla = Pointer.current.position.ReadValue();
        //Debug.Log("posPantalla " + posicionPantalla);
        Vector3 posicionMundo = Camera.main.ScreenToWorldPoint(posicionPantalla);

        RaycastHit2D hit = Physics2D.Raycast(posicionMundo, Vector2.zero, 0f, capaUnidades);

        if (hit.collider != null)
        {
            Debug.Log("Seleccione a " + hit.collider.name);
            if (objetivoActual == null)
            {
                if (hit.collider.transform.TryGetComponent(out Seleccionable seleccionable))
                {
                    objetivoActual = hit.collider.gameObject;
                    seleccionable.Seleccionar();
                }

            }
            else
            {
                if (hit.collider.transform.TryGetComponent(out Seleccionable seleccionable))
                {
                    objetivoActual.GetComponent<Seleccionable>().Deseleccionar();
                    objetivoActual = hit.collider.gameObject;
                    seleccionable.Seleccionar();

                }
                
            }
            
        }

    }
}
