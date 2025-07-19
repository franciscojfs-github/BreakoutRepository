using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Puntaje2 : MonoBehaviour
{
    public Transform transformPuntajeAlto;
    public Transform transformPuntajeActual;
    public TMP_Text textoPuntajeAlto;       // text mesh pro texto
    public TMP_Text textoPuntajeActual;
    public PuntajeAlto2 puntajeAltoSO;       // puntajeAlto del ScriptableObject
    // Start is called before the first frame update
    void Start()
    {
        transformPuntajeAlto = GameObject.Find("PuntajeAlto").transform;
        transformPuntajeActual = GameObject.Find("PuntajeActual").transform;
        textoPuntajeAlto = transformPuntajeAlto.GetComponent<TMP_Text>();
        textoPuntajeActual = transformPuntajeActual.GetComponent<TMP_Text>();

        puntajeAltoSO.Cargar(); //El monobehavior puede hacer uso de Cargar porque PuntajeAlto hereda de ObjetoPersistente
        //if (PlayerPrefs.HasKey("PuntajeAlto"))        // ahora en vez de usar PlayerPrefs. usamos ScriptableObject (del script PuntajeAlto.cs)
        //{
            //puntajeAlto = PlayerPrefs.GetInt("PuntajeAlto");
        textoPuntajeAlto.text = $"Puntaje Alto: {puntajeAltoSO.puntajeAlto}";
        //}
        puntajeAltoSO.puntajeActual = 0;
    }

    private void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {
        textoPuntajeActual.text = $"Puntaje Actual: {puntajeAltoSO.puntajeActual}";
        if (puntajeAltoSO.puntajeActual > puntajeAltoSO.puntajeAlto)
        {
            puntajeAltoSO.puntajeAlto = puntajeAltoSO.puntajeActual;
            textoPuntajeAlto.text = $"Puntaje Alto: {puntajeAltoSO.puntajeAlto}";
            puntajeAltoSO.Guardar();
            //PlayerPrefs.SetInt("PuntajeAlto", puntajeActual);
        }
    }

    public void AumentarPuntaje(int puntos)
    {
        puntajeAltoSO.puntajeActual += puntos;
    }
}
