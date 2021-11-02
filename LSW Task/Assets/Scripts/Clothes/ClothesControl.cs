using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesControl : MonoBehaviour
{
    public Color SpriteColor;

    // Start is called before the first frame update
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
