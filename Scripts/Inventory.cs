using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private GameManagerX gameManagerX;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // player picks up or put down bucket
    public void GetBucket()
    {
        if (gameManagerX.hasRake)
        {
            Debug.Log("Put down the rake first.");
        }

        else if (gameManagerX.hasBucket)
        {
            Debug.Log("drops bucket");
            gameManagerX.hasBucket = false;
            gameManagerX.bucketText.text = "Bucket ( )";
        }
        else
        {
            Debug.Log("Picks up bucket");
            gameManagerX.hasBucket = true;
            gameManagerX.bucketText.text = "Bucket (*)";
            PlayerHPChange(-5);
        }
    }
    public void GetRake()
    {
        if (gameManagerX.hasBucket)
        {
            Debug.Log("Put down the bucket first.");
        }

        else if (gameManagerX.hasRake)
        {
            Debug.Log("drops rake");
            gameManagerX.hasRake = false;
            gameManagerX.rakeText.text = "Rake ( )";
        }
        else
        {
            Debug.Log("Picks up rake");
            gameManagerX.hasRake = true;
            gameManagerX.rakeText.text = "Rake (*)";
            PlayerHPChange(-5);
        }
    }
    public void GetWater()
    {
        gameManagerX.bucketHasWater = true;
        gameManagerX.waterText.text = "Water (*)";
        PlayerHPChange(-5);
    }
    public void WaterPlant()
    {
        PlantHPChange(5);
        PlayerHPChange(-5);
        gameManagerX.bucketHasWater = false;
        gameManagerX.waterText.text = "Water ( )";
    }
    public void FeedChicken()
    {
        ChickenHPChange(5);
        PlayerHPChange(-5);
    }
    public void UseFertilizer()
    {
        if (gameManagerX.fertilizerLeft > 0)
        {
            PlantHPChange(10);
            PlayerHPChange(-5);
            gameManagerX.fertilizerLeft -= 1;
        }
        else
        {
            Debug.Log("No fertilizers left.");
        }
    }
    public void LoosenSoil()
    {
        PlantHPChange(2);
        PlayerHPChange(-5);
    }
    public void Rest()
    {
        Debug.Log("taking a rest");
        PlayerHPChange(10);
    }
    public void PlayerHPChange(float point)
    {
        if (gameManagerX.playerHP + point >= 100)
        {
            gameManagerX.playerHP = 100;
        }
        else if (gameManagerX.playerHP + point < 0)
        {
            gameManagerX.playerHP = 0;
            gameManagerX.GameOver();
        }
        else
        {
            gameManagerX.playerHP += point;
        }
        gameManagerX.playerHPText.text = "Player HP: " + gameManagerX.playerHP;
    }
    public void PlantHPChange(float point)
    {
        if (gameManagerX.plantHP + point >= 200)
        {
            gameManagerX.plantHP = 100;
            gameManagerX.GameOver();
        }
        else
        {
            gameManagerX.plantHP += point;
        }
        gameManagerX.plantHPText.text = "Plant HP: " + gameManagerX.plantHP;
    }
    public void ChickenHPChange(float point)
    {
        if (gameManagerX.chickenHP + point >= 100)
        {
            gameManagerX.chickenHP = 100;
        }
        else
        {
            gameManagerX.chickenHP += point;
        }
        gameManagerX.chickenHPText.text = "Chicken HP: " + gameManagerX.chickenHP;
    }
}
