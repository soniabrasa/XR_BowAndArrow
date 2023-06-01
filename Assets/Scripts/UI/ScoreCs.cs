using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCs : MonoBehaviour
{
    public TextMeshProUGUI valueArrows;
    public TextMeshProUGUI valueLastArrowPoints;
    public TextMeshProUGUI valueTotalPoints;

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
}
