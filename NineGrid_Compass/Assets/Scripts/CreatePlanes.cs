using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePlanes : MonoBehaviour
{
    [Header("House Size")]
    public Collider HouseCollider;
    private Vector3 _houseSize;
    private Vector3 _houseCenter;

    [Header("Planes")]
    public List<GameObject> Planes;

    [Header("Planes Variables")]
    public float PlanesNum;
    public float PlaneHeight;

    [Header("Planes Renderer")]
    public List<Renderer> PlanesRend;

    [Header("Planes Material")]
    public Material Plane1Mat;
    public Material Plane2Mat;
    public Material Plane3Mat;
    public Material Plane4Mat;
    public Material Plane5Mat;
    public Material Plane6Mat;
    public Material Plane7Mat;
    public Material Plane8Mat;
    public Material Plane9Mat;

    void Start()
    {
        HouseCollider = HouseCollider.GetComponent<Collider>();
        //get the size of the house collider
        _houseSize = HouseCollider.bounds.size;
        _houseCenter = HouseCollider.bounds.center;

        //create a list for containing the nine planes
        Planes = new List<GameObject>();
        for(int i = 0; i < PlanesNum; i++)
        {
            //create the plane
            Planes.Add(GameObject.CreatePrimitive(PrimitiveType.Plane));
        }
        foreach(var plane in Planes)
        {
            plane.transform.localScale = _houseSize / 10 / 3;
        }

        //set the corresponding planes position
        Planes[0].transform.position = new Vector3(-_houseSize.x / 3, PlaneHeight, _houseSize.z / 3);
        Planes[1].transform.position = new Vector3(_houseCenter.x, PlaneHeight, _houseSize.z / 3);
        Planes[2].transform.position = new Vector3(_houseSize.x / 3, PlaneHeight, _houseSize.z / 3);
        Planes[3].transform.position = new Vector3(-_houseSize.x / 3, PlaneHeight, _houseCenter.z);
        Planes[4].transform.position = new Vector3(_houseCenter.x, PlaneHeight, _houseCenter.z);
        Planes[5].transform.position = new Vector3(_houseSize.x / 3, PlaneHeight, _houseCenter.z);
        Planes[6].transform.position = new Vector3(-_houseSize.x / 3, PlaneHeight, -_houseSize.z / 3);
        Planes[7].transform.position = new Vector3(_houseCenter.x, PlaneHeight, -_houseSize.z / 3);
        Planes[8].transform.position = new Vector3(_houseSize.x / 3, PlaneHeight, -_houseSize.z / 3);

        //create a list for containing the nine planes renderer
        PlanesRend = new List<Renderer>();
        for(int i = 0; i < PlanesNum; i++)
        {
            PlanesRend.Add(Planes[i].GetComponent<Renderer>());
        }

        //assign the corresponding planes material
        PlanesRend[0].material = Plane1Mat;
        PlanesRend[1].material = Plane2Mat;
        PlanesRend[2].material = Plane3Mat;
        PlanesRend[3].material = Plane4Mat;
        PlanesRend[4].material = Plane5Mat;
        PlanesRend[5].material = Plane6Mat;
        PlanesRend[6].material = Plane7Mat;
        PlanesRend[7].material = Plane8Mat;
        PlanesRend[8].material = Plane9Mat;
    }
}
