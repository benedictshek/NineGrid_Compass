using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlaneHit : MonoBehaviour
{
    private Collider _Collider;
    private Vector3 _houseSize;

    void Start()
    {
        _Collider = GetComponent<Collider>();
        //get the size of the collider volume
        _houseSize = _Collider.bounds.size;
        Debug.Log(_houseSize);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                Vector3 colliderPosition = hit.point;
                Debug.Log(colliderPosition);

                //determine whether hit left, middle or right (x-axis)
                if(colliderPosition.x < -(_houseSize.x / 2 / 3))
                {
                    Debug.Log("Hit left");

                    //determine whether hit left bottom, middle or top (z-axis)
                    if(colliderPosition.z < -(_houseSize.z / 2 / 3))
                    {
                        Debug.Log("bottom");
                    }
                    else if (colliderPosition.z < _houseSize.z / 2 / 3)
                    {
                        Debug.Log("middle");
                    }
                    else
                    {
                        Debug.Log("top");
                    }
                }
                else if (colliderPosition.x < _houseSize.x / 2 / 3)
                {
                    Debug.Log("Hit middle");

                    //determine whether hit middle bottom, middle or top (z-axis)
                    if (colliderPosition.z < -(_houseSize.z / 2 / 3))
                    {
                        Debug.Log("bottom");
                    }
                    else if (colliderPosition.z < _houseSize.z / 2 / 3)
                    {
                        Debug.Log("middle");
                    }
                    else
                    {
                        Debug.Log("top");
                    }
                }
                else
                {
                    Debug.Log("Hit right");

                    //determine whether hit right bottom, middle or top (z-axis)
                    if (colliderPosition.z < -(_houseSize.z / 2 / 3))
                    {
                        Debug.Log("bottom");
                    }
                    else if (colliderPosition.z < _houseSize.z / 2 / 3)
                    {
                        Debug.Log("middle");
                    }
                    else
                    {
                        Debug.Log("top");
                    }
                }
            }
        }
    }
}
