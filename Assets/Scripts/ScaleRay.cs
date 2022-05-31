using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScaleRay : MonoBehaviour
{
    Transform lastHit;
    Rigidbody lastHitRb;
    const float SCALING_RATE = 1.5f;
    Vector3 scaleChange;
    public float maxScale = 40f;
    public float minScale = 0.05f;

    public event Action OnLeftMouseClick;
    public event Action OnRightMouseClick;
    bool hasLeftClicked;
    bool hasRightClicked;


    void TryShoot()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (!(hit.collider.gameObject.tag == "Ground"))
                {
                    lastHit = hit.collider.transform;
                    lastHitRb = hit.collider.gameObject.GetComponent<Rigidbody>();
                    if (lastHit.localScale.y <= maxScale) 
                    {
                        scaleChange = lastHit.localScale * SCALING_RATE;
                        ScaleChange(0);
                    }
                }
            }
        }

        else if (Input.GetMouseButton(1))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (!(hit.collider.gameObject.tag == "Ground"))
                {
                    lastHit = hit.collider.transform;
                    lastHitRb = hit.collider.gameObject.GetComponent<Rigidbody>();
                    if (lastHit.localScale.y >= minScale) 
                    {
                        scaleChange = lastHit.localScale * SCALING_RATE;
                        ScaleChange(1);
                    }
                }
            }
        }
    }

    void ScaleChange(int type)
    {
        switch (type)
        {
            case 1:
                lastHit.localScale -= scaleChange * Time.deltaTime;
                lastHitRb.mass -= scaleChange.y * Time.deltaTime;
                if (!hasRightClicked) OnRightMouseClick?.Invoke();
                hasRightClicked = true;
                break;
            case 0:
                lastHit.localScale += scaleChange * Time.deltaTime;
                lastHitRb.mass += scaleChange.y * Time.deltaTime;
                if (!hasLeftClicked) OnLeftMouseClick?.Invoke();
                hasLeftClicked = true;
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
