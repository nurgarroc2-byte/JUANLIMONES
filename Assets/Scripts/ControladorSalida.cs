using UnityEngine;
using System.Collections;

public class ControladorSalida : MonoBehaviour
{
    public GameObject pantallaVictoria;
    public GameObject mensajeSinLlave; // Arrastra aquí el texto de "Necesitas la llave"
    public string sonidoVictoria = "Victoria"; 
    public string sonidoDenegado = "Cerrado";   

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InventarioJugador inventario = other.GetComponent<InventarioJugador>();

            if (inventario != null && inventario.tieneLlave)
            {
                GanarJuego();
            }
            else
            {
                NoTieneLlave();
            }
        }
    }

    void GanarJuego()
    {
        if (pantallaVictoria != null)
            pantallaVictoria.SetActive(true);

        // Protección para que no salga el error NullReferenceException
        if (AudioManager.Instance != null)
            AudioManager.Instance.PlayEfecto(sonidoVictoria);

        Time.timeScale = 0; 
        Debug.Log("¡Ganaste!");
    }

    void NoTieneLlave()
    {
        // Si el AudioManager existe, suena el error
        if (AudioManager.Instance != null)
            AudioManager.Instance.PlayEfecto(sonidoDenegado);

        Debug.Log("Necesitas la llave para salir");

        // Activamos el mensaje visual
        if (mensajeSinLlave != null)
        {
            mensajeSinLlave.SetActive(true);
            // Llamamos a una función para que se apague solo en 3 segundos
            Invoke("OcultarMensaje", 3f);
        }
    }

    void OcultarMensaje()
    {
        if (mensajeSinLlave != null)
            mensajeSinLlave.SetActive(false);
    }
}