/* 
 * * Logan Ross
 * * Subject.cs
 * * Assignment 3
 * * Subject interface that is inherited by the game manager
 */

using UnityEngine;
using System.Collections;

public interface Subject
{
    public void register(GameObject o);
    public void unregister(GameObject o);
    public void notifyObserver();
}