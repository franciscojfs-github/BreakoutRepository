using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    [SerializeField] public int limiteX = 24;
    [SerializeField] public float velocidadPaddle = 30f;
    
    Transform transform;
    Vector3 mousePos2D;
    Vector3 mousePos3D;
    // Start is called before the first frame update
    void Start()
    {
        transform = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos2D = Input.mousePosition;
        mousePos2D.z = -Camera.main.transform.position.z;
        mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //Vector3 pos = this.transform.position;
        //Vector3 posMouse = transform.position;        //linea de codigo irrelevante, se trato de agregar con el else para tratar de que funcionara con teclas y mouse al mismo tiempo

        //if (Input.GetKey(KeyCode.RightArrow))                                             //este codigo es para que se puedan usar las teclas, se comenta para usar control
        //{
        //    transform.Translate(Vector3.down * velocidadPaddle * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.Translate(Vector3.up * velocidadPaddle * Time.deltaTime);
        //}
        ////////////else
        ////////////{
        ////////////    posMouse.x = mousePos3D.x;        //se trato de que funcionara con ambos mouse  y teclas pero no se puede asi
        ////////////}

        transform.Translate(Input.GetAxis("Horizontal") * Vector3.down * velocidadPaddle * Time.deltaTime);     //Para control gamer. deltaTime es la diferencia de tiempo que hay entre frames
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

        ////////////Vector3 posMouse = transform.position;  //se trato de hacer que funcionara las teclas y mouse al mismo tiempo pero no se logro
        ////////////posMouse.x = mousePos3D.x;
        ////////////if (posMouse.x < -limiteX)
        ////////////{
        ////////////    posMouse.x = -limiteX;
        ////////////}
        ////////////else if (posMouse.x > limiteX)
        ////////////{
        ////////////    posMouse.x = limiteX;
        ////////////}
        ////////////transform.position = posMouse;        //como al final queda guardada la posicion del mouse para mover al jugador, ya no le hace caso al transfor.position de las teclas antes de frame update
    }
}
