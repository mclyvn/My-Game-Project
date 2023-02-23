using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal_Attack : MonoBehaviour
{
    private GameObject attackArea = default;
    public float Cooldown = 0.5f;
    private float CooldownCount;
    private float attackSpeed = 3f;
    private float attackCount;
    public bool attacking;
    public bool canAttack;
    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && canAttack)
        {
            attackCount = 1 / attackSpeed;
            attacking = true;
            attackArea.SetActive(attacking);
            canAttack = false;
        }
        if (!canAttack)
        {
            Attacking();
        }
    }
    void Attacking()
    {
        if (attackCount > 0)
        {
            attackCount -= Time.deltaTime;
            if (attackCount <= 0)
            { 
                attacking = false;
                attackArea.SetActive(attacking);
                CooldownCount = Cooldown;
            } 
        }
        if (CooldownCount >0)
        {   
            CooldownCount -= Time.deltaTime;
            if (CooldownCount <= 0)
            {
                canAttack = true;
            }
        }
    }
}
