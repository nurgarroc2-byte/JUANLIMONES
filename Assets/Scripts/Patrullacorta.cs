using UnityEngine;
using UnityEngine.AI;

public class Patrullacorta : MonoBehaviour
{
public Transform[] puntos; // Arrastra aquí tus puntos A y B
    private NavMeshAgent agente;
    private int indiceActual = 0;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        IrAlSiguientePunto();
    }

    void Update()
    {
        // Si el agente está cerca del destino, va al siguiente
        if (!agente.pathPending && agente.remainingDistance < 0.5f)
        {
            IrAlSiguientePunto();
        }
    }

    void IrAlSiguientePunto()
    {
        if (puntos.Length == 0) return;

        agente.destination = puntos[indiceActual].position;
        // Cambia entre el punto 0 y el 1 (o más)
        indiceActual = (indiceActual + 1) % puntos.Length;
    }
}