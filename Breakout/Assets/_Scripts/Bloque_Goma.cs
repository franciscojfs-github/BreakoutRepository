using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque_Goma : Bloque
{
    // Start is called before the first frame update
    void Start()
    {
        resistencia = 4;
    }

    public override void RebotarBola()
    {
        base.RebotarBola();
    }

}
