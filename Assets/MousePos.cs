using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePos : MonoBehaviour
{
    public Vector3 mousePos;
    public Camera MainCam;

    void Start()
    {
        MainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    void Update()
    {
        mousePos = MainCam.ScreenToWorldPoint(Input.mousePosition);   

        Vector3 rotZ = mousePos - transform.position;
        float PosZ = Mathf.Atan2(rotZ.y, rotZ.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, PosZ);
    }
}
