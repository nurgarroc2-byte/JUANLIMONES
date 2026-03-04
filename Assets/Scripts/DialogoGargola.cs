using UnityEngine;
using TMPro;

public class DialogoGargola : MonoBehaviour
{
    public GameObject panelDialogo;
    public TextMeshProUGUI textoDialogo; 
    public GameObject avisoE; // <--- ARRASTRA AQUÍ EL NUEVO TEXTO "PULSA E"
    [TextArea(3, 10)]
    public string[] frases; 

    private int indice = 0;
    private bool jugadorCerca = false;

    void Update()
    {
        if (jugadorCerca && Input.GetKeyDown(KeyCode.E))
        {
            // Al empezar a hablar, ocultamos el aviso de "Pulsa E"
            if (avisoE != null) avisoE.SetActive(false);
            SiguienteFrase();
        }
    }

    void SiguienteFrase()
    {
        if (indice < frases.Length)
        {
            panelDialogo.SetActive(true);
            textoDialogo.text = frases[indice];
            indice++;
        }
        else
        {
            CerrarDialogo();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
            // Mostramos el aviso solo si no estamos ya hablando
            if (avisoE != null && !panelDialogo.activeSelf) 
            {
                avisoE.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CerrarDialogo();
        }
    }

    void CerrarDialogo()
    {
        jugadorCerca = false;
        panelDialogo.SetActive(false);
        if (avisoE != null) avisoE.SetActive(false); // Apagamos el aviso al irnos
        indice = 0; 
    }
}