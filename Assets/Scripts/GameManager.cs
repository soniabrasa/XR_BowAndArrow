using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Bow bow;
    // public Marcador marcador;
    public static GameManager instance;
    private int playerScore;
    private int launchedArrowCount;

    private List<GameObject> objectsInGame = new List<GameObject>();

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        IntializeGame();
    }


    public bool IsGameActive()
    {
        return launchedArrowCount < 10;
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

        launchedArrowCount++;
        Debug.Log("ArrowsLaunched " + launchedArrowCount);
        // marcador.SetNumeroFrechas(launchedArrowCount);
    }

    public void AddPoints(int points)
    {
        if (!IsGameActive()) { return; }

        playerScore += points;
        Debug.Log("PlayerScore " + playerScore);
        // marcador.SetPuntuacionTotal(playerScore);
        // marcador.SetPuntuacionUltimaFrecha(points);
    }

    public void IntializeGame()
    {
        playerScore = 0;
        launchedArrowCount = 0;
        foreach (GameObject go in objectsInGame)
        {
            Destroy(go);
        }
        objectsInGame.Clear();

        // marcador.SetNumeroFrechas(0);
        // marcador.SetPuntuacionTotal(0);
        // marcador.SetPuntuacionUltimaFrecha(0);
    }


    public void RetrieveBow()
    {
        bow.ResetPosition();
    }
}
