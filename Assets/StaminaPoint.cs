using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StaminaPoint : MonoBehaviour
{
    public PlayerMovement player;
    public Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = player.Maxstamina;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.Update();
    }
    protected virtual void Update()
    {
        if (this.slider == null) return;
        slider.value = player.stamina;
    }
}
