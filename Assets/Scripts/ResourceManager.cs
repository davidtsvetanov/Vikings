using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceManager : MonoBehaviour
{
    public int wood;
    public TMP_Text woodText;

    public int money;
    public TMP_Text moneyText;

    public int third;
    public TMP_Text thirdText;


    bool valuesSet;
    // Start is called before the first frame update
    void Awake()
    {
        wood = PlayerPrefs.GetInt("Wood", 0);
        money = PlayerPrefs.GetInt("Money", 0);
        third = PlayerPrefs.GetInt("Third", 0);
        valuesSet = true;
    }

    private void OnApplicationFocus(bool focus)
    {
        if (valuesSet)
        {
            PlayerPrefs.SetInt("Wood", wood);
            PlayerPrefs.SetInt("Money", money);
            PlayerPrefs.SetInt("Third", third);
        }
    }
    // Update is called once per frame
    void Update()
    {
        woodText.text = wood.ToString();
        moneyText.text = money.ToString();
        thirdText.text = third.ToString();
    }
}
