using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//All scripts wrote and developed in conjuction with youtube.com @Brackeys, @JasonWeiman and @CodeMonkey

public class Paralax : MonoBehaviour
{
    public Camera cam;

    public Transform subject;

    Vector2 startPosition;

    float startZ;

    Vector2 travel => (Vector2)cam.transform.position - startPosition;

    float disstanceFromSubject => transform.position.z - subject.position.z;

    float clippingPlane => (cam.transform.position.z + (disstanceFromSubject > 0 ? cam.farClipPlane: cam.nearClipPlane));

    float parallaxFactor => Mathf.Abs(disstanceFromSubject) / clippingPlane;

    public void Start()
    {
        startPosition = transform.position;
        startZ = transform.position.z;
    }

    public void Update()
    {
        Vector2 newPos = startPosition + travel * parallaxFactor;
        transform.position = new Vector3(newPos.x, newPos.y, startZ);
    }

}
