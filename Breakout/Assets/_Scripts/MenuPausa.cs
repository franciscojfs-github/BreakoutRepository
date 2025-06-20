using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject menuPausa;    //crear dos GO, el que va guardar/hacer referencia a menuPausa
    public GameObject menuOpciones; //y el que lo hara a menuOpciones
    public Opciones opciones;

    public void MostrarMenuPausa()  //dos situaciones en las que se llama a este menu. Una presionando el boton de Menu dentro del juego. Y cuando desde el menu de opciones clickamos en Regresar
    {
        menuPausa.SetActive(true);  
        if (menuOpciones.activeInHierarchy) menuOpciones.SetActive(false);  //si esta activo lo desactivamos si es que venimos del menu de opciones
    }

    public void OcultarMenuPausa()
    {
        menuPausa.SetActive(false);
    }

    public void RegresarAPantallaPrincipal()
    {
        SceneManager.LoadScene(0);  //regresar al menu principal
    }

    public void MostrarMenuOpciones()
    {
        menuPausa.SetActive(false);
        menuOpciones.SetActive(true);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        
    }
}
