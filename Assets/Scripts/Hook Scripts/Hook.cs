using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField] private Transform itemHolder;
    private bool itemAttached;

    private HookMovement hookMove;

    private PlayerAnimation anim;

    void Awake()
    {
        hookMove = GetComponentInParent<HookMovement>();
        anim = GetComponentInParent<PlayerAnimation>();
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == Tags.smallStone || target.tag == Tags.largeStone || target.tag == Tags.smallGold ||
            target.tag == Tags.largeGold || target.tag == Tags.middleGold)
        {
            itemAttached = true;

            target.transform.parent = itemHolder;
            target.transform.position = itemHolder.position;

            hookMove.moveSpeed = target.GetComponent<Items>().hookSpeed;
            hookMove.HookAttachedItem();

            anim.PullAnim();

            if (target.tag == Tags.smallGold || target.tag == Tags.middleGold || target.tag == Tags.largeGold)
            {
                SoundManager.instance.GoldSound();
            }
            else if( target.tag == Tags.largeStone || target.tag == Tags.smallStone)
            {
                SoundManager.instance.StoneSound();
            }

            SoundManager.instance.PullSound(true);
        }

        if(target.tag == Tags.deliverItems)
        {
            if (itemAttached)
            {
                itemAttached = false;

                Transform objChild =itemHolder.GetChild(0);
                objChild.parent = null;
                objChild.gameObject.SetActive(false);

                anim.IdleAnim();

                SoundManager.instance.PullSound(false);
            }
        }
    }
}
