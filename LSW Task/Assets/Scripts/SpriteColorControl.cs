using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteColorControl : MonoBehaviour
{
    // Start is called before the first frame update
    public Color SpriteColor;
    
    void Start()
    {
        GetComponent<SpriteRenderer>().color = SpriteColor;  
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<SpriteRenderer>().color = SpriteColor;  
    }
}
