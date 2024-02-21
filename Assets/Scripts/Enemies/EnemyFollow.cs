using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    Vector3 playerPos, newXPos, currentPosition;
    public Transform target;
    public float speed;
    

    void Start() {
        currentPosition = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        playerPos = target.transform.position;
        newXPos = new Vector3(playerPos.x, currentPosition.y, 0);
        
        transform.position = Vector3.MoveTowards(transform.position, newXPos, speed * Time.deltaTime);
    }
}