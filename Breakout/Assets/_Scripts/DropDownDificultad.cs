using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropDownDificultad : MonoBehaviour
{
    public Opciones opciones;   //referencia a scriptable object
    private TMP_Dropdown dificultad;    //creando una referencia al dropdown al que vamos hacer el atachment
    int velocidadBola;

    private void Start()
    {
        
        dificultad = GetComponent<TMP_Dropdown>();  //dame el componente donde estoy haciendo el atachment
        opciones.Cargar();
        dificultad.value = (int)opciones.NivelDificultad;
        dificultad.onValueChanged.AddListener(delegate
        {
            opciones.CambiarDificultad(dificultad.value); opciones.Guardar();

        }); //de ese componente vamos agregar un listener a un delegado anonimo que va mandar a llamar a opciones cambiar dificultad cada vez que cambie el valor del drop down(onValueChanged)
    }

}
