using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Bow bow;
    public ScoreCs scoreCs;
    private int totalPoints;
    private int totalArrows;

    private List<GameObject> objectsInGame = new List<GameObject>();

    public static GameManager instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        IntializeGame();
    }

    public void IntializeGame()
    {
        totalPoints = 0;
        totalArrows = 0;
        foreach (GameObject go in objectsInGame)
        {
            Destroy(go);
        }

        // Clear()es la forma canónica de borrar un archivo List<T>
        objectsInGame.Clear();

        // Initialize Score UGUI

        scoreCs.SetTotalArrows(totalArrows);
        scoreCs.SetTotalArrows(totalArrows);
        scoreCs.SetTotalPoints(totalPoints);
    }


    public bool IsGameActive()
    {
        return totalArrows < 10;
    }

    public void RegisterMarker(GameObject marker)
    {
        objectsInGame.Add(marker);
    }

    public void RegisterArrow(GameObject arrow)
    {
        objectsInGame.Add(arrow);
    }

    public void LaunchedArrow()
    {
        if (!IsGameActive()) { return; }

        totalArrows++;

        scoreCs.SetTotalArrows(totalArrows);

        Debug.Log("ArrowsLaunched " + totalArrows);
    }

    public void AddPoints(int points)
    {
        if (!IsGameActive()) { return; }

        totalPoints += points;

        scoreCs.SetLastArrowPoints(points);
        scoreCs.SetTotalPoints(totalPoints);

        Debug.Log("totalPoints " + totalPoints);
    }

    // UI Button recuperar arco
    public void RetrieveBow()
    {
        bow.ResetPosition();
    }
}
