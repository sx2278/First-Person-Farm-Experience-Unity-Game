using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManagerX : MonoBehaviour
{
    public GameObject bucketObject;
    public GameObject rakeObject;
    public GameObject player;

    public TextMeshProUGUI playerHPText;
    public TextMeshProUGUI plantHPText;
    public TextMeshProUGUI chickenHPText;

    public TextMeshProUGUI bucketText;
    public TextMeshProUGUI rakeText;
    public TextMeshProUGUI waterText;

    public bool isGameActive = true;
    public Button restartButton;
    public float time = 1000;

    public bool hasBucket = false;
    public bool bucketHasWater = false;
    public bool hasRake = false;
    public float playerHP = 30;
    public float chickenHP = 10;
    public float plantHP = 20;
    public float fertilizerLeft = 3;
    public bool showBox = false;


    // Start is called before the first frame update
    void Start()
    {
        playerHPText.text = "Player HP: " + playerHP;
        plantHPText.text = "Plant HP: " + plantHP;
        chickenHPText.text = "Chicken HP: " + chickenHP;

        bucketText.text = "Bucket ( )";
        rakeText.text = "Rake ( )";
        waterText.text = "Water ( )";
        //StartCoroutine(CountDown());
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHP <= 0)
        {
            GameOver();
        }

        if (hasBucket)
        {
            bucketObject.transform.position = player.transform.position - new Vector3(1/2, 9/10) + player.transform.forward * 2;
        }

        if (hasRake)
        {
            rakeObject.transform.position = player.transform.position - new Vector3(1 / 2, 9 / 10) + player.transform.forward * 2;
        }

        if (showBox)
        {
            OnGUI();
        }

        if (isGameActive==false && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }
    void OnGUI()
    {
        if (isGameActive == false)
        {
            GUI.Box(new Rect(Screen.width / 8, Screen.height - 35, Screen.width - 300, 30), "Press R to restart");
        }
        else
        {
            GUI.Box(new Rect(Screen.width / 8, Screen.height - 35, Screen.width - 300, 30), "Press \"WASD\" for directions. Press E for interacting with objects");
        }
    }


    public void GameOver()
    {
        isGameActive = false;
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
