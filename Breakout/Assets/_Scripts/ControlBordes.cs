using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlBordes : MonoBehaviour
{
   [Header("Configurar en el editor")]  //se van a crear variables, algunas editables desde el editor y otras de maneras dinamicas; para separarlas en el editor usamos Header. 
    public float radio = 0.5f;
    public bool mantenerEnPantalla = false;

    [Header("Configuraciones dinamicas")]
    public bool estaEnPantalla = true;
    public float anchoCamara;
    public float altoCamara;
    public bool salioDerecha, salioIzquierda, salioArriba, salioAbajo;

    public void Awake()
    {
        altoCamara = Camera.main.orthographicSize;  //seteando el tamano de la escena. (aspect ratio se multiplica). La propiedad size de la camara ortografica de 16 significa que hay 16 unidades del centro hacia arriba y 16 unidades del centro hacia abajo.
        anchoCamara = Camera.main.aspect * altoCamara;  // gives you the width-to-height ratio of the screen (i.e., screen width divided by height). on a 16:9 screen, aspect = 16 / 9 ? 1.78. anchoCamara = aspect * altoCamara = half-width of the camera in world units
    }
    
    // Start is called before the first frame update

    // Update is called once per frame
    void LateUpdate()       //en LateUpdate para evitar condiciones de carrera para que se ejecute despues de toda la logica del juego
    {
        Vector3 pos = transform.position;   //gives you the current position of the GameObject in world space as a Vector3
        estaEnPantalla = true;
        salioAbajo = salioArriba = salioDerecha = salioIzquierda = false;
        if (pos.x > anchoCamara - radio)
        {
            pos.x = anchoCamara - radio;
            salioDerecha = true;
        }
        if (pos.x < -anchoCamara + radio)
        {
            pos.x = -anchoCamara + radio;
            salioIzquierda = true;
        }
        if (pos.y > altoCamara - radio)
        {
            pos.y = anchoCamara - radio;
            salioArriba = true;
        }
        if (pos.y < -altoCamara + radio)
        {
            pos.y = -altoCamara + radio;
            salioAbajo = true;
        }

        estaEnPantalla = !(salioAbajo || salioArriba || salioIzquierda || salioDerecha);
        if (mantenerEnPantalla && !estaEnPantalla)
        {
            transform.position = pos;
            estaEnPantalla = true;
        }
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Vector3 tamanoBorde = new Vector3(anchoCamara * 2, altoCamara * 2, 0.1f);   //se multiplica por dos para abarcar todo lo ancho y largo (anchoCamara y altoCamara solo es del centro a los bordes)
        Gizmos.DrawWireCube(Vector3.zero, tamanoBorde);
    }
}
