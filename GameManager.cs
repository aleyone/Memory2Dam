﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cartaPrefab;
    float contador = 1;
    public List<GameObject> listaCartas = new List<GameObject>();
    public int x, y;
    private int repeticiones;
    private int totalCartaPorRepeticion;
    private int posicionX = -8;
    private int posicionY = -3;
    public List<Sprite> cartasIniciales; // llena desde unity
    public List<Sprite> cartasAleatorias; // vacía
    public List<string> tipoPersonajeInicial = new List<string> { "reina", "guardia", "asesino", "obispo", "alguacil", "bufon", "contable", "adulador", "baronesa", "cardenal" };
    public List<string> tipoPersonajeAleatorio;
    bool hayPareja = false;
    string[] pareja = new string[2] { "", "" };
    GameObject miCarta;

    // Start is called before the first frame update
    void Start()
    {
        repeticiones = x * y;
       // Debug.Log("total repeticiones: " + repeticiones);
        totalCartaPorRepeticion = repeticiones / x;
        // Debug.Log("Total cartas x repeticion:" + totalCartaPorRepeticion);

        for (int j = 0; j < 5; j++)
        {
            int frontAleat = Random.Range(0, cartasIniciales.Count);
            cartasAleatorias.Add(cartasIniciales[frontAleat]);
            cartasAleatorias.Add(cartasIniciales[frontAleat]);
            tipoPersonajeAleatorio.Add(tipoPersonajeInicial[frontAleat]);
            tipoPersonajeAleatorio.Add(tipoPersonajeInicial[frontAleat]);
            cartasIniciales.RemoveAt(frontAleat);
            tipoPersonajeInicial.RemoveAt(frontAleat);

        }

        for (int i=1; i <= repeticiones; i++)
        {
           miCarta = Instantiate(cartaPrefab, new Vector3(posicionX, posicionY, 0), Quaternion.identity);
            
            int random2 = Random.Range(0, cartasAleatorias.Count);
            miCarta.name = tipoPersonajeAleatorio[random2];
            miCarta.GetComponent<CardScript>().front = cartasAleatorias[random2];
            miCarta.GetComponent<CardScript>().nombre = tipoPersonajeAleatorio[random2];
            cartasAleatorias.RemoveAt(random2);
            tipoPersonajeAleatorio.RemoveAt(random2);
            contador++;
            listaCartas.Add(miCarta);

            posicionX += 2;
            if (i == totalCartaPorRepeticion)
            {
                posicionX = -8;
                posicionY += 3;
                totalCartaPorRepeticion += repeticiones / x;
            }
        }
    }

    public void ClickonCard(string nombre)
    {
        Debug.Log("Hola, soy " + nombre);
        if (pareja[0] == "")
        {
            pareja[0] = nombre;
        }
        else pareja[1] = nombre;
        if (pareja[0] != "" && pareja[1] != "")
        {
            if (pareja[0] == pareja[1])
            {
                Debug.Log("Pareja");
                pareja[0] = "";
                pareja[1] = "";
            }
            else
            {
                Debug.Log("No pareja");
                pareja[0] = "";
                pareja[1] = "";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
