using UnityEngine;

public class Lever : MonoBehaviour
{
    [Header("Referencia al Controlador")]
    [SerializeField] private DoorTwoLevers doorController;

    [Header("Configuración")]
    [Tooltip("1 si es la primera palanca o 2 si es la segunda.")]
    [SerializeField] private int leverId = 1;

    private bool activated = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Si choca con el jugador y la palanca aún no se ha activado
        if (!activated && other.CompareTag("Player"))
        {
            activated = true;
            Debug.Log("Palanca " + leverId + " accionada.");

            if (doorController != null)
            {
                if (leverId == 1)
                {
                    doorController.ActivateLever1();
                }
                else if (leverId == 2)
                {
                    doorController.ActivateLever2();
                }
            }
            else
            {
                Debug.LogWarning("Falta arrastrar el DoorTwoLevers en la palanca.");
            }
        }
    }
}