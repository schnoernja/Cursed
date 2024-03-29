using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for the destroyable objects
// objects will be set active again automatically when a scene-change occurs, so a specific function to reach the same goal was discarded

public class DestroyableObjects : MonoBehaviour
{

    void Start()
    {
        this.gameObject.SetActive(true);
    }

    public void destroyObject()
    {
        this.gameObject.SetActive(false);
    }
}
