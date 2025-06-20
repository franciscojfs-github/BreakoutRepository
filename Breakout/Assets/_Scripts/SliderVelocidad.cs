using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVelocidad : MonoBehaviour
{
    //Que se tiene que hacer:
    //llamar al objeto de opciones, generar un evento onValueChange, asignar delegado y cambiar la velocidad en opciones
    //la diferencia es que se crea un nuevo metodo que se llama controlar cambios

    public Opciones opciones;
    Slider slider;

    public void Start()
    {
        slider = this.GetComponent<Slider>();
        opciones.Cargar();
        slider.value = opciones.velocidadJugador;
        //opciones.velocidadJugador = slider.value;
        slider.onValueChanged.AddListener(delegate { ControlarCambios(); });
    }

    public void ControlarCambios()
    {
        opciones.CambiarVelocidad(slider.value);
        opciones.Guardar();
    }
}
