using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MilkShake;
using BreadcrumbAi;

public class zombieV2TakeDamage : MonoBehaviour
{
    private Rigidbody rb;

    public ParticleSystem bloodCutParticle;

    public GameObject bloodPool;
    public GameObject bloodCutParticle1;    
   
    public static bool enemyCanTakeDamage;     //Prevents from calling TakeDamage function multiple times when colliding
    public static bool enemyIsDead;          

    public float knockbackForce = 700f;

    public float enemyCantakeDamageTimer = 1f;  //Sets enemyCanTakeDamage bool

    public float enemyHealth;
    public float maxHealth = 105f;
    public float minHealth = 45f;

    public Shaker MyShaker;                    //Camera shake asset
    public ShakePreset EnemyHitShakePreset;    //Camera shake asset

    private Collider enemyColl; 

    void Start()
    {
        enemyCanTakeDamage = true;
        enemyIsDead = false;

        enemyHealth = Random.Range(minHealth, maxHealth);

        enemyColl = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();        
    }
   
    void Update()
    {
        if (enemyCantakeDamageTimer > 0)                
            enemyCantakeDamageTimer -= Time.deltaTime;

        if (enemyHealth <= 0)
            EnemyDead();
       
    }

   public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "WeaponCut"  && enemyCantakeDamageTimer < 0)
        {
            TakeDamage();

            enemyCantakeDamageTimer = 1f;
            MyShaker.Shake(EnemyHitShakePreset);
        }

        if(other.tag == "Kick" && enemyCantakeDamageTimer < 0)
        {
            enemyHealth -= 10f;
            enemyCantakeDamageTimer = 1f;
        }

    }

    void TakeDamage()
    {
        enemyHealth -= PlayerAttack.weaponDamage;
        bloodCutParticle.Play();
    }

    public void EnemyDead()
    {
        GetComponentInChildren<ZombieV2RagdollControll>().EnableRagdoll();
        
        DisableEnemyScripts();                                                     
    }

    public void DisableEnemyScripts()
    {
        GetComponent<zombieV2AttackControll>().DisableAllColliders();   

        enemyColl.enabled = false;                                   //Disables sphere collider to prevent from interacting with ragdoll colliders
        GetComponentInChildren<CustomTag>().enabled = true;          //Enables script to ensable parkour on dead bodies
        GetComponent<Ai>().enabled = false;                          //Disables script responsible for movement of enemy 

        enemyIsDead = true;

        bloodPool.SetActive(true);

        Destroy(bloodPool, 15f);
        Destroy(this.gameObject, 15f);
    }
   /*
    public  void Knockback()
    {
        rb.AddForce(transform.forward * knockbackForce);
    }
   */
}
