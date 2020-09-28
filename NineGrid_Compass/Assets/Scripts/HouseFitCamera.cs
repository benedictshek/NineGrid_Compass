using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseFitCamera : MonoBehaviour
{
    public float CameraDistance;

    private void Start()
    {
        Collider _houseCollider = GetComponent<Collider>();

        float _screenRatio = (float)Screen.width / (float)Screen.height;
        float _houseRatio = _houseCollider.bounds.size.x / _houseCollider.bounds.size.y;

        //if house inside the screen (too small)
        if(_screenRatio >= _houseRatio)
        {
            //move the camera closer
            Camera.main.orthographicSize = _houseCollider.bounds.size.y / 2 * CameraDistance;
        }
        //if house outside the screen (too large)
        else
        {
            float _differenceInSize = _houseRatio / _screenRatio;
            //move the camera further away
            Camera.main.orthographicSize = _houseCollider.bounds.size.y / 2 * _differenceInSize * CameraDistance;
        }
    }
}
