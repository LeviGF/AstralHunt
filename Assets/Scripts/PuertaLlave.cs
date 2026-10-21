using UnityEngine;

public class DoorKey : MonoBehaviour
{
    [Header("Configuración de la Puerta")]
    [Tooltip("Arrastra aquí el GameObject de la puerta que deseas hacer desaparecer")]
    [SerializeField] private GameObject door;

    [Header("Filtro por Etiqueta")]
    [Tooltip("Etiqueta (Tag) del objeto que debe tocar este activador (ej. Player)")]
    [SerializeField] private string targetTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entró en la zona tiene la etiqueta requerida
        if (other.CompareTag(targetTag))
        {
            DisappearDoor();
        }
    }

    // Opcional: Si se usa física 2D, usar esta función en lugar de OnTriggerEnter
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            DisappearDoor();
        }
    }

    private void DisappearDoor()
    {
        if (door != null)
        {
            // Desactiva la puerta del escenario
            door.SetActive(false);

            // Si prefieres destruirla por completo en lugar de solo ocultarla:
            // Destroy(door);
        }
        else
        {
            Debug.LogWarning("No hay puerta en el inspector.");
        }
    }
}