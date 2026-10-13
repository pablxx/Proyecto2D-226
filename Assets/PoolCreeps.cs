using UnityEngine;
using UnityEngine.Pool;

public class PoolCreeps : MonoBehaviour
{
    public static PoolCreeps Instance { get; private set; }
    public ObjectPool<GameObject> creepPoolMelee;
    public ObjectPool<GameObject> creepPoolRango;
    public ObjectPool<GameObject> creepPoolCatapulta;

    public GameObject creepMeleePrefab;
    [SerializeField]
    private int cantidadMinima = 30;
    [SerializeField]
    private int cantidadMaxima = 60;


    //EJEMPLO
    GameObject creepActual;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Initialize pool early so other Awake/Start can use it
        creepPoolMelee = new ObjectPool<GameObject>(CrearCreep,
                                                    ObtenerCreep,
                                                    DevolverCreep,
                                                    DestruirCreep,
                                                    true, cantidadMinima, cantidadMaxima);

        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            creepActual = creepPoolMelee.Get();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            creepPoolMelee.Release(creepActual);
        }
    }

    private void Start()
    {
        PrecargarPool(cantidadMinima);
    }

    public void PrecargarPool(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var nuevoCreep = creepPoolMelee.Get();
            nuevoCreep.SetActive(false);
        }
    }

    private GameObject CrearCreep()
    {
        GameObject creep = Instantiate(creepMeleePrefab, transform.position, transform.rotation);
        creep.SetActive(false);
        return creep;
    }

    private void ObtenerCreep(GameObject creep)
    {
        //MOVER AL CREEP A LA POSICION DE SPAWN
        //creep.transform.position = spawnPosition; // Asegúrate de definir spawnPosition en tu clase
        creep.SetActive(true);
    }

    private void DevolverCreep(GameObject creep)
    {
        
        creep.SetActive(false);
        //MOVER AL CREEP A UNA POSICION FUERA DE LA PANTALLA O A UN LUGAR DE ESPERA
        //creep.transform.position = new Vector3(1000, 1000, 1000); // Ejemplo de posición fuera de la pantalla
    }

    private void DestruirCreep(GameObject creep)
    {
        Destroy(creep);
    }
}