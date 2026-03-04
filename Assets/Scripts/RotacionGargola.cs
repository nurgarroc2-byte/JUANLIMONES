using UnityEngine;

public class RotacionGargola : MonoBehaviour
{
    public float velocidad = 2f;
    public float anguloMaximo = 45f; // Grados que girará a izquierda y derecha

    private Quaternion rotacionInicial;

    void Start()
    {
        // Guardamos la rotación que le pusiste en el editor
        rotacionInicial = transform.localRotation;
    }

    void Update()
    {
        // Movimiento de vaivén (como un ventilador)
        float giro = Mathf.Sin(Time.time * velocidad) * anguloMaximo;
        transform.localRotation = rotacionInicial * Quaternion.Euler(0, giro, 0);
    }
}
