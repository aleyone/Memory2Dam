using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Cartas")]
    public GameObject cartaPrefab;
    float contador = 1;
    public List<GameObject> listaCartas;
    public int x, y;
    private int repeticiones, totalCartaPorRepeticion, posicionX, posicionY;
    public List<Sprite> cartasIniciales; // llena desde unity
    [SerializeField] private List<Sprite> baseCartas;
    public List<Sprite> cartasAleatorias; // vacía
    public List<string> tipoPersonajeInicial = new List<string> { "reina", "guardia", "asesino", "obispo", "alguacil", "bufon", "contable", "adulador", "baronesa", "cardenal" };
    public List<string> tipoPersonajeAleatorio;
    bool collidersActivos;
    string[] pareja = new string[2] { "", "" };
    public int cartaIndice;
    GameObject miCarta;
    public GameObject texto;
    public Button button;
    public int puntos = 0;

    // Start is called before the first frame update
    private void Awake()
    {
        button.onClick.AddListener(reiniciarPartida);
        repeticiones = x * y;
        totalCartaPorRepeticion = repeticiones / x;
    }

    void Start()
    {        
        repartoCartas();
    }
    public void repartoCartas() {
        posicionX = -8;
        posicionY = -3;
        repeticiones = x * y;
        totalCartaPorRepeticion = repeticiones / x;
        for (int j = 0; j < 5; j++)
        {
            int frontAleat = Random.Range(0, cartasIniciales.Count);
            cartasAleatorias.Add(baseCartas[frontAleat]);
            cartasAleatorias.Add(baseCartas[frontAleat]);
            tipoPersonajeAleatorio.Add(tipoPersonajeInicial[frontAleat]);
            tipoPersonajeAleatorio.Add(tipoPersonajeInicial[frontAleat]);
            cartasIniciales.RemoveAt(frontAleat);
            tipoPersonajeInicial.RemoveAt(frontAleat);

        }

        for (int i = 1; i <= repeticiones; i++)
        {
            miCarta = Instantiate(cartaPrefab, new Vector3(posicionX, posicionY, 0), Quaternion.identity);
            int random2 = Random.Range(0, cartasAleatorias.Count);
            miCarta.name = tipoPersonajeAleatorio[random2];
            miCarta.GetComponent<CardScript>().front = cartasAleatorias[random2];
            miCarta.GetComponent<CardScript>().nombre = tipoPersonajeAleatorio[random2];
            miCarta.GetComponent<CardScript>().indice = i - 1;
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
        texto.GetComponent<Text>().text = "Parejas: " + puntos;
    }

    public void ClickonCard(string nombre, int indice)
    {
        Debug.Log("Hola, soy " + nombre);
        if (pareja[0] == "")
        {
            pareja[0] = nombre;
            cartaIndice = indice;
        }
        else
        {
            pareja[1] = nombre;
            
        } 
            

        if (pareja[0] != "" && pareja[1] != "")
        {
           
            if (pareja[0] == pareja[1])
            {
                Debug.Log("Pareja");
                pareja[0] = "";
                pareja[1] = "";
                listaCartas[cartaIndice].SetActive(false);
                listaCartas[indice].SetActive(false);
                puntos++;
                calculoPuntos();
                
            }
            else
            {
                Debug.Log("No pareja");
                pareja[0] = "";
                pareja[1] = "";
                StartCoroutine(WaitAndPrint(indice));
                fundirmeColliders(false);

            }
        }
    }

    IEnumerator WaitAndPrint(int indice)
    {       
        yield return new WaitForSeconds(2);
        listaCartas[cartaIndice].GetComponent<CardScript>().Toggle();
        listaCartas[indice].GetComponent<CardScript>().Toggle();
        fundirmeColliders(true);
    }

    public void calculoPuntos()
    {
        texto.GetComponent<Text>().text ="Parejas: " + puntos;
        if (puntos == 5)
        {
            texto.GetComponent<Text>().text = "JUEGO FINALIZADO";
        }
    }

    public void fundirmeColliders(bool enable)
    {
        for (int i = 0; i < listaCartas.Count; i++)
        {
            listaCartas[i].GetComponent<BoxCollider2D>().enabled = enable;
        }
    }

    public void reiniciarPartida()
    {
        StopAllCoroutines();
        Debug.Log("Reiniciamos");
        for (int i = 0; i < listaCartas.Count; i++)
        {
            Destroy(listaCartas[i], 0);
            listaCartas[i].GetComponent<CardScript>().volteado = false;
            listaCartas[i].GetComponent<SpriteRenderer>().sprite = listaCartas[i].GetComponent<CardScript>().back;           
        }
        cartasIniciales.Clear();
        tipoPersonajeAleatorio.Clear();
        cartasAleatorias.Clear();
        listaCartas.Clear();
        tipoPersonajeInicial.Clear();        
        fundirmeColliders(true);
        tipoPersonajeInicial = new List<string> { "reina", "guardia", "asesino", "obispo", "alguacil", "bufon", "contable", "adulador", "baronesa", "cardenal" };
        for (int i = 0; i < baseCartas.Count; i++)
        {
            cartasIniciales.Add(baseCartas[i]);
        }
        puntos = 0;
        cartaIndice = 0;        
        repartoCartas();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
