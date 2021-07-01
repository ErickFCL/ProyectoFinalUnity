using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{ 
    private SpriteRenderer sr;
    //private Animator animator;
    private Rigidbody2D rb2d;
    private float speed = 10;
    private bool limiteInicio = true;
    private bool limiteFin = false;
    // Start is called before the first frame update
    void Start()
    {
         sr= GetComponent<SpriteRenderer>();//obtengo el objeto spriterender de player
      //  Debug.Log("hola mundo este es un metodo que se ejecuta una vez");
        //sr.flipX = true;
       // animator = GetComponent<Animator>();

        rb2d = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(limiteInicio){
             sr.flipX = true;
            rb2d.velocity = new Vector2(-speed,rb2d.velocity.y);  
        }
        if(limiteFin){
            sr.flipX = false;
            rb2d.velocity = new Vector2(speed,rb2d.velocity.y);
        }
         
    }
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.layer == 7){
                limiteInicio = false;
                limiteFin = true;
        }
        if(other.gameObject.layer == 8){
                 
                limiteFin = false;
                limiteInicio = true;
        }
    }
}
