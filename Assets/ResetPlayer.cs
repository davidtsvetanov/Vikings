using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public void ResetThePlayer()
    {
        PlayerPrefs.DeleteAll();
    }

 
}
