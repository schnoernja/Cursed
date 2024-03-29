using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class GaaruzalBossFight : MonoBehaviour
{
    private GameManager gameManager;

    public GameObject Boss;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;

        if (gameManager.gaaruzalIsDead != true)
        {
            Boss.SetActive(true);
        }
        else
        {
            Boss.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (!Boss.activeInHierarchy)
        {
            gameManager.gaaruzalIsDead = true;
        }
    }
}
