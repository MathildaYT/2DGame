using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum playerState
{
    Alive,
    Die
}
public class PlayerController 
{
    private static PlayerController _Instance;
    public static PlayerController GetInstance
    {
        get
        {
            if (_Instance==null)
            {
                _Instance = new PlayerController();
            }
            return _Instance;
        }
    }
    public playerState _pState;
    public GameObject player;
    public float moveSpeed=10f;
    private SpriteRenderer _spriteRender;
    private Rigidbody2D _rig;
    public float upSpeed = 0.1f;
    private Animator animator;
    // Start is called before the first frame update
  public  void Awake()
    {
        
        player = GameObject.Find("PennyPixel").gameObject;
        _spriteRender = player.GetComponent<SpriteRenderer>();
        _rig = player.GetComponent<Rigidbody2D>();
        animator = player.GetComponent<Animator>();
    }

    // Update is called once per frame
  public  void Update()
    {
        if (_pState==playerState.Alive)
        {
           _spriteRender.enabled = true;

            Move();
        }
    }
    void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            player.transform.Translate(-moveSpeed*Time.deltaTime,0,0);
            _spriteRender.flipX = true;
           // animator.SetFloat("");
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.transform.Translate(moveSpeed * Time.deltaTime, 0, 0);
            _spriteRender.flipX = false;
           // animator.SetFloat("");

        }
        animator.SetBool("grounded", true);

        if (Input.GetKey(KeyCode.Space))
        {
            //tiaoyue
            _rig.AddForce(Vector3.up*upSpeed,ForceMode2D.Impulse);
        animator.SetBool("grounded", false);

        }
    }
}
