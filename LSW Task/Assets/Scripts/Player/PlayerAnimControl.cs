using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimControl : MonoBehaviour
{

    public List<Animator> Animators = new List<Animator>();
    public Animator BodyAnimtr;
    public Animator HairAnimtr;
    public Animator EyesAnimtr;
    public Animator UpperAnimtr;
    public Animator LowerAnimtr;
    public Animator FeetAnimtr;

    // Start is called before the first frame update
    void Start()
    {
        Animators.Add(BodyAnimtr);
        Animators.Add(HairAnimtr);
        Animators.Add(EyesAnimtr);
        Animators.Add(UpperAnimtr);
        Animators.Add(LowerAnimtr);
        Animators.Add(FeetAnimtr);
    }

    // Update is called once per frame
    void Update()
    {
        SkinMovementAnimationUpdate();
    }


    // Updates the reference of the Animator the entity Player uses to play the animations
    // Requires the GameObject of the new clothing
    public void AnimtrChange(GameObject newClothing) 
    {
        
        if(newClothing.tag == Tags.UpperClothes)
        {
            UpperAnimtr = newClothing.GetComponent<Animator>();
        }
        else if (newClothing.tag == Tags.LowerClothes)
        {
            LowerAnimtr = newClothing.GetComponent<Animator>();
        }
        else if (newClothing.tag == Tags.FeetClothes)
        {
            FeetAnimtr = newClothing.GetComponent<Animator>();
        }

        Animators.Clear();

        Animators.Add(BodyAnimtr);
        Animators.Add(HairAnimtr);
        Animators.Add(EyesAnimtr);
        Animators.Add(UpperAnimtr);
        Animators.Add(LowerAnimtr);
        Animators.Add(FeetAnimtr);
        
    }
    
    // Updates the Animations of all parts and clothing accordingly to the movement
    public void SkinMovementAnimationUpdate()
    {
        Vector2 MovValue = GetComponent<PlayerMovement>().movement;
        
        foreach (Animator animtr in Animators)
        {
            animtr.SetFloat("Horizontal",MovValue.x);
            animtr.SetFloat("Vertical",MovValue.y);
            animtr.SetFloat("Speed", MovValue.magnitude);
        }
    }
}
