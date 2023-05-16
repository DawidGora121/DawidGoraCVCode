using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class PlayerHealthControll : MonoBehaviour
{
    private float canTakeDamageTimer = 1f; //Timer counts down when the player can take damage prevents player from taking multiple damage from one zombie strike
    public float health = 100;
    public TextMeshProUGUI healthText;

    public PostProcessVolume volume;
   
    void Start()
    {
        
    }
   
    void Update()
    {

        healthText.text = health.ToString();
        canTakeDamageTimer -= Time.deltaTime;
    }

    void OnTriggerEnter(Collider target)
    {
        //When the timer is 0 and player collides with hand of primary enemy player can be damaged by zombie
        if (target.tag == "Hands" && canTakeDamageTimer < 1)
        {           
           //Reset of the timer
            canTakeDamageTimer = 1f;
            Debug.Log("damaeged");
            DamagePlayer();
        }
    }

    void DamagePlayer()
    {
        float damage = Random.Range(3, 9);
        health -= damage;
    }



}
