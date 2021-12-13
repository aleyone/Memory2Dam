using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    public Sprite front, back;
    bool volteado = false;
    SpriteRenderer render;
    // Start is called before the first frame update
    void Start()
    {

        render = GetComponent<SpriteRenderer>();

    }
    private void OnMouseDown()
    {
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
