using System.Collections;
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
    // Start is called before the first frame update
    void Start()
    {
        repeticiones = x * y;
        Debug.Log("total repeticiones: " + repeticiones);
        totalCartaPorRepeticion = repeticiones / x;
        Debug.Log("Total cartas x repeticion:" + totalCartaPorRepeticion);
        for (int i=1; i <= repeticiones; i++)
        {
            GameObject miCarta = Instantiate(cartaPrefab, new Vector3(posicionX, posicionY, 0), Quaternion.identity);
            miCarta.name = ("Carta" + contador);
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
       /* for (int i = -5; i < 5; i += 2) { 
            GameObject miCarta = Instantiate(cartaPrefab, new Vector3(i+2, -3, 0), Quaternion.identity);
            miCarta.name = ("Carta" + contador);
            contador++;
            listaCartas.Add(miCarta);
        }

        for (int i = -5; i < 5; i += 2) {

            GameObject miCarta = Instantiate(cartaPrefab, new Vector3(i+2, 3, 0), Quaternion.identity);
            miCarta.name = ("Carta" + contador);
            contador++;
            listaCartas.Add(miCarta);
        }*/

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
