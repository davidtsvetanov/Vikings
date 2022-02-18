using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBuilding : MonoBehaviour
{

    public GameObject spawnPlatform;
    bool onTarget;
    public ResourceManager resources;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (onTarget)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PricesForBuilding prices = spawnPlatform.GetComponent<PricesForBuilding>();
                if (resources.wood >= prices.wood && resources.money >= prices.money && resources.third >= prices.third)
                {
                    resources.wood -= prices.wood;
                    resources.money -= prices.money;
                    resources.third -= prices.third;
                    PlayerPrefs.SetInt("BuildingPlaced"+ prices.id, 1);
                    Instantiate(prices.futureBuildingPrefab, spawnPlatform.transform.position + new Vector3(0, 2, 0), Quaternion.identity);
                    Destroy(spawnPlatform.gameObject);
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Building1")
        {
            spawnPlatform = other.gameObject;
            onTarget = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Building1")
        {
            spawnPlatform = null;
            onTarget = false;

        }
    }
}

