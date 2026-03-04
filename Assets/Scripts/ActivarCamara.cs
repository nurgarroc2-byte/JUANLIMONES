using Unity.Cinemachine;
using UnityEngine;

public class ActivarCamara : MonoBehaviour
{
    [SerializeField] private CinemachineCamera[] camaras;

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "Entrada":
                ActivarCamaras(0);
                break;

            case "Hall":
                ActivarCamaras(1);
                break;

            case "Pasillo":
                ActivarCamaras(2);
                break;

                case "Comedor1":
                ActivarCamaras(3);
                break;

                case "Comedor2":
                ActivarCamaras(4);
                break;

                case "Habitacion1":
                ActivarCamaras(5);
                break;

                case "Habitacion2":
                ActivarCamaras(6);
                break;

                case "Habitacion3":
                ActivarCamaras(7);
                break;

                case "Habitacion4":
                ActivarCamaras(8);
                break;

                case "Habitacion4(1)":
                ActivarCamaras(9);
                break;

                case "Baño":
                ActivarCamaras(10);
                break;

                case "SegundoPasillo":
                ActivarCamaras(11);
                break;

                case "Pasilloesquina":
                ActivarCamaras(12);
                break;

                case "pasillo3":
                ActivarCamaras(13);
                break;

                case "pasillo4":
                ActivarCamaras(14);
                break;

                case "pasillo5":
                ActivarCamaras(15);
                break;

                case "pasillo6":
                ActivarCamaras(16);
                break;

                case "pasillo7":
                ActivarCamaras(17);
                break;

                case "pasillo8":
                ActivarCamaras(18);
                break;

                case "pasillo9":
                ActivarCamaras(19);
                break;

                case "Salida":
                ActivarCamaras(20);
                break;
        }
    }

    private void ActivarCamaras(int index)
    {
        for (int i = 0; i < camaras.Length; i++)
        {
            if (i != index)
            {
                camaras[i].Priority = 0;
            }
        }

        camaras[index].Priority = 10;
    }
}