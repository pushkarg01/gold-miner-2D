using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HookMovement : MonoBehaviour
{
    [SerializeField] float minZ = -55f, maxZ = 55f;
    [SerializeField] float rotateSpeed = 50f;
    private float rotateAngle;

    private bool canRotate;
    private bool rotateRight;
    private bool moveDown;

    public float moveSpeed = 3f;
    private float initialSpeed;

    [SerializeField] float minY = -2.5f;
    private float initialY;

   private RopeRenderer ropeRenderer;

    private void Awake()
    {
        ropeRenderer = GetComponent<RopeRenderer>();
    }

    void Start()
    {
        initialY = transform.position.y;
        initialSpeed = moveSpeed;

        canRotate = true;
    }

  
    void Update()
    {
        Rotate();
        GetInput();
        MoveRope();
    }

    void Rotate()
    {
        if (!canRotate) return;

        if (rotateRight)
        {
            rotateAngle += rotateSpeed * Time.deltaTime;
        }
        else
        {
            rotateAngle -= rotateSpeed * Time.deltaTime;
        }
        transform.rotation = Quaternion.AngleAxis(rotateAngle,Vector3.forward);

        if(rotateAngle >= maxZ)
        {
            rotateRight = false;
        }
        else if(rotateAngle <=minZ)
        {
            rotateRight = true;
        }
    }

    void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (canRotate)
            {
                canRotate = false;
                moveDown = true;

                SoundManager.instance.StreachingSound(true);
            }
        }
    }

    void MoveRope()
    {
        if (canRotate) return;

        if(!canRotate)
        {
            Vector3 temp = transform.position;
            if (moveDown)
            {
                temp -= transform.up * Time.deltaTime *moveSpeed;
            }
            else
            {
                temp += transform.up * Time.deltaTime * moveSpeed;
            }

            transform.position = temp;
            if(temp.y <= minY)
            {
                moveDown = false;
            }

            if(temp.y >= initialY)
            {
                canRotate = true;

                ropeRenderer.RenderLine(temp, false);
                moveSpeed = initialSpeed;

                SoundManager.instance.StreachingSound(false);
            }
            ropeRenderer.RenderLine(temp,true);
        }
    }

    public void HookAttachedItem()
    {
        moveDown=false;
    }
}
