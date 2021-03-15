/* 
 * * Logan Ross
 * * GameManager.cs
 * * Assignment 3
 * * Runs the player updates, and notifies observers
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour, Subject
{
    public List<GameObject> observerList = new List<GameObject>();
    public GameObject player;

    private void Start()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in enemies)
        {
            register(enemy);
        }

        player = GameObject.FindGameObjectWithTag("Player");
        notifyObserver();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
    public void rotateRight()
    {
        player.transform.Rotate(player.transform.position, 90);
        notifyObserver();
    }

    public void rotateLeft()
    {
        player.transform.Rotate(player.transform.position, -90);
        notifyObserver();
    }

    public void notifyObserver()
    {
        foreach (GameObject item in observerList)
        {
            if (item != null)
            {
                EnemyHandler eh = item.GetComponent<EnemyHandler>();
                eh.update();
            }
        }
    }

    public void register(GameObject newObserver)
    {
        observerList.Add(newObserver);
    }
    public void unregister(GameObject newObserver)
    {
        observerList.Remove(newObserver);
    }
}
