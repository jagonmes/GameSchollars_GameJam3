using UnityEngine;

public class Camera3D : MonoBehaviour
{
    //Referencia a la camara
    [SerializeField] private Transform playerCamera;

    //Sensibilidad en ambos ejes
    public Vector2 sensitivities;

    //Angulos de rotación para jugador y camara
    private Vector2 m_XYRotation;
    
    //Script de movimiento del jugador
    private Movimiento movimientoJugador;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        movimientoJugador = this.transform.GetComponent<Movimiento>();
    }


    void Update()
    {
        if (movimientoJugador.JugadorActivo)
        {
            //Leer X e Y del ratón
            Vector2 mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

            //Calcular rotación
            m_XYRotation.x -= mouseInput.y * sensitivities.y;
            m_XYRotation.y += mouseInput.x * sensitivities.x;

            //Limitar la rotación vertical
            m_XYRotation.x = Mathf.Clamp(m_XYRotation.x, -60f, 60f);

            //Giramos al personaje (horizontal)
            transform.eulerAngles = new Vector3(0f, m_XYRotation.y, 0f);
            //Giramos la camara (vertical)
            playerCamera.localEulerAngles = new Vector3(m_XYRotation.x, 0f, 0f);
        }
    }
}
