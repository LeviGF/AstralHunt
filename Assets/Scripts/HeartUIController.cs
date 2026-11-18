using UnityEngine;
using UnityEngine.UI;

public class HeartUIController : MonoBehaviour
{
    public Image[] heartImages;       //  4 corazones en la UI
    public Sprite[] heartSprites;     // Los sprites de la animación (del lleno al vacío)

    public void UpdateHearts(int currentHealth, int maxHealthPerHeart = 4)
    {
        // currentHealth representa la vida total numérica del jugador
        for (int i = 0; i < heartImages.Length; i++)
        {
            // Calculamos qué sprite le toca a cada corazón individualmente
            int spriteIndex = Mathf.Clamp(maxHealthPerHeart - (currentHealth - (i * maxHealthPerHeart)), 0, heartSprites.Length - 1);
            
            // Si el corazón ya pasó su vida, se queda vacío; si no, muestra su estado actual
            if (currentHealth <= i * maxHealthPerHeart)
            {
                heartImages[i].sprite = heartSprites[heartSprites.Length - 1]; // Corazón vacío
            }
            else if (currentHealth >= (i + 1) * maxHealthPerHeart)
            {
                heartImages[i].sprite = heartSprites[0]; // Corazón completamente lleno
            }
            else
            {
                int localHealth = currentHealth - (i * maxHealthPerHeart);
                int index = maxHealthPerHeart - localHealth;
                heartImages[i].sprite = heartSprites[Mathf.Clamp(index, 0, heartSprites.Length - 1)];
            }
        }
    }
}