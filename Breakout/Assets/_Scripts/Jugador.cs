using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    public Opciones opciones;
    [SerializeField] public int limiteX = 24;
    [SerializeField] public float velocidadPaddle;
    

    Transform transform;
    Vector3 mousePos2D;
    Vector3 mousePos3D;
    // Start is called before the first frame update
    void Start()
    {
        transform = this.gameObject.transform;
        opciones.Cargar();
        velocidadPaddle = opciones.velocidadJugador;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bola")
        {
            Vector3 direccion = collision.contacts[0].point - transform.position;
            direccion = direccion.normalized;
            collision.rigidbody.velocity = collision.gameObject.GetComponent<Bola>().velocidadBola * direccion;
        }
    }

    // Update is called once per frame
    void Update()
    {
        velocidadPaddle = opciones.velocidadJugador;

        mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //if (Input.GetKey(KeyCode.RightArrow))                                             //este codigo es para que se puedan usar las teclas, se comenta para usar control
        //{
        //    transform.Translate(Vector3.down * velocidadPaddle * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.Translate(Vector3.up * velocidadPaddle * Time.deltaTime);
        //}

        transform.Translate(Input.GetAxis("Horizontal") * Vector3.down * velocidadPaddle * Time.deltaTime);     //Para control gamer. deltaTime es la diferencia de tiempo que hay entre frames, suaviza el movimiento para que no se vea cortado
        //GetAxis funciona con cualquier control, joystick o teclado. "down" porque esta rotado 90 grados. (y -1?)

        Vector3 pos = transform.position;
        //pos.x = mousePos3D.x;                 //activar esta linea para jugar con mouse
        if (pos.x < -limiteX)
        {
            pos.x = -limiteX;
        }
        else if (pos.x > limiteX)
        {
            pos.x = limiteX;
        }
        transform.position = pos;
    }
}
