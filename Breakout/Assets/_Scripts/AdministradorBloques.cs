using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorBloques : MonoBehaviour
{
    public GameObject MenuFinNivel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount == 0)  //si este objeto tiene hijos, preguntamos cuantos hijos tiene y si su cantidad es zero activamos el menu
        {
            MenuFinNivel.SetActive(true);
        }
    }
}
