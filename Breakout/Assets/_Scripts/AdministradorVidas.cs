using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorVidas : MonoBehaviour
{
    [HideInInspector] public List<GameObject> vidas;    //variable publica para que otros objetos puedan acceder a ella por medio de codigo pero que no podamos ver en el inspector
    public GameObject bolaPrefab;   //gameobject que hace referencia al prefab de la bola
    public Bola bolaScript; //un objeto de tipo bola que hara referencia al componente bola que es un script con la logica d la bola. Un GameObject no es lo mismo que un script que lo controla, un script es un componente mas
    public GameObject MenuFinJuego;

    // Start is called before the first frame update
    void Start()
    {
        Transform[] hijos = GetComponentsInChildren<Transform>();   //va guardar todos los transform de los hijos que hay en esta coleccion de game objects. Si nosotros vamos al GO "AdminVidas" que es como el papa y de hijo tiene a las 3 vidas. Obtendriamos las transform de cada imagen de vida
        foreach (Transform hijo in hijos)   //vamos a recorrer cada uno de ellos y adquirir su gameObject
        {
            vidas.Add(hijo.gameObject); //una vez adquirido su gameObject se guarda en la lista "vidas"
        }
    }

    public void EiminarVida()
    {
        var objetoAEliminar = vidas[vidas.Count - 1];   //seleccionar un objeto a eliminar; que es la ultima vida que esta registrada en nuestro gameobject
        Destroy(objetoAEliminar);   //destruye ese gameobject (ultima vida registrada)
        vidas.RemoveAt(vidas.Count - 1);    //que lo remueva de la lista
        if (vidas.Count <= 0)   //si llegamos a cero vidas se activa el fin de juego menu
        {
            MenuFinJuego.SetActive(true);
            return;
        }
        var bola = Instantiate(bolaPrefab) as GameObject;   //en caso de que ultima vida no suceda; se va crear una nueva bola instanciadola como una gameobject. haciendo casteo explicito con la palabra as
        //bola.
        bolaScript = bola.GetComponent<Bola>(); //obtener su componente Bola
        bolaScript.BolaDestruida.AddListener(this.EiminarVida); //en el script Bola; ya hemos creado el unityEvent destruir bola "BolaDestruida". Se le agrega un listener, nos suscribimos a ese evento desde codigo
        Debug.Log($"Vidas restantes: {vidas.Count}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
