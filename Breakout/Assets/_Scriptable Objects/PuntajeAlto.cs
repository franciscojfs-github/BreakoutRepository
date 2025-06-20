using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PuntajeAlto", menuName = "Herramientas/PuntajeAlto", order = 0)]  //setear crear un scriptable object en nuestro panel de proyecto
            // va poder aparacer en el menu contextual de click derecho al seleccionar el script, cuando queramos crear un objeto va aparecer la ruta de Tools y luego submenu de PuntajeAlto. Order: primer elemento del submenu. El tipo de archivo que va crear se va llamar PuntajeAlto.
public class PuntajeAlto : ObjetoPersistente     // es de tipo ScriptableObject (quizas por eso el valor se queda guardado y no empieza de cero?). Se quito la palabra ScriptableObject y se agrego que hereda mas bien de ObjetoPersistente porque aquella es virtual
{
    // Start is called before the first frame update
    public int puntajeActual = 0;
    public int puntajeAlto = 10000;

    //
}
