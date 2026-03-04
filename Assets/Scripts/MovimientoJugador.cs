using UnityEngine;

[RequireComponent(typeof(CharacterController))]
// Añadimos esto para que Unity te ponga el altavoz automáticamente
[RequireComponent(typeof(AudioSource))] 
public class MovimientoJugador : MonoBehaviour
{
    public float speed = 5.0f;
    private Animator anim;
    private AudioSource audioSource; // Variable para el sonido

    void Start()
    {
        // Obtenemos las referencias al empezar
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 1. Capturamos el movimiento
        float moveHorizontal = -Input.GetAxis("Horizontal");
        float moveVertical = -Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // 2. Lógica de movimiento y animación
        if (movement.magnitude > 0.1f)
        {
            transform.Translate(movement * speed * Time.deltaTime, Space.World);
            transform.rotation = Quaternion.LookRotation(movement);
            anim.SetBool("walk", true);

            // --- LÓGICA DE SONIDO ---
            // Si se mueve y el sonido no está sonando, lo activamos
            if (!audioSource.isPlaying) 
            {
                audioSource.Play();
            }
        }
        else
        {
            anim.SetBool("walk", false);

            // Si se detiene, paramos el sonido
            audioSource.Stop();
        }
    }
}