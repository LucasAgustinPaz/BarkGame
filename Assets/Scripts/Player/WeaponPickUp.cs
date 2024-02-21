using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    public SpriteRenderer srPlayer;
    public SpriteRenderer srWeapon;
    public Sprite PlayerWithMG;
    public Sprite PlayerWithPistol;
    public Sprite PlayerWithKnife;
    public Sprite PlayerWithFork;
    public Sprite PlayerWithPencil;
    public GameObject weapon;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("MachineGun"))
        {
            srPlayer.sprite = PlayerWithMG;
        }

        /*if (other.CompareTag("Pistol"))
        {
            srPlayer.sprite = PlayerWithPistol;
        }

        if (other.CompareTag("Knife"))
        {
            srPlayer.sprite = PlayerWithKnife;
        }

        if (other.CompareTag("Fork"))
        {
            srPlayer.sprite = PlayerWithFork;
        }

        if (other.CompareTag("Pencil"))
        {
            srPlayer.sprite = PlayerWithPencil;
        }*/

        srWeapon.enabled = false;
    }
}
