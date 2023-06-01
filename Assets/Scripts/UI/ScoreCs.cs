using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCs : MonoBehaviour
{
    public TextMeshProUGUI valueArrows;
    public TextMeshProUGUI valueLastArrowPoints;
    public TextMeshProUGUI valueTotalPoints;

    public Image targetHitLight;

    public void SetTotalArrows(int num)
    {
        valueArrows.text = num.ToString();
    }

    public void SetLastArrowPoints(int num)
    {
        valueLastArrowPoints.text = num.ToString();
    }

    public void SetTotalPoints(int num)
    {
        valueTotalPoints.text = num.ToString();
    }

    public void ButtonInitializeOnClick()
    {
        GameManager.instance.IntializeGame();
    }

    public void ButtonRetrieveBowOnClick()
    {
        GameManager.instance.RetrieveBow();
    }

    public void SetTargetHitLight(int newColor)
    {
        switch (newColor)
        {
            case 0:
                targetHitLight.color = Color.red;
                break;

            case 1: 
                targetHitLight.color = Color.yellow;
                break;
            case 2:
                targetHitLight.color = Color.green;
                break;

            default:
                targetHitLight.color = Color.black;
                break;
        }

        // if(hit)
        // {
        //     targetHitLight.color = Color.green;
        // }
        // else
        // {
        //     targetHitLight.color = Color.red;
        // }

    }
}
