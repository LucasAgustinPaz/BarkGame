using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LifeCount : MonoBehaviour
{
    public Image[] lives;
    public int livesRemaining;
    int maxHealth;

    public TextMeshProUGUI deadText;

    public GameObject dmg;
    public GameObject heal;

    void Start()
    {
        deadText.gameObject.SetActive(false);
        maxHealth = livesRemaining;
    }

    private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Spike"))
    {
        GetDamage(); // Call GetDamage method if colliding object is tagged as "Spike"
    }
    
    if (other.CompareTag("Heal"))
    {
        GetHealed(); // Call GetHealed method if colliding object is tagged as "Heal"
    }
}

    public void GetDamage()
    {
        //0,1,2,3 - 4
        //0,1,2,[3] - 3
        //0,1,[2],3 - 2
        //0,[1],2,3 - 1
        //[0],1,2,3 - dead
        if(livesRemaining == 0){
            return;
        }
        if (livesRemaining > 1)
        {
            livesRemaining--;
            lives[livesRemaining].enabled = false;
        }
        else
        {
            livesRemaining--;
            lives[livesRemaining].enabled = false;
            deadText.gameObject.SetActive(true);
            Time.timeScale = 0; // Stop
        }
    }

    public void GetHealed()
    {
        if (livesRemaining < maxHealth)
        {
            livesRemaining++;
            lives[livesRemaining - 1].enabled = true;
            Debug.Log("Healed");
        }
    }
}
