using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CambioMundos : MonoBehaviour
{
    public Transform CambioDestino;
    public Transform ObjetosCambio;
    //private Rigidbody2D rb;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            TP();

        }
    }

    private void TP()
    {
        Vector2 PosicionAnteriorDelPlayer = transform.position;

        transform.position = CambioDestino.position;
        ObjetosCambio.position = PosicionAnteriorDelPlayer;
        Debug.Log("Jugador Teletrasportado con exito");
    }

}
