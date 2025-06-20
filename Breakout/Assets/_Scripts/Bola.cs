using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bola : MonoBehaviour
{
    bool isGameStarted = false;
    [SerializeField]public float velocidadBola;
    Vector3 ultimaPosicion = Vector3.zero;  //en que posicion fue la ultima que estuvimos antes de colisionar con borde. Se va detectar en FixedUpdate (pasa menos), lo que va permitir que la ultima posicion sea distninta a la posicion que se tiene en el actual update
    Vector3 direccion = Vector3.zero;   // conociendo la ultima posicion y la posicion donde se toco el borde; se encuentra la direccion para rebotar en dicho borde
    Rigidbody rigidbody;    //para controlar la direccion en la que va rebotar
    private ControlBordes control;  // sirve para que atachando el script de ControlBordes podamos tener acceso a toda la funcionalidad de ese script
    public UnityEvent BolaDestruida;    //para llamar OnDestroy
    public Opciones opciones;
    public Bloque bloque;

    private void Awake()
    {
        control = GetComponent<ControlBordes>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Vector3 posicionInicial = GameObject.FindGameObjectWithTag("Jugador").transform.position;
        posicionInicial.y += 3;
        this.transform.position = posicionInicial;
        this.transform.SetParent(GameObject.FindGameObjectWithTag("Jugador").transform);

        rigidbody = this.gameObject.GetComponent<Rigidbody>();  //se agrega la obtencion de lo que es el rigidbody




        //if (opciones.NivelDificultad == Opciones.dificultad.Facil)    // causa un corner case que si cambias la dificultad y no has lanzado la bola, la dificultad se va a cambiar hasta la siguiente vida, por eso mejor en update
        //{
        //    velocidadBola = 10;
        //}
        //else if (opciones.NivelDificultad == Opciones.dificultad.Normal)
        //{
        //    velocidadBola = 30;
        //}
        //else if (opciones.NivelDificultad == Opciones.dificultad.Dificil)
        //{
        //    velocidadBola = 60;
        //}

    }

    // Update is called once per frame
    void Update()
    {     
        //logica de rebote
        if (control.salioAbajo)
        {
            BolaDestruida.Invoke();     //manda a llamar el unity event que se creo
            Destroy(this.gameObject);
        }
        if (control.salioArriba)
        {
            direccion = transform.position - ultimaPosicion;
            Debug.Log("La bola toco el borde superior");
            direccion.y *= -1;    //que cambie de direccion hacia la contraria
            direccion.Normalize();
            rigidbody.velocity = velocidadBola * direccion;
            control.salioArriba = false;
            control.enabled = false;        //ultimas dos lineas de codigo son por si corre muy rapido la pc varios frames por segundo (se queda trabada la bola en el borde)
            Invoke("HabilitarControl", 0.2f);   //dpues de 0.5f (medio segundo) lo mande a habilitar
        }
        if (control.salioDerecha)
        {
            direccion = transform.position - ultimaPosicion;
            Debug.Log("La bola toco el borde derecho");
            direccion.x *= -1;    //que cambie de direccion hacia la contraria
            direccion.Normalize();
            rigidbody.velocity = velocidadBola * direccion;
            control.salioDerecha = false;
            control.enabled = false;        //ultimas dos lineas de codigo son por si corre muy rapido la pc varios frames por segundo (se queda trabada la bola en el borde)
            Invoke("HabilitarControl", 0.2f);   //dpues de 0.5f (medio segundo) lo mande a habilitar
        }
        if (control.salioIzquierda)
        {
            direccion = transform.position - ultimaPosicion;
            Debug.Log("La bola toco el borde izquierdo");
            direccion.x *= -1;    //que cambie de direccion hacia la contraria
            direccion.Normalize();
            rigidbody.velocity = velocidadBola * direccion;
            control.salioIzquierda = false;
            control.enabled = false;        //ultimas dos lineas de codigo son por si corre muy rapido la pc varios frames por segundo (se queda trabada la bola en el borde)
            Invoke("HabilitarControl", 0.2f);   //dpues de 0.5f (medio segundo) lo mande a habilitar
        }

        //controles

        if (Input.GetKey(KeyCode.Space) || Input.GetButton("Submit"))
        {
            if(!isGameStarted)
            {
                isGameStarted = true;
                //bloque.vidaBloque = bloque.resistencia * opciones.multDificultad;

                //Bloque[] todosBloques = FindObjectsOfType<Bloque>();
                //foreach (Bloque b in todosBloques)
                //{
                //    b.RecalcularVida();
                //}

                switch (opciones.NivelDificultad)
                {
                    case Opciones.dificultad.Facil:
                        velocidadBola = 20;
                        break;

                    case Opciones.dificultad.Normal:
                        velocidadBola = 25;
                        break;

                    case Opciones.dificultad.Dificil:
                        velocidadBola = 30;
                        break;
                }

                this.transform.SetParent(null);
                GetComponent<Rigidbody>().velocity = velocidadBola * Vector3.up;
            }
        }
    }

    private void HabilitarControl()
    {
        control.enabled = true;
    }

    public void FixedUpdate()
    {
        ultimaPosicion = transform.position;
        
        //if (opciones.NivelDificultad == Opciones.dificultad.Facil)
        //{
        //    velocidadBola = 10;
        //}
        //else if (opciones.NivelDificultad == Opciones.dificultad.Normal)
        //{
        //    velocidadBola = 30;
        //}
        //else if (opciones.NivelDificultad == Opciones.dificultad.Dificil)
        //{
        //    velocidadBola = 60;
        //}
    }

    private void LateUpdate()
    {
        if (direccion != Vector3.zero) direccion = Vector3.zero;
    }


}
