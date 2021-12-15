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
    public List<Sprite> cartasIniciales; // llena desde unity
    public List<Sprite> cartasAleatorias; // vacía
    
    // Start is called before the first frame update
    void Start()
    {
        repeticiones = x * y;
        Debug.Log("total repeticiones: " + repeticiones);
        totalCartaPorRepeticion = repeticiones / x;
        Debug.Log("Total cartas x repeticion:" + totalCartaPorRepeticion);

        for (int j = 0; j < 5; j++)
        {
            int frontAleat = Random.Range(0, cartasIniciales.Count);
            Debug.Log(frontAleat);
            cartasAleatorias.Add(cartasIniciales[frontAleat]);
            cartasAleatorias.Add(cartasIniciales[frontAleat]);
            cartasIniciales.RemoveAt(frontAleat);

        }

        for (int i=1; i <= repeticiones; i++)
        {
            GameObject miCarta = Instantiate(cartaPrefab, new Vector3(posicionX, posicionY, 0), Quaternion.identity);
            miCarta.name = ("Carta" + contador);
            int random2 = Random.Range(0, cartasAleatorias.Count);
            miCarta.GetComponent<CardScript>().front = cartasAleatorias[random2];
            cartasAleatorias.RemoveAt(random2);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
