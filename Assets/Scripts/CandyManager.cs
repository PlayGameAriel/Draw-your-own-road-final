using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CandyManager : MonoBehaviour
{ 
    public static CandyManager instance;
    public Text text;
    int score;

    void Start()
    {
       if(instance == null)
        {
            instance = this;
        }
    }

    public void ChangeScore(int candyValue)
    {
        score += candyValue;
        text.text = score.ToString();
    }
   
   
}
