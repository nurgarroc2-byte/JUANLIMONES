using UnityEngine;

public class InventarioJugador : MonoBehaviour
{
    public bool tieneLlave = false;

    // Método para recoger la llave (llámalo desde el script de la llave)
    public void RecogerLlave()
    {
        tieneLlave = true;
        Debug.Log("¡Llave recogida!");
    }
}