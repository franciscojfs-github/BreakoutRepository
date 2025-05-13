using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque_Piedra : Bloque     //denota la herencia
{
    // Start is called before the first frame update
    void Start()
    {
        resistencia = 5;
    }

    public override void RebotarBola()      //hacer uso de lo que tiene la clase padre como clase virtual. Sobrecarga de ese metodo
    {
        base.RebotarBola();                 //agarrar lo que ya hace nuestra clase padre y replicar lo que dice su metodo. Al replicar lo que dice su metodo podemos agregar logica antes o despues de ese metodo.
    }

}
