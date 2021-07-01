using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float velocityX=10f;
    private Rigidbody2D rigidbody;
    private DinoController playerController;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerController = FindObjectOfType<DinoController>(); //lo busca
        //para eliminar gameobject
        Destroy(gameObject,3);
    }

    // Update is called once per frame
    void Update()
    {
         rigidbody.velocity = Vector2.right * velocityX;
    }
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag =="Enemy" ){
            Destroy(other.gameObject);
            Destroy(this.gameObject);
            playerController.AumentaScore10();
        }
    }
}
