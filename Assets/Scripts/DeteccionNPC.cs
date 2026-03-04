using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class DeteccionNPC : MonoBehaviour
{
    public GameObject objetoGameOver; 
    private AudioSource musicaMuerte;
    private bool yaPillado = false;

    void Start()
    {
        // Buscamos el AudioSource en el mismo objeto donde esté este script
        musicaMuerte = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !yaPillado)
        {
            yaPillado = true;
            Debug.Log("¡Pillado!");

            // 1. Mostramos la imagen
            if (objetoGameOver != null) 
                objetoGameOver.SetActive(true);

            // 2. Le damos al play a la música
            if (musicaMuerte != null) 
                musicaMuerte.Play();

            // 3. Congelamos el juego
            Time.timeScale = 0;

            // 4. Esperamos 4 segundos reales para que se vea el mensaje
            StartCoroutine(EsperarYReiniciar());
        }
    }

    IEnumerator EsperarYReiniciar()
    {
        yield return new WaitForSecondsRealtime(4f);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}