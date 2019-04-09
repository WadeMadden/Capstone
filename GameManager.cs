using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class GameManager : MonoBehaviour
{
    public int gemLevelComplete; 
    public static int gemTotal = 0;
    public TextMeshProUGUI gemText;
    public TextMeshProUGUI findGemNumber;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gemLevelComplete = GameObject.FindGameObjectsWithTag("enableGem").Length;
        findGemNumber.text = gemLevelComplete.ToString();
    }

    public int GetGems()
    {
        return gemTotal;
    }

    public void SetGems(int gems)
    {
        gemTotal = gems;
        gemText.text = gemTotal.ToString();
    }

    public void AddGem(int gemToAdd)
    {
        gemTotal += gemToAdd;
        gemText.text = gemTotal.ToString();
    }
}
