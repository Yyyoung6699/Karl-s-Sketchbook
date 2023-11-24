using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController cc;

    public float moveSpeed;//移动速度
    public float jumpSpeed;//跳跃速度

    private float horizontalMove, verticalMove;//移动
    private Vector3 dir;

    public float gravity;//重力
    private Vector3 velocity;

    public Transform groundCheck;//检测是否接触地面
    public float checkRadius;
    public LayerMask groundLayer;
    public bool isGround;

    public bool afterTutorial = false;

    public Touch touch;
    AudioSource audioPlayer;
    public AudioClip running;
    public AudioClip waterRunning;
    private void Start()
    {
        cc = GetComponent<CharacterController>();
        audioPlayer = GetComponent<AudioSource>();
        touch = GetComponent<Touch>();
    }

    private void Update()
    {
        if (afterTutorial)
        {
            StartControl();
        }
    }


    public void StartControl()
    {
        isGround = Physics.CheckSphere(groundCheck.position, checkRadius, groundLayer);//检测地面碰撞
        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetButtonDown("Jump") && isGround)
        {
            velocity.y = jumpSpeed;
        }

        horizontalMove = Input.GetAxis("Horizontal") * moveSpeed;
        verticalMove = Input.GetAxis("Vertical") * moveSpeed;

        dir = transform.forward * verticalMove + transform.right * horizontalMove;
        cc.Move(dir * Time.deltaTime);

        velocity.y -= gravity * Time.deltaTime;//重力
        cc.Move(velocity * Time.deltaTime);


        if (touch.TouchWaterBool == true)
        {
            audioPlayer.clip = waterRunning;
        }
        if (touch.TouchWaterBool == false)
        {
            audioPlayer.clip = running;
        }

        if (Mathf.Abs(horizontalMove) > 0.1f || Mathf.Abs(verticalMove) > 0.1f)
        {
            if (!audioPlayer.isPlaying)
            {
                audioPlayer.Play();                
            }
        }
        else
        {
            audioPlayer.Stop();
        }
    }
}
