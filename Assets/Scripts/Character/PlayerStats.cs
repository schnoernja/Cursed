using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

// Script for the player basics, like baseAttack, health, etc etc
// Handles also the damage the player takes from the enemy


public class PlayerStats : MonoBehaviour
{
    public float playerHealth;
    public int currentXp;
    public int maxXp;
    public int currentLevel;
    public int baseAttack;
    public string levelText;
    public TMP_Text levelNumber;

    public Image Lifebar;
    public Image Levelbar;

    public float maxLife;

    public bool reachedLevelTwo;

    private GameManager gameManager;
    private XPManager xpManager;
    private SceneManager sceneManager;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        if (xpManager == null)
        {
            xpManager = XPManager.instance;
        }

        playerHealth = gameManager.playerLife;
        baseAttack = gameManager.basePlayerAttack;
        maxLife = gameManager.maxLife;
        currentXp = gameManager.currentXp;
        maxXp = gameManager.maxXp;
        currentLevel = gameManager.currentLevel;
        reachedLevelTwo = gameManager.canDestroyCage;
        UpdateLifeBar();

        levelNumber.text = currentLevel.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        gameManager.playerLife = playerHealth;
        gameManager.currentLevel = currentLevel;
        gameManager.currentXp = currentXp;
        gameManager.canDestroyCage = reachedLevelTwo;
        gameManager.basePlayerAttack = baseAttack;
        gameManager.maxLife = maxLife;
    }

    void UpdateLifeBar()
    {
        float fillValue = playerHealth / maxLife;
        Lifebar.fillAmount = fillValue;
    }

    void UpdateLevelBar()
    {
        float fillValue = (float)currentXp / maxXp;
        Levelbar.fillAmount = fillValue;
    }

    public void takeDamage(int amountOfDamage)
    {
        if (gameObject != null) {
            playerHealth = playerHealth - amountOfDamage;
            playerHealth = Mathf.Clamp(playerHealth, 0f, maxLife);
            UpdateLifeBar();
            //Debug.Log(playerHealth);
            StartCoroutine(damageCooldown()); // doesn't work, idk why. needs to be fixed

            if (playerHealth <= 0)
            {
                playerHealth = maxLife;
                SceneManager.LoadSceneAsync(3);
                GetComponent<CharacterController>().currentState = PlayerState.dead;
            }

        }
    }


    private IEnumerator damageCooldown()
    {
        yield return new WaitForSeconds(3f);
    }

    private void HandleExperienceChange(int newXP)
    {
        currentXp += newXP;
        UpdateLevelBar();
        if (currentXp >= maxXp)
        {
            LevelUp();
        }
    }


    private IEnumerator StartCo()
    {
        while (XPManager.instance == null)
        {
            yield return null; // Warte einen Frame
        }
        xpManager = XPManager.instance;
        xpManager.OnExperienceChange += HandleExperienceChange;
    }

        private void OnEnable()
         {
        StartCoroutine(StartCo());

             /*if (XPManager.instance != null)
             {
                 xpManager = XPManager.instance;
                 xpManager.OnExperienceChange += HandleExperienceChange;
             }
             else
             {
                 Debug.LogError("XPManager instance not found.");
             }*/
         }

        private void OnDisable()
    {
        if (xpManager != null)
        {
            xpManager.OnExperienceChange -= HandleExperienceChange;
        }
        else { Debug.LogError("xp manager nich drin"); }
    }

    private void LevelUp()
    {
        baseAttack += 1;
        maxLife += 2;
        playerHealth = maxLife;

        currentLevel++;
        currentXp = 0;

        levelNumber.text = currentLevel.ToString();

        if (currentLevel == 2)
        {
            reachedLevelTwo = true;
        }
    }
}
