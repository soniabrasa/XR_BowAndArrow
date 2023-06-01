using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour, IArrowHittable
{
    public GameObject yellowHitMarkerPrefab;
    public GameObject redHitMarkerPrefab;

    private float radioExterior = 0.49f;
    private float radioDivisionCentral = 0.037f;
    private float anchoZona;

    void Start()
    {
        anchoZona = (radioExterior - radioDivisionCentral) / 9;
    }

    void Update()
    {
    }

    public void Hit(Arrow arrow, RaycastHit hit)
    {
        float impactDistance = Vector3.Distance(transform.position, hit.point);

        int points = 0;
        if (impactDistance < radioExterior)
        {
            if (impactDistance <= radioDivisionCentral)
            {
                points = 10;
            }
            else
            {
                points = 9 - (int)Mathf.Floor((impactDistance - radioDivisionCentral) / anchoZona);
            }
        }

        if (points >= 9)
        {
            //Marcamos o impacto en vermello
            GameManager.instance.RegisterMarker(Instantiate(redHitMarkerPrefab, hit.point, Quaternion.LookRotation(transform.right)));
        }
        else
        {
            GameManager.instance.RegisterMarker(Instantiate(yellowHitMarkerPrefab, hit.point, Quaternion.LookRotation(transform.right)));
        }

        Debug.Log($"Target {points} points");
        GameManager.instance.AddPoints(points);
    }
}
