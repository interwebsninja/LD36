﻿using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class Senses : MonoBehaviour
{
    public float senseRange;
    public Transform head;
    public LayerMask sightMask;
    public float visiblityThreshold;
    public float audioThreshold;

    public UnityEvent OnDetected;

    void Update()
    {
        CheckEars();
    }

    public void EvaluateSight()
    {
        Vector3 dir = Player.instance.transform.position - transform.position;
        Ray sightRay = new Ray(head.position, dir);
        RaycastHit hit;
        if (Physics.Raycast(sightRay, out hit, senseRange, sightMask))
        {
            Player player = hit.collider.GetComponent<Player>();
            if (player && player.currentLight >= visiblityThreshold)
            {
                OnDetected.Invoke();
            }
        }
    }

    void CheckEars()
    {
        Vector3 dir = Player.instance.transform.position - transform.position;
        Ray audioRay = new Ray(head.position, dir);
        RaycastHit hit;
        if (Physics.Raycast(audioRay, out hit, senseRange, sightMask))
        {
            Player player = hit.collider.GetComponent<Player>();
            if (player && player.soundEmission >= audioThreshold)
            {
                OnDetected.Invoke();
            }
        }
    }
}
