using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque_Goma : Bloque
{
    void Awake()
    {
        resistencia = 2;
    }

    void Start()
    {
        vidaBloque = resistencia * opciones.multDificultad;
        bloquesRestantes++;
    }


    public override void RebotarBola(Collision collision)
    {
        base.RebotarBola(collision);
    }

}
