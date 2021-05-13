using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public Text scoreText;
    [HideInInspector] public int scoreCount; 
   
    private void LateUpdate()
    {
        scoreText.text = "Your scores:" + scoreCount.ToString(); 
    }
}
