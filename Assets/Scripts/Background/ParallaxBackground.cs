using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{

    private GameObject cam;
    [SerializeField] private float parallaxEffect;
    private float xPosition;
    private float length;

    void Start()
    {
        cam = GameObject.Find("Main Camera");
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        xPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceMove = cam.transform.position.x * parallaxEffect;
        float distanceMoved = cam.transform.position.x * (1- parallaxEffect);

        transform.position = new Vector3(xPosition + distanceMove, transform.position.y);

        if (distanceMoved > xPosition + length)
            xPosition += length;
        else if(distanceMoved <xPosition -length)
            xPosition -= length;
    }
}
