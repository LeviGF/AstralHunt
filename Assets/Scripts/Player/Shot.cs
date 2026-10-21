using UnityEngine;

public class Shot : MonoBehaviour
{
    //Hace referencia al controlador de disparo que esta en el jugador
    [SerializeField] private Transform ControladorDisparo;
    //Hace referencia al objeto bala
    [SerializeField] private GameObject bala;

    private void Update()
    {
        //Detecta si estas tocando el clik izquierdo del maus
        if (Input.GetButtonDown("Fire1"))
        {
            //Disparar
            Disparar();

        }
    }

    private void Disparar()
    {
        Instantiate(bala, ControladorDisparo.position, ControladorDisparo.rotation);
    }
}
