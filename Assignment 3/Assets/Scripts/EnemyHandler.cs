/* 
 * * Logan Ross
 * * EnemyHandler.cs
 * * Assignment 3
 * * moves and stops the enemy movment, also handles enemy removal
 */

using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemyHandler : MonoBehaviour, Observer
{
    public GameObject player;
    public GameManager gm;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gm.register(gameObject);
    }
    public void update()
    {
        if (Mathf.Abs(player.transform.rotation.eulerAngles.y - gameObject.transform.rotation.eulerAngles.y) == 180f)
        {
            canMove = false;
        }
        else
            canMove = true;
    }

    public bool canMove = true;
    public int moveSpeed = 3;

    public void setCanMove(bool newCanMove)
    {
        canMove = newCanMove;
    }
    void Update()
    {
        if (canMove)
        {
            this.transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hitbox")
        {
            gm.unregister(this.gameObject);
            Destroy(this.gameObject);
        }
    }

}
