using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float detection;
    public float spd;
    private SpriteRenderer musuh;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        musuh = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] detect = Physics2D.OverlapCircleAll(transform.position,detection);
        foreach(Collider2D cek in detect){
            if(cek.CompareTag("user")){
                Vector2 posisiUser = cek.gameObject.transform.position;
                Vector2 posisiMusuh = transform.position;
                if(posisiUser.x < posisiMusuh.x){
                    musuh.flipX = true;
                }else{
                    musuh.flipX = false;
                }
                if(posisiUser.x-posisiMusuh.x < 1){
                    rb.velocity = new Vector2(rb.velocity.x - spd *Time.deltaTime, 0);
                }else if(posisiUser.x - posisiMusuh.x > 1){
                    rb.velocity = new Vector2(rb.velocity.x + spd *Time.deltaTime, 0);
                }
            }
        }
    }
    private void OnDrawGizmos() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position,detection);
    }
}
