using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycasting : MonoBehaviour
{
    public float distanceToSee;
    RaycastHit whatIHit;
    private GameManagerX gameManagerX;
    private Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
        inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManagerX.isGameActive)
        {
            Debug.DrawRay(this.transform.position, this.transform.forward * distanceToSee, Color.magenta);

            if (Physics.Raycast(this.transform.position, this.transform.forward, out whatIHit, distanceToSee))
            {
                if (whatIHit.collider.tag == "InteractingObjects")
                {
                    Debug.Log("Hitting " + whatIHit.collider.gameObject);
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        if (whatIHit.collider.gameObject.GetComponent<Interactions>().interactingObject == Interactions.interactableObjects.bucket)
                        {
                            inventory.GetBucket();
                        }

                        else if (whatIHit.collider.gameObject.GetComponent<Interactions>().interactingObject == Interactions.interactableObjects.well)
                        {
                            if (gameManagerX.hasBucket)
                            {
                                inventory.GetWater();
                                Debug.Log("Got water!");
                            }
                            else
                            {
                                Debug.Log("Get bucket first!");
                            }
                        }

                        else if (whatIHit.collider.gameObject.GetComponent<Interactions>().interactingObject == Interactions.interactableObjects.table)
                        {
                            inventory.Rest();
                        }

                        else if (whatIHit.collider.gameObject.GetComponent<Interactions>().interactingObject == Interactions.interactableObjects.sack)
                        {
                            inventory.UseFertilizer();
                        }

                        else if (whatIHit.collider.gameObject.GetComponent<Interactions>().interactingObject == Interactions.interactableObjects.chicken)
                        {
                            inventory.FeedChicken();
                        }

                        else if (whatIHit.collider.gameObject.GetComponent<Interactions>().interactingObject == Interactions.interactableObjects.rake)
                        {
                            inventory.GetRake();
                        }

                        else if (whatIHit.collider.gameObject.GetComponent<Interactions>().interactingObject == Interactions.interactableObjects.farm)
                        {
                            Debug.Log("farm here");
                            //water the plant
                            if (gameManagerX.hasBucket && gameManagerX.bucketHasWater)
                            {
                                inventory.WaterPlant();
                            }

                            else if (gameManagerX.hasRake)
                            {
                                inventory.LoosenSoil();
                            }
                        }
                    }

                }
            }
            else if (gameManagerX.hasBucket && Input.GetKeyDown(KeyCode.E))
            {
                inventory.GetBucket();
            }
            else if (gameManagerX.hasRake && Input.GetKeyDown(KeyCode.E))
            {
                inventory.GetRake();
            }
        }
    }
}
