//using Microsoft.Unity.VisualStudio.Editor;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using UnityEngine.UI;

public class CambioMundos : MonoBehaviour
{
    public Transform CambioDestino;
    public Transform ObjetosCambio;

    //--------Trancicion----------
    public Image imagenEnNegro; //imagen negro del canvas
    public float duraccion = 0.3f; //tiempo en el cual dura la pantalla en negro
    private bool enTrasicion = false; //Variable si es que esta en trasicion

    //private Rigidbody2D rb;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !enTrasicion)
        {
            StartCoroutine(Transicion());
            //TP();
            
        }
    }

    private void TP()
    {
        Vector2 PosicionAnteriorDelPlayer = transform.position;

        transform.position = CambioDestino.position;
        ObjetosCambio.position = PosicionAnteriorDelPlayer;
        Debug.Log("Jugador Teletrasportado con exito");
    }

    IEnumerator Transicion()
    {
        //Pasa a ser verdadero la variable "enTransicion"
        enTrasicion = true;

        //Oscure la pantalla
        yield return StartCoroutine(CambiarAlfa(0f, 1f));

        yield return new WaitForSeconds(0.2f);

        TP();

        yield return new WaitForSeconds(0.5f);

        yield return StartCoroutine(CambiarAlfa(1f, 0f));

        enTrasicion = false;
    }

    IEnumerator CambiarAlfa(float inicio, float fin)
    {
        float tiempoTranscurido = 0f;

        Color colorActual = imagenEnNegro.color;

        while (tiempoTranscurido < duraccion)
        {
            tiempoTranscurido += Time.deltaTime;
            float nuevoAlfa = Mathf.Lerp(inicio, fin, tiempoTranscurido / duraccion);

            colorActual.a = nuevoAlfa;
            imagenEnNegro.color = colorActual;

            yield return null;
        }
        colorActual.a = fin;
        imagenEnNegro.color = colorActual;

    }

}
