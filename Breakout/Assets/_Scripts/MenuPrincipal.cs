using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject MenuOpciones;
    public GameObject MenuInicial;  //diferente nombre porque una variable no puede llamarse igual a su clase 

    private void Start()
    {
        MenuInicial.SetActive(true);
        MenuOpciones.SetActive(false);
    }

    public void IniciarJuego()
    {
        SceneManager.LoadScene(1);  //carga la escena con el build index 1
    }

    public void finalizarJuego()
    {
        Application.Quit(); //cerrar el juego (cuando se compila el juego y se juega)
    }

    public void MostrarOpciones()   //se usa este metodo para no tener que cargar escenas adicionales cuando solo se muestran diferentes interfaces (menus, etc.)
    {
        MenuInicial.SetActive(false);   //es como si lo desactivaramos del Inspector (el checkbox de hasta arriba del objeto en el inspector)
        MenuOpciones.SetActive(true);
    }

    public void MostrarMenuInicial()    //invertido a Mostrar opciones
    {
        MenuOpciones.SetActive(false);
        MenuInicial.SetActive(true);
    }
}
