using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Función para el botón JUGAR
    public void Jugar()
    {
        SceneManager.LoadScene(1); // Carga la escena número 1
    }

    // Función para el botón SALIR
    public void Salir()
    {
        Debug.Log("Saliendo del juego..."); // Esto saldrá en la consola
        Application.Quit(); // Cierra el juego (solo funciona en el juego exportado)
    }
}