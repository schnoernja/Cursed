using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

//Inherites EnemyBasics.cs

// This class provides the code, which will make certain enemies:
// - run towards the PLAYER, if he's within a given range
// - move in general (patroling)
// - animate

public class EnemyMovement : EnemyBasics
{
    public GameObject Player;
    public float enemySpeed;
    public float triggerDistance;

    private float distance;       // Distance between enemy and player
    private Vector3 homePosition; // starting Position of the enemy, to which he returns when the player isn't within the triggerdistance anymore

    public float range;           // for wandering around
    public float maxDistance;
    Vector2 waypoint;

    // Start is called before the first frame update
    void Start()
    {
        homePosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, Player.transform.position); //distance between enemy and player
        Vector2 direction = Player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //Triggered,when the player is too close to the enemy

        if (distance < triggerDistance)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, enemySpeed * Time.deltaTime); //move towards player
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);

        }
        else if (distance > triggerDistance)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, homePosition, enemySpeed * Time.deltaTime);

        }
        else if (transform.position == homePosition)
        {
            // Herumwandern innerhalb einer vorgegebenen Range
        }
    }
}
