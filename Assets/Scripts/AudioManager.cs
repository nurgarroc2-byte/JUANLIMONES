using UnityEngine;
using System.Collections.Generic; // Necesario para las listas

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    [Header("Reproductores")]
    [SerializeField] private AudioSource reproductorMusica;
    [SerializeField] private AudioSource reproductorEfectos;

    // Como los Diccionarios no se ven en el Inspector, usamos una lista de una clase simple
    [System.Serializable]
    public class SonidoConfig
    {
        public string nombre;
        public AudioClip clip;
    }

    [Header("Biblioteca de Sonidos")]
    [SerializeField] private List<SonidoConfig> listaSonidos; 

    private Dictionary<string, AudioClip> bibliotecaSonidos = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Debe ir dentro del IF
        }
        else
        {
            Destroy(gameObject);
            return; // Salimos para no ejecutar el resto
        }

        // Pasamos la lista al diccionario para que sea rápido buscar sonidos
        foreach (var sonido in listaSonidos)
        {
            if (!bibliotecaSonidos.ContainsKey(sonido.nombre))
            {
                bibliotecaSonidos.Add(sonido.nombre, sonido.clip);
            }
        }
    }

    // Método para que puedas llamar a un sonido desde otros scripts
    public void PlayEfecto(string nombre)
    {
        if (bibliotecaSonidos.ContainsKey(nombre))
        {
            reproductorEfectos.PlayOneShot(bibliotecaSonidos[nombre]);
        }
        else
        {
            Debug.LogWarning("El sonido " + nombre + " no existe en el AudioManager");
        }
    }
}
