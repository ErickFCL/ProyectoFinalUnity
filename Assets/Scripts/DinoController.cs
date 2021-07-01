using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DinoController : MonoBehaviour
{
    private bool estaTocandoElSuelo = false;
    private float speed = 9;
    private float speedRun = 12;

    public GameObject rightBullet;
    public GameObject leftBullet;

    public List<AudioClip> audioClips;
    private AudioSource audioSource;
    private SpriteRenderer sr;
    private Animator animator;
    private Rigidbody2D rb2d;
    public Text scoreText;

    private int score = 0;
    private int scoreAmarillo = 0;
    private int vidas = 3;
    private int puntaje = 0;
    // Start is called before the first frame update
    void Start()
    {
         sr= GetComponent<SpriteRenderer>();//obtengo el objeto spriterender de player
      //  Debug.Log("hola mundo este es un metodo que se ejecuta una vez");
        //sr.flipX = true;
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();

        rb2d = GetComponent<Rigidbody2D>(); 
        audioSource.PlayOneShot(audioClips[1]);
    }

    // Update is called once per frame
    void Update()
    {
         scoreText.text = "MONEDAS: "+scoreAmarillo +"     " +"VIDAS: " +vidas+"     "+"PUNTAJE: "+ puntaje;
        rb2d.gravityScale = 25;
        //si esta muerto
         
    if(vidas !=0)
    {
       
        if(Input.GetKeyDown(KeyCode.A))
        {
           
            if(!sr.flipX)
            {
            var position = new Vector2(transform.position.x+0.5f,transform.position.y-0.5f);
                Instantiate(rightBullet,position,rightBullet.transform.rotation);
            }
            else{
             var position = new Vector2(transform.position.x-2f,transform.position.y-0.5f);
                Instantiate(leftBullet,position,rightBullet.transform.rotation);
            }
            audioSource.PlayOneShot(audioClips[2]);
        }
        
         if(Input.GetKey(KeyCode.RightArrow))
        {
            sr.flipX = false;
            Caminar();
            
            rb2d.velocity = new Vector2(speed,rb2d.velocity.y);
            if(Input.GetKey(KeyCode.UpArrow)&& estaTocandoElSuelo)
            {            
            saltarF();
            estaTocandoElSuelo = false;
            }
            if(Input.GetKey(KeyCode.Space))
            {
            Correr();
             rb2d.velocity = new Vector2(speedRun,rb2d.velocity.y);
            }
        }else if(Input.GetKey(KeyCode.LeftArrow))
        {
            sr.flipX = true;
            Caminar();
            rb2d.velocity = new Vector2(-speed,rb2d.velocity.y);
            if(Input.GetKey(KeyCode.UpArrow)&& estaTocandoElSuelo)
            {
               saltarF();
             
            estaTocandoElSuelo = false;
            }
            if(Input.GetKey(KeyCode.Space))
            {
            Correr();
             rb2d.velocity = new Vector2(-speedRun,rb2d.velocity.y);
            }
        }
        else
        {
            Quieto();
            rb2d.velocity = new Vector2(0,rb2d.velocity.y);
            if(Input.GetKey(KeyCode.UpArrow) && estaTocandoElSuelo)
            {
            saltarF();
             
            estaTocandoElSuelo = false;
            }
        }
    }
    else{
        //audioSource.PlayOneShot(audioClips[4]);
        Morir();
        Destroy(this.gameObject);
       }
    }  
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.layer == 6){
                estaTocandoElSuelo = true;
        }
        if(other.gameObject.layer == 9){
             Destroy(other.gameObject);
             scoreAmarillo ++;
             audioSource.PlayOneShot(audioClips[3]);
        }
        if(other.gameObject.layer == 11){
             Destroy(other.gameObject);
             scoreAmarillo += 2;
             audioSource.PlayOneShot(audioClips[3]);
        }
        if(other.gameObject.layer == 12){
             Destroy(other.gameObject);
             scoreAmarillo += 10;
             audioSource.PlayOneShot(audioClips[3]);
        }
        if(other.gameObject.layer == 10){ 
             vidas --;     
             audioSource.PlayOneShot(audioClips[4]);
        }if(other.gameObject.layer == 13){
             Destroy(this.gameObject);
             
        }
    }
    //funciones
     public void saltarF(){
        var upSpeed = 80f;
        rb2d.velocity = Vector2.up * upSpeed;
        Saltar();
        audioSource.PlayOneShot(audioClips[5]);
    }
    
    public void Quieto(){
        animator.SetInteger("Estado", 0);
    }
    public void Caminar(){
       animator.SetInteger("Estado", 1);
    }
    public void Saltar(){
        animator.SetInteger("Estado", 2);        
    }
    public void Morir(){
        animator.SetInteger("Estado", 3);        
    }
     public void Correr(){
        animator.SetInteger("Estado", 4);        
    }
    public void AumentaScore10(){
        puntaje += 10;      
    }
}
