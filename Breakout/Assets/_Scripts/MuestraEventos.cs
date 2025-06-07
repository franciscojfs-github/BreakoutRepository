using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MuestraEventos : MonoBehaviour
{
    public event EventHandler OnSpacePressed;    //EnCasoDeEspacioPresionado. Evento de tipo .NET
    public UnityEvent MiEventoUnity;        // Evento tipo UnityEvent; se puede modificar desde el Inspector mas facilmente sin tanto codigo
      
    // Start is called before the first frame update
    void Start()
    {
        OnSpacePressed += EventoEscuchado;
        // += en este contexto: suscribe a method (EventoEscuchado) to an event (OnSpacePressed); no es como x += 1 donde se sumaba, es diferente
        // like saying: "Hey event (OnSpacePressed), when you happen, also call this method (EventoEscuchado)"
        // Adding a function to a list of functions the event will call when triggered
        // Se puede subscribir a multiples eventos: (cuando el evento es invocado, se llaman todos)
            // OnSpacePressed += MethodA;
            // OnSpacePressed += MethodB;
            // OnSpacePressed -= EventoEscuchado; tambien se puede quitar de la lista de listeners
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            OnSpacePressed?.Invoke(this, EventArgs.Empty);  // se deja el "?" como best practice porque ayuda a no crashe. En caso que no haya nadie suscrito a OnSpacePressed y se llame al .Invoke; regresaria null y crashearia, por eso primero se checa con el ?. 
                                                            // this = sender of event (tells the listener who triggered it). En este caso la instancia de MuestraEventos
            MiEventoUnity.Invoke();
        }
    }

    public void EventoEscuchado(object sender, EventArgs e)
    {
        Debug.Log("el evento se escucho correctamente");
    }

    public void EventoUnityDisparado()
    {
        Debug.Log("El evento Unity se disparo correctamente");
    }
}
