using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    Transform lastHit;
    public float scaleChangeRate = 10f;
    Vector3 scaleChange;

    private void Start() 
    {
        scaleChange = new Vector3(scaleChangeRate, scaleChangeRate, scaleChangeRate);
    }

    void TryShoot()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                lastHit = hit.collider.transform;
                ScaleChange(0);
            }
        }

        else if (Input.GetMouseButton(1))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                lastHit = hit.collider.transform;
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
