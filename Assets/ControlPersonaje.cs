using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class ControlPersonaje : MonoBehaviour
{
    private NavMeshAgent agente;
    private InputSystem_Actions inputActions;
    
    void Awake()
    {
        agente = GetComponent<NavMeshAgent>();

        inputActions = new InputSystem_Actions();

        agente.updateRotation = false;
        agente.updateUpAxis = false;
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
        Debug.Log("posPantalla " + posicionPantalla);
        Vector3 posicionMundo = Camera.main.ScreenToWorldPoint(posicionPantalla);

        //mover al agente a la posición del mundo
        posicionMundo.z = transform.position.z;
        agente.SetDestination(posicionMundo);

    }
}
