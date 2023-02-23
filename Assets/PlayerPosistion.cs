using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosistion : MonoBehaviour
{
    float PlayerPosX;
    float PlayerPosY;

    // Update is called once per frame
    void Start()
    {
        PlayerPosX = transform.position.x;
        PlayerPosY = transform.position.y;
    }
}
