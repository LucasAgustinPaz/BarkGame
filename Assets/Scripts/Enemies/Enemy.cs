using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float MaxLife;
    float Health;

    [SerializeField] HealthBar healthBar;
    
    private void Awake() {
        healthBar = GetComponentInChildren<HealthBar>();
    }

    void Start()
    {
        Health = MaxLife;
        healthBar.updateHealthBar(Health, MaxLife);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Bullet")){
            takeDamage(20);
        }
    }
    
    void takeDamage(float damageAmount){
        Health -= damageAmount;
        healthBar.updateHealthBar(Health, MaxLife);
        if(Health <= 0){
            Die();
        }
    }

    void Die(){
        Destroy(gameObject);
    }
}
