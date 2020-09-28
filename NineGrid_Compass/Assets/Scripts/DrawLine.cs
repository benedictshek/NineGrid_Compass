using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    [Header("House Size")]
    public Collider HouseCollider;
    private Vector3 _houseSize;

    [Header("Draw Lines")]
    public List<LineRenderer> Lines;
    private LineRenderer _line1;
    private LineRenderer _line2;
    private LineRenderer _line3;
    private LineRenderer _line4;

    [Header("Lines Variables")]
    public float StartWidth;
    public float EndWidth;

    void Start()
    {
        //get the size of the house collider
        HouseCollider = HouseCollider.GetComponent<Collider>();
        _houseSize = HouseCollider.bounds.size;

        //create a list for containing all the lines that need to draw
        Lines = new List<LineRenderer>();
        Lines.Add(_line1);
        Lines.Add(_line2);
        Lines.Add(_line3);
        Lines.Add(_line4);
        //create a GameObject for each lines and each of them has a line renderer attached
        for (int i = 0; i < Lines.Count; i++)
        {
            Lines[i] = new GameObject().AddComponent<LineRenderer>();
        }
        //for each lines
        foreach(var line in Lines)
        {
            //set the GameObjects as the child of the current gameObject
            line.transform.SetParent(transform, false);
            line.material = new Material(Shader.Find("Sprites/Default"));
            //set the line width
            line.startWidth = StartWidth;
            line.endWidth = EndWidth;
        }

        //Draw the horizontal first line
        Vector3[] positions = new Vector3[2];
        positions[0] = new Vector3(-_houseSize.x / 2, _houseSize.y, _houseSize.z / 2 / 3);
        positions[1] = new Vector3(_houseSize.x / 2, _houseSize.y, _houseSize.z / 2 / 3);
        Lines[0].positionCount = positions.Length;
        Lines[0].SetPositions(positions);

        //Draw the horizontal second line
        Vector3[] positions2 = new Vector3[2];
        positions2[0] = new Vector3(-_houseSize.x / 2, _houseSize.y, -_houseSize.z / 2 / 3);
        positions2[1] = new Vector3(_houseSize.x / 2, _houseSize.y, -_houseSize.z / 2 / 3);
        Lines[1].positionCount = positions2.Length;
        Lines[1].SetPositions(positions2);

        //Draw the vertical first line
        Vector3[] positions3 = new Vector3[2];
        positions3[0] = new Vector3(-_houseSize.x / 2 / 3, _houseSize.y, -_houseSize.z / 2);
        positions3[1] = new Vector3(-_houseSize.x / 2 / 3, _houseSize.y, _houseSize.z / 2);
        Lines[2].positionCount = positions3.Length;
        Lines[2].SetPositions(positions3);

        //Draw the vertical second line
        Vector3[] positions4 = new Vector3[2];
        positions4[0] = new Vector3(_houseSize.x / 2 / 3, _houseSize.y, -_houseSize.z / 2);
        positions4[1] = new Vector3(_houseSize.x / 2 / 3, _houseSize.y, _houseSize.z / 2);
        Lines[3].positionCount = positions4.Length;
        Lines[3].SetPositions(positions4);
    }
}
