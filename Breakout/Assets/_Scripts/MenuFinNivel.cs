using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFinNivel : MonoBehaviour
{
    public GameObject menuUI;

    void Start()
    {
        Debug.Log("MenuFinNivel attached to: " + gameObject.name);

        if (menuUI != null)
        {
            menuUI.SetActive(false);
        }
        else
        {
            Debug.LogWarning("menuUI is null in " + gameObject.name);
        }
    }

    public void MostrarMenu()
    {
        if (menuUI != null)
        {
            menuUI.SetActive(true);
        }
        else
        {
            Debug.LogWarning("menuUI is not assigned!");
        }

        Time.timeScale = 0f;
    }

    public void SiguienteNivel()
    {
        Time.timeScale = 1f;
        int siguienteNivel = SceneManager.GetActiveScene().buildIndex + 1;  //adquirir el indice de esta escena y sumarle uno
        if (SceneManager.sceneCountInBuildSettings > siguienteNivel)    //en caso de que la cantaidad de escenas sea mayor que el siguiente nivel, cargara el siguiente nivel
        {
            SceneManager.LoadScene(siguienteNivel);
        }
        else //de lo contrario volvera a l menu principal
        {
            Debug.Log("Ultimo nivel alcanzado");
            CargarMenuPrincipal();
        }
    }

    public void CargarMenuPrincipal()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void ReintentarNivel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

