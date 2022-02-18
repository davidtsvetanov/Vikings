using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeHealth : MonoBehaviour
{
    public int health = 2;
    public bool isTreeDead;
    bool doOnce;
    private void Update()
    {
        if (doOnce == false && health < 1)
        {

            StartCoroutine(DestroyTree(10));



        }
    }
        // every 2 seconds perform the print()
        private IEnumerator DestroyTree(float waitTime)
        {
        doOnce = true;
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
        }
    }
