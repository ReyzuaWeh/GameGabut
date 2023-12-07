using System.Collections;
using System.Collections.Generic;
using ClearSky;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class skill : MonoBehaviour
{
    public float kecepatan;
    public float waktuSerangA;
    public SimplePlayerController user;
    private float sizechange=0;
    private LineRenderer line;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        user = user.GetComponent<SimplePlayerController>();
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        waktuSerangA -= Time.deltaTime;
        if(gameObject.CompareTag("SkillA")){
            if(waktuSerangA > 0){
                sizechange += Time.deltaTime * kecepatan;
                Vector3 endP = transform.position + (transform.right * sizechange);
                line.SetPositions(new Vector3[]{transform.position,endP});
            }else{
                user.anim.SetBool("delay", false);
                user.move = true;
                Destroy(gameObject);
            }
        }else{
            if(waktuSerangA > 0){
                if(transform.rotation.eulerAngles.y == 0){
                    rb.velocity = new Vector2(kecepatan + Time.deltaTime, 0);
                }else{
                    rb.velocity = new Vector2( -kecepatan + Time.deltaTime, 0);
                }
            }else{
                Destroy(gameObject);
            }
        }
    }
}
