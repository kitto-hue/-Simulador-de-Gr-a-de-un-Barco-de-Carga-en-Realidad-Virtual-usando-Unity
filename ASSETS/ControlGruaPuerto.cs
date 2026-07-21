using UnityEngine;

public class ControlGruaPuerto : MonoBehaviour
{
    [Header("Componentes de la Grúa")]
    public Transform parteGiratoria; 
    public Transform carritoMovil;   
    public Transform cablesObjeto;   
    public Transform ganchoCable;    

    [Header("Velocidades de Simulación")]
    public float velocidadGiro = 25.0f;
    public float velocidadCarrito = 12.0f;
    public float velocidadGancho = 8.0f;

    private LineRenderer lineaCuerda;

    void Start()
    {
        lineaCuerda = gameObject.AddComponent<LineRenderer>();
        lineaCuerda.startWidth = 0.05f; 
        lineaCuerda.endWidth = 0.05f;
        lineaCuerda.material = new Material(Shader.Find("Sprites/Default"));
        lineaCuerda.startColor = Color.black; 
        lineaCuerda.endColor = Color.black;
    }

    void Update()
    {
        // 1. GIRO 360 (Teclas Q / E)
        if (Input.GetKey(KeyCode.Q))
        {
            parteGiratoria.Rotate(Vector3.up * -velocidadGiro * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.E))
        {
            parteGiratoria.Rotate(Vector3.up * velocidadGiro * Time.deltaTime, Space.World);
        }

        // =========================================================================
        // 2. DESPLAZAMIENTO DEL CARRITO CORREGIDO (Teclas: A / D)
        // Usamos Vector3.up y down porque el eje del modelo 3D está rotado -90 grados
        // =========================================================================
        if (Input.GetKey(KeyCode.D))
        {
            carritoMovil.Translate(Vector3.up * velocidadCarrito * Time.deltaTime, Space.Self);
        }
        if (Input.GetKey(KeyCode.A))
        {
            carritoMovil.Translate(Vector3.down * velocidadCarrito * Time.deltaTime, Space.Self);
        }

        // 3. SUBIR Y BAJAR GANCHO (Teclas W / S)
        if (Input.GetKey(KeyCode.W))
        {
            ganchoCable.Translate(Vector3.up * velocidadGancho * Time.deltaTime, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            ganchoCable.Translate(Vector3.down * velocidadGancho * Time.deltaTime, Space.World);
        }

        // 4. CUERDA AUTOMÁTICA
        if (lineaCuerda != null)
        {
            lineaCuerda.SetPosition(0, carritoMovil.position);
            lineaCuerda.SetPosition(1, ganchoCable.position);
        }
    }
}