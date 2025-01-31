using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    #region Animation Logic

    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();

    }

    public void IdleAnim()
    {
        anim.Play(AnimationTags.idleAnim);
    }

    public void PullAnim()
    {
        anim.Play(AnimationTags.ropeAnim);
    }
    #endregion
}
