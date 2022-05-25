using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleRay : MonoBehaviour
{
    Transform lastHit;
    public float scalingRate = 10f;
    Vector3 scaleChange;

    void TryShoot()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Object being scaled up."); 
                lastHit = hit.collider.transform;
                scaleChange = lastHit.localScale * scalingRate;
                ScaleChange(0);
            }
        }

        else if (Input.GetMouseButton(1))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Object being scaled down.");
                lastHit = hit.collider.transform;
                scaleChange = lastHit.localScale * scalingRate;
                ScaleChange(1);
            }
        }
    }

    void ScaleChange(int type)
    {
        switch (type)
        {
            case 1:
                lastHit.localScale -= scaleChange * Time.deltaTime;
                break;
            case 0:
                lastHit.localScale += scaleChange * Time.deltaTime;
                break;
            default:
                break;
        }
    }

    void Update()
    {
        TryShoot();
    }
}