using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bloque : MonoBehaviour
{
    public float resistencia = 1;
    public float vidaBloque = 1;
    public Opciones opciones;
    public UnityEvent AumentarPuntaje;
    public static int bloquesRestantes = 0;
    public MenuFinNivel menuFinNivel;

    public void OnCollisionEnter(Collision collision)  //recibe un objeto de tipo Collision (o cualquier nombre)
    {
        if (collision.gameObject.tag == "Bola") //el tag de nuestro objeto es bola? Esto se seteo previamente en el Tag del prefab de Bola (en el inspector)
        {
            RebotarBola(collision);
        }
    }

    public virtual void RebotarBola(Collision collision)        //virtual para poder modificarlo en las clases que hereden de bloque
    {
        Vector3 direccion = collision.contacts[0].point - transform.position;   //vector igual al punto de colision del objeto colisionado menos la posicion del bloque (el centro del bloque). De la resta se obtiene un vector que va del centro hacia el punto de contacto
        direccion = direccion.normalized;       //magnitud de uno
        collision.rigidbody.velocity = collision.gameObject.GetComponent<Bola>().velocidadBola * direccion;     //se obtiene velocidad: obteniendo el gameObject de la colision, sacamos su componente de bola, y despues la propiedad de velocidad bola y luego se multiplica por direccion normalizado
        vidaBloque--;  //se resta resistencia al bloque
    }

    //private void Awake()
    //{
    //    vidaBloque = resistencia * opciones.multDificultad;
    //}

    // Start is called before the first frame update
    void Start()
    {
        vidaBloque = resistencia * opciones.multDificultad;
        bloquesRestantes = GameObject.FindGameObjectsWithTag("Bloque").Length;
        Debug.Log($"los bloques restantes son: {bloquesRestantes}");
    }

    // Update is called once per frame
    void Update()
    {
        if (vidaBloque <= 0)
        {
            AumentarPuntaje.Invoke();
            Destroy(this.gameObject);
            //bloquesRestantes--;
        }
        //if (bloquesRestantes <= 0)
        //{
 
        //    menuFinNivel.SiguienteNivel();
        //}
        //Debug.Log(bloquesRestantes);
    }

    private void OnDestroy()
    {
        bloquesRestantes--;

        Debug.Log("Bloque destruido. Restantes: " + bloquesRestantes);

        if (bloquesRestantes <= 0)
        {
            if (menuFinNivel == null)
            {
                menuFinNivel = FindObjectOfType<MenuFinNivel>();  // Safety net
            }

            if (menuFinNivel != null)
            {
                Debug.Log("Todos los bloques destruidos. Mostrando menú...");
                menuFinNivel.MostrarMenu();  // ? Show menu here, NOT next level
            }
            else
            {
                Debug.LogWarning("menuFinNivel es null. No se puede mostrar el menú.");
            }
        }
    }

    private void LateUpdate()
    {
        Debug.Log(bloquesRestantes);
    }

    public virtual void RebotarBola()       //virtual: las clases hijo puedan hacer overwrite al metodo que ya trae la clase padre. Nos permite hacer sobrecarga de ese metodo
    {

    }

    //public void RecalcularVida()
    //{
    //    vidaBloque = resistencia * opciones.multDificultad;
    //}

}
