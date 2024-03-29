using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

//this script is for scene transitions and whatever belongs in this category or is related to a scene change
public class SceneTransitions : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerPosition;
    public VectorValue playerSpawnPosition;
    public GameObject FadingPanelWhite; // for a fading transition between scene changes. (it isn't white anymore)
    public string currentLocation;      // current location of the player in the world
    public GameObject text;
    public TMP_Text TMPlocationText;
    private SceneManager sceneManager;

    PlayerStats playerStats;

    //GameObject worldBoundaryForCamera;
    
    private void Awake()
    {
        if(FadingPanelWhite != null)
        {
            GameObject panel = Instantiate(FadingPanelWhite, Vector3.zero, Quaternion.identity) as GameObject;
            Destroy(panel, 1);
            StartCoroutine(locationNameCo());
        }
    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            playerSpawnPosition.initialValue = playerPosition;
            SceneManager.LoadSceneAsync(sceneToLoad);
        }
    }

    // Co-Routine to deactivate the Name of the location after a certain amount of time
    private IEnumerator locationNameCo()
    {
        text.SetActive(true);
        TMPlocationText.text = currentLocation;
        yield return new WaitForSeconds(4f);
        text.SetActive(false); ;
    }
}
