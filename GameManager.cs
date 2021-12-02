using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cartaPrefab;
    float contador = 1;
    public List<GameObject> listaCartas = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = -5; i < 5; i += 2) { 
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
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
