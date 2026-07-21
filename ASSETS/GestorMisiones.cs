using UnityEngine;
using TMPro; // <-- Esto es necesario para leer TextMeshPro

public class GestorMisiones : MonoBehaviour
{
    [Header("Pantalla (Arrastrar desde el Canvas)")]
    public TextMeshProUGUI textoMision; // <-- Adaptado a la nueva versión
    public TextMeshProUGUI textoPuntos;

    [Header("Puntuación")]
    private int puntosActuales = 0;
    public int puntosPorEntrega = 100;

    void Start()
    {
        textoMision.text = "Mision 1: Mueve un contenedor al barco.";
        ActualizarMarcador();
    }

    void OnTriggerEnter(Collider otro)
    {
        // Revisa si la caja que cayó tiene la etiqueta "Contenedor"
        if (otro.CompareTag("Contenedor"))
        {
            puntosActuales += puntosPorEntrega;
            ActualizarMarcador();

            textoMision.text = "¡Mision Cumplida! Descarga el siguiente contenedor.";
        }
    }

    void ActualizarMarcador()
    {
        textoPuntos.text = "Puntos: " + puntosActuales.ToString();
    }
}