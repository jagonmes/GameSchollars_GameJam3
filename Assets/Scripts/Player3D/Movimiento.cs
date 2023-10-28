using Unity.VisualScripting;
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
    
    //Audio
    [SerializeField] private AudioClip cAudio;
    [SerializeField] private AudioClip cAudioRunning;
    [SerializeField] private float volume = 0.2f;
    [SerializeField] private float spatialBlend = 1.0f;
    [SerializeField] private bool loop = true;
    
    private AudioSource aSource;
    private AudioSource aSource2;


    void Start()
    {
        //Asignamos el controlador
        m_Controller = GetComponent<CharacterController>();
        if (cAudio != null)
        {
            aSource = this.AddComponent<AudioSource>();
            aSource.loop = loop;
            aSource.spatialBlend = spatialBlend;
            aSource.volume = volume;
            aSource.clip = cAudio;
            aSource.Play();
        }
        if (cAudio != null)
        {
            aSource2 = this.AddComponent<AudioSource>();
            aSource2.loop = loop;
            aSource2.spatialBlend = spatialBlend;
            aSource2.volume = volume;
            aSource2.clip = cAudioRunning;
            aSource2.Play();
        }
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

            Debug.Log(m_CurrentMoveVelocity.magnitude);
            if (m_CurrentMoveVelocity.magnitude > 0.5f)
            {
                if (cAudio != null && !Input.GetKey(KeyCode.LeftShift))
                {
                    aSource2.Pause();
                    aSource.UnPause();
                }

                if (cAudioRunning != null && Input.GetKey(KeyCode.LeftShift))
                {
                    aSource2.UnPause();
                    aSource.Pause();
                }

            }
            else
            {
                if (cAudio != null)
                {
                    aSource.Pause();
                    aSource2.Pause();
                }
            }


        }
        else
        {
            if (cAudio != null)
            {
                aSource.Pause();
                aSource2.Pause();
            }
        }

        if (!JugadorActivo && !Pausa.juegoPausado)
        {
            m_CurrentMoveVelocity = new Vector3(0,0,0);
            m_CurrentForceVelocity = new Vector3(0,0,0);
        }
    }
}