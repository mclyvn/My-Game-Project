using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
        public Rigidbody2D rb;
        public Animator anim;
        public Normal_Attack attack;
        private SpriteRenderer FlipCheck;
        private float moveSpeed = 3.5f;
        private float dashingPower = 12f;
        private float dashingTime = 0.25f;
        private float dashingCooldown = 0.8f;
        private float dashCount;
        private float dashCoolCount;
        public float Speed;
        private float RunSpeed = 5.5f;
        public float Maxstamina = 50;
        public float stamina;
        public bool dashing;
        public bool canDash;
        public bool run;
        public bool action;
        private bool RightFacing = true;
        private bool UpFace;
        private bool DownFace;
        public Vector3 movement;
        public bool test;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        FlipCheck = GetComponent<SpriteRenderer>();
        canDash = true;
        Speed = moveSpeed;
        stamina = Maxstamina;
    } 
    // Update is called once per frame
    void Update()
    {
        if (dashing)
        {
            return;
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        
        if (attack.attacking)
        {
            movement = new Vector3(0, 0, 0);
        }
        movement.Normalize();

        Flip();
        Up_Down_Check();
    }

    void FixedUpdate()
    {
        rb.velocity = movement * Speed;

        //Điều kiện dash
        {
            if (!canDash)
            {
                Dash();
            }

            anim.SetBool("dashing", dashing);

            if (Input.GetKeyDown(KeyCode.Space) && canDash && stamina >= 15)
            {
                Speed = dashingPower;
                dashCount = dashingTime;
                stamina -= 15;
                canDash = false;
                dashing = true;
                run = false;
                if (movement == new Vector3(0f, 0f, 0f))
                {
                    if (UpFace) movement.y = 1;
                    else
                    {
                        if (DownFace) movement.y = -1;
                        else
                        {
                            if (RightFacing) movement.x = 1;
                            else movement.x = -1;
                        }

                    }
                }
            }
        }

        if (dashing || attack.attacking)
        {
            return;
        }

        //Điều kiện chạy
        {
            if (Input.GetKey(KeyCode.LeftShift) && stamina >= 1 && movement != new Vector3(0f,0f,0f))
            {
                run = true;
            }

            anim.SetBool("run", run);

            if (run == true)
            {
                Run();
            }
        }
        //Hồi stamina
        {
            if (stamina < Maxstamina && !run)
            {
                stamina += 6 * Time.deltaTime;
                if (stamina > Maxstamina)
                {
                    stamina = Maxstamina;
                }
            }
        }
        //
        anim.SetBool("UpFace", UpFace);
        anim.SetBool("DownFace", DownFace);
    }
    //dash
    void Dash()
    {      
 
        if (dashCount > 0)
        {
            dashCount -= Time.deltaTime;

            if (dashCount <= 0)
            {
                Speed = moveSpeed;
                dashCoolCount = dashingCooldown;
                dashing = false;
            }
        }
        if (dashCoolCount > 0)
        {
            dashCoolCount -= Time.deltaTime;
            if (dashCoolCount <=0)
            {
                canDash = true;
            }
        }                
    }
    //chạy
    void Run()
    {
        Speed = RunSpeed;
        stamina -= 5 * Time.deltaTime;
        if (!Input.GetKey(KeyCode.LeftShift) || stamina < 1 || movement == new Vector3(0f,0f,0f))
        {
            run = false;
            Speed = moveSpeed;
        }
    }   
    //đảo hướng Trái Phải
    void Flip()
    {
        if (RightFacing && movement.x < 0 || !RightFacing && movement.x >0)
        {
            RightFacing = !RightFacing;
            FlipCheck.flipX = !FlipCheck.flipX;
        }
    }
    //đảo hướng lên xuống
    void Up_Down_Check()
    {
        if (movement.y == 1)
        {
            UpFace = true;
            DownFace = false;
        }
        else
        {
            if (movement.y == -1)
            {
                DownFace = true;
                UpFace = false;
            }

            if (movement.x != 0)
            {
                UpFace = false;
                DownFace = false;
            }           
        }       
    }
}
