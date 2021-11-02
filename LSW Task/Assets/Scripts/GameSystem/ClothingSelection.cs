using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothingSelection : MonoBehaviour
{

    public GameObject Player;

    public GameObject NewClothing;

    private PlayerAnimControl AnimControl;

    
    void Start()
    {
        AnimControl = Player.GetComponent<PlayerAnimControl>();
    }


    void Update()
    {
        
    }

    public void debugOnClick()
    {
        SpawnNewClothingPiece("Upper","UpperClothes");
    }

    public void SpawnNewClothingPiece(string partName,string TagName)
    {
        string part = partName;
        GameObject oldClothing = GameObject.FindWithTag(TagName);
        Destroy(oldClothing);

        GameObject cloth = Instantiate(NewClothing,Player.transform);
        AnimControl.AnimtrChange(part, cloth.GetComponent<Animator>());
        
    }

}

