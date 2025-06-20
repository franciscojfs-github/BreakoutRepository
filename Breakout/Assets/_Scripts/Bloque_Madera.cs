using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque_Madera : Bloque
{
    void Awake()
    {
        resistencia = 3;
    }

    void Start()
    {
        vidaBloque = resistencia * opciones.multDificultad;
        bloquesRestantes++;
    }


    public override void RebotarBola(Collision collision)      //hacer uso de lo que tiene la clase padre como clase virtual. 
    {
        base.RebotarBola(collision);                 //agarrar lo que ya hace nuestra clase padre y replicar lo que dice su metodo. Al replicar lo que dice su metodo podemos agregar logica antes o despues de ese metodo.
    }
}
