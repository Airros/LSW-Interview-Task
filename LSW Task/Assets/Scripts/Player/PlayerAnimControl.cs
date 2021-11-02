using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimControl : MonoBehaviour
{

    public Animator BodyAnimtr;
    public Animator HairAnimtr;
    public Animator UpperAnimtr;
    public Animator LowerAnimtr;
    public Animator FeetAnimtr;

    // Start is called before the first frame update
    void Start()
    {
        // Animator OriginBody = GameObject.FindWithTag(Tags.Body).GetComponent<Animator>();
        // Animator OriginUpper = GameObject.FindWithTag(Tags.UpperClothes).GetComponent<Animator>();
        // Animator OriginLower = GameObject.FindWithTag(Tags.LowerClothes).GetComponent<Animator>();
        // Animator OriginFeet = GameObject.FindWithTag(Tags.FeetClothes).GetComponent<Animator>();

        // AnimtrChange("Body", OriginBody);
        // AnimtrChange("Upper", OriginUpper);
        // AnimtrChange("Lower", OriginLower);
        // AnimtrChange("Feet", OriginFeet);
    }

    // Update is called once per frame
    void Update()
    {
        SkinMovementAnimationUpdate();
    }


    // Updates the reference of the Animator the entity Player uses to play the animations
    // Requires the name of the Clothing the change has been made to and the new Animator from the new GameObject;
    public void AnimtrChange(string part, Animator name) 
    {

        if(part == "Body")
        {
            BodyAnimtr = name;
            return;
        } 
        if(part == "Upper") 
        {
            UpperAnimtr = name;
            return;
        }
        if(part == "Lower")
        {
            LowerAnimtr = name;
            return;
        }
        if(part == "Feet")
        {
            FeetAnimtr = name;
            return;
        }
        
        
    }
    
    // Updates the Animation accordingly to the movement
    public void SkinMovementAnimationUpdate()
    {
        Vector2 MovValue = GetComponent<PlayerMovement>().movement;

        BodyAnimtr.SetFloat("Horizontal",MovValue.x);
        BodyAnimtr.SetFloat("Vertical",MovValue.y);
        BodyAnimtr.SetFloat("Speed", MovValue.magnitude);

        if(HairAnimtr !=  null)
        {
            HairAnimtr.SetFloat("Horizontal",MovValue.x);
            HairAnimtr.SetFloat("Vertical",MovValue.y);
            HairAnimtr.SetFloat("Speed", MovValue.magnitude);
        }

        if(UpperAnimtr !=  null)
        {
            UpperAnimtr.SetFloat("Horizontal",MovValue.x);
            UpperAnimtr.SetFloat("Vertical",MovValue.y);
            UpperAnimtr.SetFloat("Speed", MovValue.magnitude);
        }

        if(LowerAnimtr !=  null)
        {
            LowerAnimtr.SetFloat("Horizontal",MovValue.x);
            LowerAnimtr.SetFloat("Vertical",MovValue.y);
            LowerAnimtr.SetFloat("Speed", MovValue.magnitude);
        }
        
        if(FeetAnimtr !=  null)
        {
            FeetAnimtr.SetFloat("Horizontal",MovValue.x);
            FeetAnimtr.SetFloat("Vertical",MovValue.y);
            FeetAnimtr.SetFloat("Speed", MovValue.magnitude);
        }

    }
}
