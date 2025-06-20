using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorDePersistencia : MonoBehaviour
{
    //en este GameObject vamos a guardar una lista de objetos a guardar que son los que heredan de ObjetoPersistente
    public List<ObjetoPersistente> ObjetosAGuardar;
    public void OnEnable()
    {
        for (int i = 0; i < ObjetosAGuardar.Count; i++)     //despues de obtener "eso" se itera en caso de que tenga algo 
        {
            var so = ObjetosAGuardar[i];    //despues de que se itera, cuando se crea, se carga cada uno de los objetos persistentes
            so.Cargar();
        }
    }

    public void OnDisable()
    {
        for (int i = 0; i < ObjetosAGuardar.Count; i++) 
        {
            var so = ObjetosAGuardar[i];
            so.Guardar();       //cuando cerremos el juego se guarda cada uno de los objetos persistentes
        }
    }
}
