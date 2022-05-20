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
            var ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                lastHit = hit.collider.transform;
                ScaleChange(1);
            }
        }

        else if (Input.GetMouseButton(1))
        {
            var ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                lastHit = hit.collider.transform;
                ScaleChange(2);
            }
        }
    }

    void ScaleChange(int type)
    {
        switch (type)
        {
            case 2:
                lastHit.localScale += scaleChange * Time.deltaTime;
                break;
            case 1:
                lastHit.localScale += scaleChange * Time.deltaTime;
                break;
            default:
                break;
        }
    }

    void Update()
    {
        

    }
}
