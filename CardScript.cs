using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    public Sprite front, back;
    bool volteado = false;
    SpriteRenderer render;
    GameObject myGame;
    public string nombre;
    // Start is called before the first frame update
    private void Awake()
    {
        for (int i=0; i<=5; i++)
        {
            
        }
    }
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        myGame = GameObject.FindGameObjectWithTag("GameController");

    }
    private void OnMouseDown()
    {
        myGame.GetComponent<GameManager>().ClickonCard(nombre);

        if (volteado==false) 
        {
            render.sprite = front;
            volteado = true;

        } else
        {
            render.sprite = back;
            volteado=false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
