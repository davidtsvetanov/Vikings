using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceBuilding : MonoBehaviour
{
    public GameObject building1prefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerStay(Collider other)
    {

        if (other.tag == "Building1")
        {
           
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("kur");
                Instantiate(building1prefab, other.transform.position+ new Vector3(0,2,0), Quaternion.identity);
                Destroy(other.gameObject);
            }
        }
    }
}

