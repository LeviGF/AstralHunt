using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class CambioMundos : MonoBehaviour
{
    public Transform CambioDestino;
    //private Rigidbody2D rb;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            TP();
            //rb = GetComponent<Rigidbody2D>();
            //if (rb != null)
            //{
                //rb.MovePosition(CambioDestino.position);
            //}
            //else
            //{
                //other.transform.position = CambioDestino.position;
            //}
        }
    }

    private void TP()
    {
        transform.position = CambioDestino.position;
        Debug.Log("Jugador Teletrasportado con exito");
    }
}
