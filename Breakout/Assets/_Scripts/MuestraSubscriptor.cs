using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuestraSubscriptor : MonoBehaviour
{
    MuestraEventos subscriptor; //evento de base .NET
    // Start is called before the first frame update
    void Start()
    {
        subscriptor = GetComponent<MuestraEventos>();
        subscriptor.OnSpacePressed += MensajeEscuchadoPorElSubscriptor;
    }

    private void MensajeEscuchadoPorElSubscriptor(object sender, EventArgs e)
    {
        Debug.Log("El evento ha sido escuchado desde otra clase");
        subscriptor.OnSpacePressed -= MensajeEscuchadoPorElSubscriptor;
    }

}
