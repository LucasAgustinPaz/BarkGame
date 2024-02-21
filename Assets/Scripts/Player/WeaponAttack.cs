using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    private float timeWhenAllowedNextShoot = 0f;
    public float timeBetweenShooting = 0f;
    public SpriteRenderer SrPlayer;
    public Sprite MachineGun;
    public Sprite idle;
    public GameObject player;

    private Camera mainCam;
    private Vector3 mousePos;

    public GameObject bullet;
    public Transform bulletTransform;
    public float bulletSpeed;


    //public GameObject ProjectilePrefab;
    void Start()
    {
        mainCam = Camera.main;
    }
    void Update()
    {
        //GameObject Bullet = Instantiate(ProjectilePrefab, transform.position, transform.rotation);

        weaponRange();

        //mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

    }

    void weaponRange() // check weapon range
    {
        if (SrPlayer.sprite == MachineGun)
        {
            checkIfShouldShootRanged();
        }

        if (SrPlayer.sprite == idle)
        {
            checkIfShouldShootMelee();
        }
    }


    void checkIfShouldShootMelee() // Melee Attack Delay
    {
        if (timeWhenAllowedNextShoot <= Time.time)
        {
            if (Input.GetMouseButton(0))
            {
                shootMelee();
                timeWhenAllowedNextShoot = Time.time + timeBetweenShooting;
            }
        }
    }

    void checkIfShouldShootRanged() // Ranged Attack Delay
    {
        if (timeWhenAllowedNextShoot <= Time.time)
        {
            if (Input.GetMouseButton(0))
            {
                shootRanged();
                timeWhenAllowedNextShoot = Time.time + timeBetweenShooting;
            }
        }
    }

    void shootMelee()
    {
        Debug.Log("Shoot Melee");
    }

    void shootRanged()
    {
        ShootBullet();
        Debug.Log("Shoot Ranged");
    }

     void ShootBullet()
    {
        // Calculate the direction towards the mouse pointer
        Vector3 mousePosition = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - bulletTransform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Instantiate the bullet
        GameObject bulletInst = Instantiate(bullet, bulletTransform.position, Quaternion.Euler(0f, 0f, angle));

        // Get the Rigidbody2D component of the bullet and apply velocity
        Rigidbody2D bulletRb = bulletInst.GetComponent<Rigidbody2D>();
        bulletRb.velocity = direction * bulletSpeed; // Set bulletSpeed according to your needs
    }

    //With X Sprite, Do this attack
    //One function for melee, and one for ranged
    //Evaluate weapon, realize that weapons attack attack
}

/*for bullet
public GameObject target;
Vector3 pos;
float speed= 10;
// Use this for initialization
void Start () {
pos = target.transform.position;
}

// Update is called once per frame
void Update () {
float step = speed * Time.deltaTime;
transform.position = Vector3.MoveTowards(transform.position, pos, step);
}​
*/