using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ScaleRay : MonoBehaviour
{
    Transform lastHit;
    Rigidbody lastHitRb;

    const float SCALING_RATE = 1.5f;
    const float SCALING_RATE_LOW = 0.25f;
    const float SCALING_RATE_HIGH = 5f;

    Vector3 scaleChange;
    bool isLowChange = false;
    bool isHighChange = false;

    public float maxScale = 40f;
    public float minScale = 0.05f;

    public event Action OnLeftMouseClick;
    public event Action OnRightMouseClick;
    bool hasLeftClicked;
    bool hasRightClicked;

    void TryLowChange()
    {
        if (Input.GetKeyDown("q")) 
        { 
            isLowChange = true; 
            Debug.Log("Low change active."); 
        }
        else if (Input.GetKeyUp("q"))
        {
            isLowChange = false;
            Debug.Log("Low change inactive.");
        }
    }

    void TryHighChange()
    {
        if (Input.GetKeyDown("e"))
        {
            isHighChange = true;
            Debug.Log("High change active.");
        }
        else if (Input.GetKeyUp("q"))
        {
            isHighChange = false; 
            Debug.Log("High change inactive.");
        }
    }

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
                    if (lastHit.localScale.y <= maxScale && !isLowChange && !isHighChange) 
                    {
                        scaleChange = lastHit.localScale * SCALING_RATE * Time.deltaTime;
                        Debug.Log("Scaling up normally.");
                        ScaleChange(0);
                    }
                    else if (lastHit.localScale.y <= maxScale && isLowChange) 
                    {
                        scaleChange = lastHit.localScale * SCALING_RATE_LOW * Time.deltaTime;
                        Debug.Log("Scaling up with low change.");
                        ScaleChange(0);
                    }
                    else if (lastHit.localScale.y <= maxScale && isHighChange) 
                    {
                        scaleChange = lastHit.localScale * SCALING_RATE_HIGH * Time.deltaTime;
                        Debug.Log("Scaling up with high change.");
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
                    if (lastHit.localScale.y >= minScale && !isLowChange && !isHighChange) 
                    {
                        scaleChange = lastHit.localScale * SCALING_RATE * Time.deltaTime;
                        Debug.Log("Scaling down normally.");
                        ScaleChange(1);
                    }
                    else if (lastHit.localScale.y >= minScale && isLowChange)  
                    {
                        scaleChange = lastHit.localScale * SCALING_RATE_LOW * Time.deltaTime;
                        Debug.Log("Scaling down with low change.");
                        ScaleChange(1);
                    }
                    else if (lastHit.localScale.y >= minScale && isHighChange) 
                    {
                        scaleChange = lastHit.localScale * SCALING_RATE_HIGH * Time.deltaTime;
                        Debug.Log("Scaling down with high hange.");
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
                lastHit.localScale -= scaleChange;
                lastHitRb.mass -= scaleChange.y;
                if (!hasRightClicked) OnRightMouseClick?.Invoke();
                hasRightClicked = true;
                break;
            case 0:
                lastHit.localScale += scaleChange;
                lastHitRb.mass += scaleChange.y;
                if (!hasLeftClicked) OnLeftMouseClick?.Invoke();
                hasLeftClicked = true;
                break;
            default:
                break;
        }
    }

    void Update()
    {
        TryLowChange();
        TryHighChange();
        if (isLowChange && isHighChange) { isLowChange= false; isHighChange = false; }
        TryShoot();
    }
}
