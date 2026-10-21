using UnityEngine;

public class DoorsPalanca : MonoBehaviour
{
    [Header("Configuración de la Puerta")]
    [Tooltip("Arrastra el GameObject de la puerta")]
    [SerializeField] private GameObject door;

    [Header("Estado de las Palancas (Solo lectura)")]
    [SerializeField] private bool lever1Activated = false;
    [SerializeField] private bool lever2Activated = false;

    // Se activa una única vez y no se puede revertir
    public void ActivateLever1()
    {
        if (!lever1Activated)
        {
            lever1Activated = true;
            Debug.Log("¡Palanca 1 activada!");
            CheckConditions();
        }
    }

    // Se activa una única vez
    public void ActivateLever2()
    {
        if (!lever2Activated)
        {
            lever2Activated = true;
            Debug.Log("¡Palanca 2!");
            CheckConditions();
        }
    }

    private void CheckConditions()
    {
        // Si ambas palancas ya fueron activadas, hace desaparecer la puerta
        if (lever1Activated && lever2Activated)
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        if (door != null)
        {
            door.SetActive(false);
            Debug.Log("¡Ambas palancas activadas! La puerta ha desaparecido.");
        }
        else
        {
            Debug.LogWarning("No se ha asignado ninguna puerta en el script.");
        }
    }
}
