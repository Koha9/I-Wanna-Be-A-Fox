using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    public AudioClip JumpSound;
    private AudioSource m_JumpAudioSource;

    public float maxJumpHeight = 4;
    public float minJumpHeight = 1;
    public float timeToJumpApex = .4f;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    float moveSpeed = 6;

    public Vector2 wallJumpClimb;
    public Vector2 wallJumpOff;
    public Vector2 wallLeap;

    public float wallSlideSpeedMax = 3;
    public float wallStickTime = .25f;
    float timeToWallUnstick;

    float gravity;
    float maxJumpVelocity;
    float minJumpVelocity;
    Vector3 velocity;
    float velocityXSmoothing;

    float jumpTimes = 0;
    float jumpTimesOnWall = 0;
    public float maxJumpTimes = 2;
    public float maxJumpTimesOnWall = 1;
    public bool IsDied = false;
    public bool IsDiedOver = false;

    Controller2D controller;


    //Changed-bool-----------------------------------------------------------------------------------------------------------------------------------
    public Animator animator;


    bool boolLeft = false;
    bool boolRight = false;
    //Changed-bool-----------------------------------------------------------------------------------------------------------------------------------

    void Start()
    {
        m_JumpAudioSource = GetComponent<AudioSource>();
        controller = GetComponent<Controller2D>();

        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
        print("Gravity: " + gravity + "  Jump Velocity: " + maxJumpVelocity);
    }

    public void ImDied()
    {
        IsDied = true;
    }
    public void ImDiedOver()
    {
        IsDiedOver = true;
        animator.SetBool("IsDiedOver", IsDiedOver);
    }
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            IsDied = false;
            IsDiedOver = false;
        }
        animator.SetBool("IsDied", IsDied);


        //When The Fox Is Alive`````````````````````````````
        if (IsDied == false)
        {
            //Changed-bool-----------------------------------------------------------------------------------------------------------------------------------
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                boolLeft = true;
                boolRight = false;
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                boolRight = true;
                boolLeft = false;
            }
            else if ((Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow)))
            {
                boolLeft = false;
                boolRight = false;
            }
            else
            {
                boolLeft = false;
                boolRight = false;
            }

            animator.SetFloat("Speed", velocity.x);
            animator.SetBool("L", boolLeft);
            animator.SetBool("R", boolRight);
            


            if (Input.GetKey(KeyCode.Space))
            {
                animator.SetBool("IsJumping", true);
            }

            if (controller.collisions.below)
            {
                animator.SetBool("IsJumping", false);
            }

            if (controller.collisions.left && !controller.collisions.below && velocity.y < 0)
            {
                animator.SetBool("WallL", true);
            }
            else
            {
                animator.SetBool("WallL", false);
            }

            if (controller.collisions.right && !controller.collisions.below && velocity.y < 0)
            {
                animator.SetBool("WallR", true);
            }
            else
            {
                animator.SetBool("WallR", false);
            }

            //Changed-bool-----------------------------------------------------------------------------------------------------------------------------------

            Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            int wallDirX = (controller.collisions.left) ? -1 : 1;

            float targetVelocityX = input.x * moveSpeed;
            velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);

            bool wallSliding = false;
            /*if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0)
            {

                wallSliding = true;

                if (velocity.y < -wallSlideSpeedMax)
                {
                    velocity.y = -wallSlideSpeedMax;
                }

                if (timeToWallUnstick > 0)
                {
                    velocityXSmoothing = 0;
                    velocity.x = 0;

                    if (input.x != wallDirX && input.x != 0)
                    {
                        timeToWallUnstick -= Time.deltaTime;
                    }
                    else
                    {
                        timeToWallUnstick = wallStickTime;
                    }
                }
                else
                {
                    timeToWallUnstick = wallStickTime;
                }

        }*/

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (wallSliding)
                {
                    if (wallDirX == input.x && jumpTimesOnWall < maxJumpTimesOnWall)
                    {
                        velocity.x = -wallDirX * wallJumpClimb.x;
                        velocity.y = wallJumpClimb.y;
                        jumpTimesOnWall++;
                    }
                    else if (input.x == 0)
                    {
                        velocity.x = -wallDirX * wallJumpOff.x;
                        velocity.y = wallJumpOff.y;
                    }
                    /*else
                    {
                        velocity.x = -wallDirX * wallLeap.x;
                        velocity.y = wallLeap.y;
                    }*/
                }
                if (jumpTimes < maxJumpTimes)
                {
                    m_JumpAudioSource.clip = JumpSound;
                    m_JumpAudioSource.Play();
                    velocity.y = maxJumpVelocity;
                    jumpTimes++;

                }

            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                if (velocity.y > minJumpVelocity)
                {
                    velocity.y = minJumpVelocity;
                }
            }


            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime, input);

            if (controller.collisions.above)
            {
                velocity.y = 0;
            }
            else if (controller.collisions.below)
            {
                jumpTimes = 0;
                jumpTimesOnWall = 0;        //限制爬墙跳次数有BUG 
                velocity.y = 0;
            }
        }
    }
}