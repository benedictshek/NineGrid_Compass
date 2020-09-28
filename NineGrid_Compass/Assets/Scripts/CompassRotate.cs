using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassRotate : MonoBehaviour
{
    public Collider HouseCollider;
    public GameObject Door;

    [Header("House Size")]
    private float _houseHeight;
    private float _houseLength;
    private float _houseWidth;

    [Header("Compass Size")]
    public float CompassRatio;

    [Header("Mouse Position")]
    private Vector3 _mousePrevPos = Vector3.zero;
    private Vector3 _mousePosDelta = Vector3.zero;
    private Transform _mainCamTransform;

    [Header("Compass Rotate Speed")]
    public float RotateSpeed;

    [Header("Compass Rotate Angle")]
    private float _doorFacingAngle;
    private float _compassRotateAngle;

    private void Awake()
    {
        HouseCollider = HouseCollider.GetComponent<Collider>();
        //get the house height
        _houseHeight = HouseCollider.bounds.size.z;
        //get the house length
        _houseLength = HouseCollider.bounds.size.y;
        //get the house width
        _houseWidth = HouseCollider.bounds.size.x;

        //move the compass position on the middle of the house
        transform.position = HouseCollider.transform.position;
        //move the compass on top of the house
        transform.Translate(Vector3.forward * -_houseHeight, Space.World);

        //set the compass size relative to house size
        transform.localScale = HouseCollider.transform.localScale * Mathf.Min(_houseLength, _houseWidth) / CompassRatio;

    }

    private void Start()
    {
        _mainCamTransform = Camera.main.transform;

        _doorFacingAngle = Door.transform.eulerAngles.z;
    }

    private void Update()
    {
        //if mouse is pressed
        if (Input.GetMouseButtonDown(0))
        {
            //store the first pressed position as the previous position
            _mousePrevPos = Input.mousePosition;
        } 
        //if mouse is held down
        else if (Input.GetMouseButton(0))
        {
            //update the changing position
            _mousePosDelta = Input.mousePosition - _mousePrevPos;

            //get the origin position of the compass
            Vector3 proj = Camera.main.WorldToScreenPoint(transform.position);

            //if mouse position is on the bottom half of the compass
            if (proj.y > Input.mousePosition.y)
            {
                transform.Rotate(transform.forward, Vector3.Dot(_mousePosDelta, _mainCamTransform.right) * RotateSpeed, Space.World);
            }
            //if mouse position is on the top half of the compass
            else
            {
                transform.Rotate(transform.forward, -Vector3.Dot(_mousePosDelta, _mainCamTransform.right) * RotateSpeed, Space.World);
            }

            //if mouse position is on the left half of the compass
            if (proj.x > Input.mousePosition.x)
            {
                transform.Rotate(_mainCamTransform.forward, -Vector3.Dot(_mousePosDelta, _mainCamTransform.up) * RotateSpeed, Space.World);
            }
            //if mouse position is on the right half of the compass
            else
            {
                transform.Rotate(_mainCamTransform.forward, Vector3.Dot(_mousePosDelta, _mainCamTransform.up) * RotateSpeed, Space.World);
            }

            //update the current position as the previous position (last frame)
            _mousePrevPos = Input.mousePosition;
        }

        _compassRotateAngle = transform.eulerAngles.z;

        //return the angle difference between compass and the door
        Debug.Log(Mathf.Abs(Mathf.DeltaAngle(_compassRotateAngle, _doorFacingAngle)));
    }
}
