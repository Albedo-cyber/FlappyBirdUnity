using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;
    public float upForce = 200f;

    private RoteBird rotateBird;
    

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim =GetComponent < Animator>();
        rotateBird = GetComponent < RoteBird>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (isDead) return;
        {
            if(Input.GetMouseButtonDown(0))
            {
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(Vector2.up*upForce);
                anim.SetTrigger("Flap");
                SoundSystem.instance.PlayFlap();
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isDead = true;
        anim.SetTrigger("Die");
        rotateBird.enabled = false;
        //Invoke("BirdDie", 1f);
        
        GameController.instance.BirdDie();
        rb2d.velocity = Vector2.zero;
        SoundSystem.instance.PlayHit();
    }

    
}
