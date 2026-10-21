using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_Life : MonoBehaviour
{
    [SerializeField] private float vidaMax; //Vima maxima del jugador
    private float vida; //Vida actual del jugador

    public string desbloquear;


    private void Start()
    {
        vida = vidaMax;
    }

    public void TomarDaño(float CantidadDaño)
    {
        vidaMax -= CantidadDaño;

        if (vidaMax <= 0)
        {

            Dead();

        }
    }

    private void Dead()
    {
        Destroy(gameObject);

        SceneManager.LoadScene(desbloquear);
    }
}
