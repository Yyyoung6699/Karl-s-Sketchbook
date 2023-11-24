using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController cc;

    public float moveSpeed;//�ƶ��ٶ�
    public float jumpSpeed;//��Ծ�ٶ�

    private float horizontalMove, verticalMove;//�ƶ�
    private Vector3 dir;

    public float gravity;//����
    private Vector3 velocity;

    public Transform groundCheck;//����Ƿ�Ӵ�����
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
        isGround = Physics.CheckSphere(groundCheck.position, checkRadius, groundLayer);//��������ײ
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

        velocity.y -= gravity * Time.deltaTime;//����
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
