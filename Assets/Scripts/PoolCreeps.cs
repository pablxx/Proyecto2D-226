using UnityEngine;
using UnityEngine.Pool;

public class PoolCreeps : MonoBehaviour
{
    public static PoolCreeps Instance { get; private set; }
    public ObjectPool<GameObject> creepPool;
    //public ObjectPool<GameObject> creepPoolRango;
    //public ObjectPool<GameObject> creepPoolCatapulta;

    [SerializeField] CreepPoolInfo[] creepsInfo = new CreepPoolInfo[3];

    //public GameObject creepMeleePrefab;
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

        CargarCantidades();

        creepPool = new ObjectPool<GameObject>(CrearCreep,
                                                    ObtenerCreep,
                                                    DevolverCreep,
                                                    DestruirCreep,
                                                    true, cantidadMinima, cantidadMaxima);
    }

    //cargamos todas las cantidades de creeps sumadas
    void CargarCantidades()
    {
        for (int i = 1; i < creepsInfo.Length; i++)
        {
            cantidadMinima += creepsInfo[i].cantidadMinima;
            cantidadMaxima += creepsInfo[i].cantidadMaxima;
        }
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            creepActual = creepPool.Get();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            creepPool.Release(creepActual);
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
            var nuevoCreep = creepPool.Get();
            nuevoCreep.SetActive(false);
        }
    }

    private GameObject CrearCreep()
    {
        GameObject creep = null;

        foreach (var creepInfo in creepsInfo)
        {
            creep = Instantiate(creepInfo.creepPrefab, transform.position, transform.rotation);
            creep.SetActive(false);
        }
        
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

[System.Serializable]
public class CreepPoolInfo
{
    public GameObject creepPrefab;
    public int cantidadMinima;
    public int cantidadMaxima;
}