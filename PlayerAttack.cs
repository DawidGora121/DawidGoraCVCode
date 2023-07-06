using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MilkShake;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerAttack : MonoBehaviour
{
    public Animator attackAnim;

    private float animatorOffTimer = 0f;           //Disables animator     --->                                   /* Weapon root sway doesn't work properly when the animator is enabled so it is off when player doesn't attack */
    private float attackRate;                      //Attack couldown is set by WeaponStats.cs script

    public Shaker MyShaker;                        //Camera shake asset
    public ShakePreset MyStrikePreset;             //Camera shake asset

    public static float AttackCouldown = 0.5f;
    public static float weaponDamage;              //Weapon damage is set from WeaponStats.cs script

    public static bool attackStaminaEnough;        //Checks if player has enough stamina swtiched by Stamina.cs script
    public static bool weaponColl;                 //Enables/disables colliders on the weapon to prevent enemies from taking damage when player is not attacking

    
    void Awake()
    {
      weaponColl = false;
      attackAnim.enabled = false;
      attackStaminaEnough = true;
    }                                                                                                    

    void Update()
    {                                                                                                                                
        if(AttackCouldown > 0)
           AttackCouldown -= Time.deltaTime;

        if (animatorOffTimer > 0)
            animatorOffTimer -= Time.deltaTime;


        bool canAttack = RigidbodyFirstPersonController.canAttack;   //Checks if the player is able to attack from RigidbodyFirstPersonController.cs
        bool isParkouring = PlayerController.IsParkour;              //Checks if the player is not parkouring at the moment from PlayerController.cs

       
        if (Input.GetMouseButtonDown(0) && canAttack && !isParkouring && AttackCouldown < 0 && attackStaminaEnough)
        {
           attackRate = GetComponentInChildren<WeaponStats>().attackRate;
           AttackCouldown = attackRate;

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
       attackAnim.SetTrigger("Attack");                                                       //Pick random attack animation and play it

       Stamina.instance.UseStamina(GetComponentInChildren<WeaponStats>().staminaDrain);       //Use staminaDrain set by WeaponStats.cs
       
       MyShaker.Shake(MyStrikePreset);                                                        //Camera shake

       
       weaponDamage = GetComponentInChildren<WeaponStats>().damage;

       GetComponentInChildren<WeaponStats>().WeaponUse();                                    //Damages weapon, weapon damage set by WeaponStats.cs

       StartCoroutine(WeaponCollider());
    }

    private void AnimatorOff()          //Disables animator when player is not attacking, to make weapon sway work
    {
        animatorOffTimer = 2f;

       if(animatorOffTimer > 0)
        {
            attackAnim.enabled = true;
        }

    }

    private IEnumerator WeaponCollider()  //Coroutine prevents enemy from taking damage when player is not atacking
    {
        weaponColl = true;
        yield return new WaitForSeconds(0.8f);
        weaponColl = false;
    }

}
