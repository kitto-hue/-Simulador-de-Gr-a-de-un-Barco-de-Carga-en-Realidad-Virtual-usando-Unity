using UnityEngine;

public class ControlCamaras : MonoBehaviour
{
    [Header("Arrastra tus cámaras aquí")]
    public Camera camara1; // Tecla 1
    public Camera camara2; // Tecla 2
    public Camera camara3; // Tecla 3

    void Start()
    {
        // Al darle Play, solo la cámara 1 estará prendida
        camara1.gameObject.SetActive(true);
        camara2.gameObject.SetActive(false);
        camara3.gameObject.SetActive(false);
    }

    void Update()
    {
        // Presionar la tecla 1 (Cámara General)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            camara1.gameObject.SetActive(true);
            camara2.gameObject.SetActive(false);
            camara3.gameObject.SetActive(false);
        }
        
        // Presionar la tecla 2 (Cámara de la Cabina)
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            camara1.gameObject.SetActive(false);
            camara2.gameObject.SetActive(true);
            camara3.gameObject.SetActive(false);
        }

        // Presionar la tecla 3 (Cámara del Gancho)
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            camara1.gameObject.SetActive(false);
            camara2.gameObject.SetActive(false);
            camara3.gameObject.SetActive(true);
        }
    }
}