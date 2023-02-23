using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    private  MousePos mouse;
    public Normal_Attack attack;
    // Start is called before the first frame update
    void Start()
    {
        mouse = GameObject.FindGameObjectWithTag("Mouse").GetComponent<MousePos>();
    }

    // Update is called once per frame
    void Update()
    {
        {
            if (!attack.attacking)
            {
                Vector3 rotZ = mouse.mousePos - transform.position;
                float PosZ = Mathf.Atan2(rotZ.y, rotZ.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(0, 0, PosZ);
            }
        }
    }
}
