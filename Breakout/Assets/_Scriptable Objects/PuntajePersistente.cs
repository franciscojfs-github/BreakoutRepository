using System.Collections;
using System.Collections.Generic;
using System.IO;    // permite acceder al disco duro de la PC
using System.Runtime.Serialization.Formatters.Binary; // crea un archivo binario de nuestro save file. solo la pc entiende este formato, no se puede abrir facilmente
using UnityEngine;

public abstract class PuntajePersistente : ScriptableObject  // Tipo ScriptableObject. abstract = la unica manera de acceder a este metodo o hacer uso de ellos es heredando de esta clase. esta clase ya es scriptable object, ahora necesitamos una clase que herede de ella. Y entonces hacemos que PuntajeAlto herede de ella.
{
    // se utiliza Jason para crear archivo de guardado, un lenguaje intermedio que permite comunicar con otros lenguajes
    // va crear un objeto que permite mandar a otros servicios.
    // ejmplo: si hicieramos un servicio de base de datos en phyton que se almacena en la nube y quisieramos accederlo desde nuestro juego en Unity; habria que hacer que el servicio en la nube regrese los datos de la nube en Jason.
    // Start is called before the first frame update
    // se crean rutas para guardar, cargar y obtener la ruta de carpeta

    public void Guardar(string nombreArchivo = null)    //crear variable que voy a recibir como argumento; seteando un valor por defecto en caso de que la funcion que le esta llamando no de ningun parametro y por lo tanto sea nulo en caso de no recibir dicho parametro
    {
        var bf = new BinaryFormatter(); // creando el BinaryFormatter que ayuda a guardar archivo en formato binario 
        var file = File.Create(ObtenerRuta(nombreArchivo));       // se usa la clase file que viene en el namespace de System.IO. Ahora necesitamos pasarle una ruta a nuestro metodo para poder crear el archivo. 
        var json = JsonUtility.ToJson(this);    //crear objeto jason que es un string. con jasonutility guardar los datos de esta clase dentro de ese archivo jason (que es un string)

        bf.Serialize(file, json);   //se va guardar en nuestro archivo que ya creamos
        file.Close();   //siempre que se abra, lea, modifique o lo que sea un archivo se debe cerrar
    }

    public virtual void Cargar(string nombreArchivo = null)     //virtual = cualquier clase que herede de esta clase va a poder hacer una sobre carga de este metodo y modificarlo
    {
        if (File.Exists(ObtenerRuta(nombreArchivo)))
        {
            var bf = new BinaryFormatter(); //igual se crea binaryformater
            var file = File.Open(ObtenerRuta(nombreArchivo), FileMode.Open);    //usamos file.open (file script), para abirir necesitamos ruta, y como lo va abrir? con filemode.open
            JsonUtility.FromJsonOverwrite((string)bf.Deserialize(file), this);  //fromjasonoverwrite vamos a obtener una representacion de lo que nos de el binaryformater con su metodo deserialize; el cual recibe dos argumentos, el archivo y que objeto va guardar esos datos (this = en esta misma clase)
            //si PuntajeAlto hereda de PuntajePersistente; si tenemos en Jason los datos que son relevantes para PuntajeAlto (puntajeActual y puntajeAlto), se van a guardar si es que el archivo existe
            file.Close();
        }
    }

    public string ObtenerRuta(string nombreArchivo = null)  //Crear metodo para crear la ruta de archivo
    {
        var nombreArchivoCompleto = string.IsNullOrEmpty(nombreArchivo) ? name : nombreArchivo; //pregunta si el string esta nulo/vacio. En caso que si, el name (nombre de la clase) va ser el que este guardado (mouse over). En caso que no se usa el nombre del archivo
        return string.Format("{0}/{1}.ebac", Application.persistentDataPath, nombreArchivoCompleto);    //regresa 0 y 1 (parametros de application.persistendatapath (donde unity puede guardar cosas) + nombre del archivo. ".ebac" se puede cambiar por lo que queramos, es la extension.
    }

}
