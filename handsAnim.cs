using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class handsAnim : MonoBehaviour
{
    public Rigidbody rb;

    public GameObject firstPersonControll;
    public GameObject stamina;
    public GameObject PlayerFightAudio;

    public Animator anim;
    
    public bool isAttacking = false; // is supposed to prevent enemy from taking damage when player doesn't attack (disables/enables weapon's collider) (TEMP)
    public bool canAttack; 
    public bool IsGrounded = false;

    private float attackSpeed;  
    public float attackSpeedRateStats = 1f; // will be chaged from weapon script (TEMP) 
    public float playerSpeed; // used for animations

    public  int animTypeAttack;

    void Start()
    {
        attackSpeed = 1f;
        canAttack = true;
    }

    
    void Update()
    { 
        float playerSpeed = rb.velocity.magnitude;
        attackSpeed -= Time.deltaTime;
        anim.SetFloat("playerSpeed", playerSpeed);

        //Debug.Log(playerSpeed);
        
        if (Input.GetMouseButtonDown(0) && attackSpeed < 0 && canAttack == true)
        {
            Strike();
            stamina.GetComponent<staminaBarScript>().UseStamina();
            attackSpeed = attackSpeedRateStats;

            //Calls random player shouts when attacking (INSPECTOR: Player > PlayerAudio > FightAudio > playerFigthAudio.cs)
            PlayerFightAudio.GetComponent<playerFightAudio>().PlayerFightAudio();
        }
       

    }

    // Function picks random animation attack, 0 swings from right to left side, 1 swings from left to right
    public void Strike()
    {
        animTypeAttack = Random.Range(0, 2);
        //isAttacking enables the weapon collider what makes enemy take damage (will be changed)
        isAttacking = true;

        if (animTypeAttack == 0 )
        {
            anim.SetTrigger("Attack1");
        }

        if (animTypeAttack == 1 )
        {
            anim.SetTrigger("Attack2");
        }

        Invoke("ResetisAttacking", 0.1f);
    }  
 
     void ResetisAttacking()
    {
        //isAttacking = false;
    }

   

}
