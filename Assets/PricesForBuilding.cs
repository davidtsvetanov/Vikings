using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PricesForBuilding : MonoBehaviour
{
    public GameObject futureBuildingPrefab;
    public int wood;
    public int money;
    public int third;
    int isBuildingPlaced;
    public int id;

    private void Awake()
    {
        isBuildingPlaced =  PlayerPrefs.GetInt("BuildingPlaced" + id,0);
    }
    private void Start()
    {
        if (isBuildingPlaced==1)
        {
            Instantiate(futureBuildingPrefab, transform.position + new Vector3(0, 2, 0), Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
