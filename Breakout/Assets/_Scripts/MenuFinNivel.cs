using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFinNivel : MonoBehaviour
{
    public void SiguienteNivel()
    {
        var siguienteNivel = SceneManager.GetActiveScene().buildIndex + 1;  //adquirir el indice de esta escena y sumarle uno
        if (SceneManager.sceneCountInBuildSettings > siguienteNivel)    //en caso de que la cantaidad de escenas sea mayor que el siguiente nivel, cargara el siguiente nivel
        {
            SceneManager.LoadScene(siguienteNivel);
        }
        else //de lo contrario volvera a l menu principal
        {
            CargarMenuPrincipal();
        }
    }

    public void CargarMenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }

    public void ReintentarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

