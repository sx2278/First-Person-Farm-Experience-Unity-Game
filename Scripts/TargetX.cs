using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetX : MonoBehaviour
{
    private GameManagerX gameManagerX;
    private Rigidbody targetRb;
    public float timeOnScreen = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();

        transform.position = RandomSpawnPosition();
        //StartCoroutine(RemoveObjectRoutine()); // begin timer before target leaves screen
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    Vector3 RandomSpawnPosition()
    {
        float spawnPosX = -1 * Random.Range(1, 4);
        float spawnPosZ = -1 * Random.Range(9, 12);
        Vector3 spawnPosition = new Vector3(spawnPosX, 0.3f, spawnPosZ);
        return spawnPosition;
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        Debug.Log("Target Hit!");
        //gameManagerX.UpdateScore(100);
    }

    IEnumerator RemoveObjectRoutine()
    {
        yield return new WaitForSeconds(timeOnScreen);
        if (gameManagerX.isGameActive)
        {
            Debug.Log("Escaped!");
            Destroy(gameObject);
        }

    }
}
