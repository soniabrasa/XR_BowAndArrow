using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResetPosition()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}
