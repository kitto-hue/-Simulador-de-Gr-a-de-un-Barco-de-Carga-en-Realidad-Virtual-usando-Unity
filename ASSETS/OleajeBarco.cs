using UnityEngine;

public class OleajeBarco : MonoBehaviour
{
    [Header("Configuración del Balanceo (Rotación)")]
    public float velocidadRotacion = 1.0f;
    public float anguloMaximo = 4.0f; // Grados que se inclinará hacia los lados

    [Header("Configuración de Flote (Arriba y Abajo)")]
    public float velocidadFlote = 0.5f;
    public float alturaFlote = 0.15f; // Qué tanto sube y baja en el agua

    private Vector3 posicionInicial;
    private Quaternion rotacionInicial;

    void Start()
    {
        // Guardamos la posición y rotación inicial del barco para que no se mueva de su sitio
        posicionInicial = transform.position;
        rotacionInicial = transform.rotation;
    }

    void Update()
    {
        // 1. Efecto de flotar (Sube y baja usando la función matemática Seno)
        float nuevoY = posicionInicial.y + Mathf.Sin(Time.time * velocidadFlote) * alturaFlote;
        transform.position = new Vector3(transform.position.x, nuevoY, transform.position.z);

        // 2. Efecto de balanceo (Se inclina de izquierda a derecha usando Seno)
        float anguloZ = Mathf.Sin(Time.time * velocidadRotacion) * anguloMaximo;
        
        // Aplicamos la rotación sobre el eje Z (para que se meza de lado a lado)
        transform.rotation = rotacionInicial * Quaternion.Euler(0, 0, anguloZ);
    }
}