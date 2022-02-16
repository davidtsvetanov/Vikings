using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public GameObject itemFolder;
    GameObject currentlySelected;
    GameObject sword;
    GameObject axe;
    GameObject spear;
    public GameObject spearPickUp;
    public GameObject swordPickUp;
    public GameObject axePickUp;
    public ThirdPersonMovement thirdPersonMovement;
    // Start is called before the first frame update
    void Start()
    {
        sword = itemFolder.transform.GetChild(0).gameObject;
        axe = itemFolder.transform.GetChild(1).gameObject;
        spear = itemFolder.transform.GetChild(2).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
     
        if (other.tag == "SwordPickUp" || other.tag == "AxePickUp" || other.tag == "SpearPickUp")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                try
                {
                    Instantiate(currentlySelected);
                }
                catch { }
                switch (other.tag)
                {
                    case "SwordPickUp":
                        currentlySelected = swordPickUp;
                        sword.SetActive(true);
                        spear.SetActive(false);
                        axe.SetActive(false);
                        thirdPersonMovement.Weapon = sword;
                        break;
                        
                    case "AxePickUp":
                        currentlySelected = axePickUp;
                        axe.SetActive(true);
                        spear.SetActive(false);
                        sword.SetActive(false);
                        thirdPersonMovement.Weapon = axe;
                        break;

                    case "SpearPickUp":
                        currentlySelected = spearPickUp;
                        spear.SetActive(true);
                        sword.SetActive(false);
                        axe.SetActive(false);
                        thirdPersonMovement.Weapon = spear;
                        break;
                }
                Destroy(other.gameObject);
               
            }
        }
    }
}
