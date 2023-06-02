using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Animator attackAnim;

    float animatorOffTimer = 0f;



    void Awake()
    {
        attackAnim.enabled = false;
    }

    void Update()
    {
        animatorOffTimer -= Time.deltaTime;

        if (Input.GetMouseButtonDown(0))
        {           
            Strike();
            AnimatorOff();
        }
        
        if(animatorOffTimer < 0)
        {
            attackAnim.enabled = false;
        }

        


    }

    private void Strike()
    {
        attackAnim.SetInteger("AttackIndex", Random.Range(0, 2));
        attackAnim.SetTrigger("Attack");
    }

    private void AnimatorOff()
    {
        animatorOffTimer = 2f;

       if(animatorOffTimer > 0)
        {
            attackAnim.enabled = true;
        }

    }

}
