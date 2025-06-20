using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Opciones", menuName = "Herramientas/Opciones", order = 1)]

public class Opciones : ObjetoPersistente
{
    public float velocidadJugador;
    public dificultad NivelDificultad;
    public float multDificultad = 1;

    public enum dificultad
    {
        Facil,
        Normal,
        Dificil
    }

    public void CambiarVelocidad(float nuevaVelocidad)
    {
        velocidadJugador = nuevaVelocidad;
    }

    public void CambiarDificultad(int nuevaDificultad)
    {
        NivelDificultad = (dificultad) nuevaDificultad;
        if (NivelDificultad == Opciones.dificultad.Facil)
        {
            multDificultad = 1;
        }
        else if (NivelDificultad == Opciones.dificultad.Normal)
        {
            multDificultad = 2;
        }
        else if (NivelDificultad == Opciones.dificultad.Dificil)
        {
            multDificultad = 2.5f;
        }

        //los delegados son listas de eventos/funciones que ejecutan el evento relevante
    }
}
