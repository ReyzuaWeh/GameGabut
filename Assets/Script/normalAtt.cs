using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalAtt : MonoBehaviour
{
    public float timeShow;
    public float spd;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeShow>=0){
            timeShow -= Time.deltaTime;
        }
    }
}
