using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothesControl : MonoBehaviour
{
   public string Name;
   public int Price;
   public bool hasColorVariation;
   public Color SpriteColor;
   public Sprite Icon;
   public string Tag;

   void Start()
   {
      if(Price == 0) 
      {
         Price = 50;
      }

      if(Icon == null)
      {
         Icon = GetComponent<SpriteRenderer>().sprite;
      }  

      transform.name = Name;

      if(gameObject.GetComponent<SpriteRenderer>().color == new Color(0,0,0,0))
      {
         gameObject.GetComponent<SpriteRenderer>().color = SpriteColor;
      }

   }
   
}
