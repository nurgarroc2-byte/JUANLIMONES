using UnityEngine;

public class ItemLlave : MonoBehaviour
{
    [SerializeField] private string sonidoRecogida = "Llave"; // Nombre en el AudioManager

    private void OnTriggerEnter(Collider other)
    {
        // Comprobamos si es el jugador el que toca la llave
        if (other.CompareTag("Player"))
        {
            // Buscamos el componente InventarioJugador que creamos antes
            InventarioJugador inventario = other.GetComponent<InventarioJugador>();

            if (inventario != null)
            {
                inventario.RecogerLlave(); // Activamos la variable true
                
                // Opcional: Sonido de recogida
                if (AudioManager.Instance != null)
                    AudioManager.Instance.PlayEfecto(sonidoRecogida);

                // Destruimos la llave de la escena porque ya la tenemos
                Destroy(gameObject);
            }
        }
    }

    void Update()
    {
        // Un pequeño toque visual: que la llave flote y rote
        transform.Rotate(Vector3.up * 50 * Time.deltaTime);
    }
}