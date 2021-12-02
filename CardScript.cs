using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    public Sprite spriteBack;
   
    GameObject carta;
    // Start is called before the first frame update
    void Start()
    {

        GetComponent<SpriteRenderer>().sprite = spriteBack;
        transform.position = new Vector3(3, 3, 0);
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
