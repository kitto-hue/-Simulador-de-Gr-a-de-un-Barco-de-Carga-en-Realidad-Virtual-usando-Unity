using UnityEngine;

public class SistemaAgarre : MonoBehaviour
{
    [Header("Configuración del Gancho")]
    public Transform puntoAgarre;
    public AudioSource sonidoAgarre;

    private GameObject contenedorActual;
    private bool estaAgarrando = false;

    void Update()
    {
        // 1. Detectar si presionas la barra espaciadora
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (estaAgarrando)
            {
                SoltarContenedor();
            }
            else
            {
                AgarrarContenedor();
            }
        }

        // 2. EL TRUCO ANTI-ESTIRAMIENTO: Perseguir al gancho
        if (estaAgarrando && contenedorActual != null)
        {
            // El contenedor se teletransporta a la posición del gancho en cada fotograma
            contenedorActual.transform.position = puntoAgarre.position;
            
            // Opcional: También hace que rote igual que el gancho
            contenedorActual.transform.rotation = puntoAgarre.rotation; 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Contenedor") && !estaAgarrando)
        {
            contenedorActual = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Contenedor") && !estaAgarrando)
        {
            contenedorActual = null;
        }
    }

    public void AgarrarContenedor()
    {
        if (contenedorActual != null)
        {
            estaAgarrando = true;
            
            // Solo desactivamos la gravedad, ya NO usamos SetParent
            contenedorActual.GetComponent<Rigidbody>().isKinematic = true; 
            
            if (sonidoAgarre != null)
            {
                sonidoAgarre.Play();
            }
        }
    }

    private void SoltarContenedor()
    {
        if (contenedorActual != null)
        {
            // Devolvemos la gravedad al soltar
            contenedorActual.GetComponent<Rigidbody>().isKinematic = false; 
            estaAgarrando = false;
            contenedorActual = null;
        }
    }
}