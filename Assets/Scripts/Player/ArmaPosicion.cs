using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaPosicion : MonoBehaviour
{
    //El objetivo es el cursor del maus en este caso
    private Vector3 objetivo;
    [SerializeField] private Camera camara;

    private void Update()
    {
        objetivo = camara.ScreenToWorldPoint(Input.mousePosition);

        float anguloR = Mathf.Atan2(objetivo.y - transform.position.y, objetivo.x - transform.position.x); //Angulo en Radianes
        float anguloG = (180 / Mathf.PI) * anguloR - 90; //Angulo en Grados
        transform.rotation = Quaternion.Euler(0, 0, anguloG);
    }
}
