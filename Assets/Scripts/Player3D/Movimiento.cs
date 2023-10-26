using UnityEngine;

public class Movimiento : MonoBehaviour
{
    //Variables controlables por editor
    [SerializeField] private float moveSmoothTime;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    //Para cálculos
    private Vector3 m_CurrentMoveVelocity;
    private Vector3 m_MoveDampVelocity;
    private Vector3 m_CurrentForceVelocity;

    //Controlador
    private CharacterController m_Controller;

    public bool JugadorActivo = true;


    void Start()
    {
        //Asignamos el controlador
        m_Controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //Si el jugador esta activo
        if (JugadorActivo && !Pausa.juegoPausado)
        {
            //Leemos y normalizamos la entrada 
            Vector3 playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            if (playerInput.magnitude > 1f)
                playerInput.Normalize();

            //Recalculamos la dirección del movimiento
            Vector3 moveVector = transform.TransformDirection(playerInput);

            //Comprobamos si corremos o no, para elegir la velocidad
            float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? runSpeed : walkSpeed;

            //Se calcula la velocidad del movimiento
            m_CurrentMoveVelocity = Vector3.SmoothDamp(m_CurrentMoveVelocity, moveVector * currentSpeed,
                ref m_MoveDampVelocity, moveSmoothTime);

            //Se asigna -2 a la velocidad horizontal para que se mantenga pegado al suelo
            m_CurrentForceVelocity.y = -20f;

            //Se mueve al personaje

            m_Controller.Move(m_CurrentMoveVelocity * Time.deltaTime);
            m_Controller.Move(m_CurrentForceVelocity * Time.deltaTime);
        }

        if (!JugadorActivo && !Pausa.juegoPausado)
        {
            m_CurrentMoveVelocity = new Vector3(0,0,0);
            m_CurrentForceVelocity = new Vector3(0,0,0);
        }
    }
}