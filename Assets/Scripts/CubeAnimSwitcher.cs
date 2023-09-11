using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeAnimSwitcher : MonoBehaviour
{

    Animator anim;
    AnimationClip[] animations;
    System.Random rnd = new System.Random();

    private void Awake()
    {
        anim = GetComponent<Animator>();

        if(anim != null)
        {
            animations = anim.runtimeAnimatorController.animationClips;
        }
    }

    private void PlayRandomAnimation()
    {
        int animIndex = rnd.Next(0, animations.Length);
        Debug.Log(animations[animIndex].name);
        anim.SetTrigger(animations[animIndex].name);
    }

}
