using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUDManager : MonoBehaviour
{
    ScaleRay scaleRay;
    public GameObject textIncrease;
    public GameObject textDecrease;

    void Start()
    {
        scaleRay = FindObjectOfType<ScaleRay>();
        scaleRay.OnLeftMouseClick += KillTextIncrease;
        scaleRay.OnRightMouseClick += KillTextDecrease;
    }

    public void KillTextIncrease()
    {
        textIncrease.SetActive(false);
    }

    public void KillTextDecrease()
    {
        textDecrease.SetActive(false);
    }
}
