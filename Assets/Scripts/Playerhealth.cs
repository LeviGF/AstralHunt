using UnityEngine;
using System.Collections;

public class Playerhealth : MonoBehaviour
{
    [Header("Configuración de Vida")]
    public int maxHealth = 16;       // 4*4 corazones
    private int currentHealth;
    
    [Header("Cooldown")]
    public float damageCooldown = 1f; // 1 segundo de cooldown por daño recibido
    private bool canTakeDamage = true;

    // Referencia al script que actualiza los sprites en la UI
    public HeartUIController heartUI;

    void Start()
{
    currentHealth = maxHealth; // Esto asegura que empiece con los 16 puntos de vida
    if (heartUI != null)
    {
        heartUI.UpdateHearts(currentHealth, 4);
    }
}

    // Detectar colisión con el enemigo por físicas (Collider 2D)
    private void OnCollisionStay2D(Collision2D collision)
{
    // Esto imprimirá en la consola de Unity cada objeto exacto con el que choca el jugador
    Debug.Log("¡Colisión detectada con: " + collision.gameObject.name + " | Tag: " + collision.gameObject.tag);

    if (collision.gameObject.CompareTag("Enemy"))
    {
        TryTakeDamage();
    }
}



    void TryTakeDamage()
    {
        if (canTakeDamage && currentHealth > 0)
        {
            currentHealth--;
            
            // Actualizar la interfaz visual de los corazones
            if (heartUI != null)
            {
                heartUI.UpdateHearts(currentHealth);
            }

            // Iniciar el cooldown de 1 segundo
            StartCoroutine(DamageCooldownRoutine());

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    IEnumerator DamageCooldownRoutine()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(damageCooldown);
        canTakeDamage = true;
    }

    void Die()
    {
        Debug.Log("El jugador ha muerto.");
        //puedes reiniciar la escena
    }
}