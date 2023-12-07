using System;
using Unity.Mathematics;
using UnityEngine;

namespace ClearSky
{
    public class SimplePlayerController : MonoBehaviour
    {
        public Transform attPos;
        public GameObject blast;
        public GameObject firstSkill;
        public GameObject secSkill;
        public GameObject trdSkill;
        public GameObject frthSkill;
        public float maxHP;
        public float hpNow;
        public float delayAttack;
        private float cdA = 0f;
        public float delaySkill1;
        public float cd1 = 0f;
        public float delaySkill2;
        public float cd2 =0f;
        public float delaySkill3;
        public float cd3 =0f;
        public float delaySkill4;
        public float cd4 =0f;
        public float movePower = 10f;
        public float jumpPower = 15f; //Set Gravity Scale in Rigidbody2D Component to 5

        private Rigidbody2D rb;
        public Animator anim;
        Vector3 movement;
        private int direction = 1;
        bool isJumping = false;
        public bool move;
        private bool alive = true;


        // Start is called before the first frame update
        void Start()
        {
            hpNow = maxHP;
            move = true;
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            anim.SetBool("delay", false);
        }

        private void Update()
        {
            Restart();
            if (alive)
            {
                Attack();
                if(move){
                    Die();
                    Hurt();
                    Jump();
                    Run();
                }
                allSkill();
            }
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            anim.SetBool("isJump", false);
        }


        void Run()
        {
            Vector3 moveVelocity = Vector3.zero;
            anim.SetBool("isRun", false);
            float horiz = Input.GetAxisRaw("Horizontal");
            if (horiz < 0)
            {
                direction = -1;
                transform.localScale = new Vector3(direction, 1, 1);
                if (!anim.GetBool("isJump"))
                    anim.SetBool("isRun", true);

            }
            if (horiz > 0)
            {
                direction = 1;
                transform.localScale = new Vector3(direction, 1, 1);
                if (!anim.GetBool("isJump"))
                    anim.SetBool("isRun", true);
            }
            rb.velocity = new Vector2(horiz * movePower, rb.velocity.y);
        }
        void Jump()
        {
            if (Input.GetButtonDown("Jump")
            && !anim.GetBool("isJump"))
            {
                isJumping = true;
                anim.SetBool("isJump", true);
            }
            if (!isJumping)
            {
                return;
            }

            rb.velocity = Vector2.zero;

            Vector2 jumpVelocity = new Vector2(0, jumpPower);
            rb.AddForce(jumpVelocity, ForceMode2D.Impulse);

            isJumping = false;
        }
        void Attack()
        {
            if(move){
                if (Input.GetMouseButtonDown(0)&&cdA <= 0)
                {
                    anim.SetInteger("skill",0);
                    anim.SetTrigger("attack");
                    cdA = delayAttack;
                }
            }
            if(cdA > 0){
                cdA -= Time.deltaTime;
            }
        }
        void allSkill(){
            if(move){
                if(Input.GetKeyDown(KeyCode.Alpha1)&& cd1 <= 0){
                    anim.SetInteger("skill",1);
                    anim.SetTrigger("attack");
                    anim.SetBool("delay",true);
                    cd1 = delaySkill1;
                }
                if(Input.GetKeyDown(KeyCode.Alpha2)&& cd2<=0){
                    anim.SetInteger("skill",2);
                    anim.SetTrigger("attack");
                    cd2 = delaySkill2;
                }
                if(Input.GetKeyDown(KeyCode.Alpha3)&& cd3 <=0){
                    anim.SetInteger("skill", 3);
                    anim.SetTrigger("attack");
                    cd3 = delaySkill3;
                }
                if(Input.GetKeyDown(KeyCode.Alpha4)&& cd4 <= 0){
                    anim.SetInteger("skill",4);
                    anim.SetTrigger("attack");
                    cd4=delaySkill4;
                }
            }
            if(cd1 > 0){
                cd1 -= Time.deltaTime;
            }
            if(cd2 >0){
                cd2 -= Time.deltaTime;
            }
            if(cd3 >0){
                cd3 -= Time.deltaTime;
            }
            if(cd4 >0){
                cd4 -= Time.deltaTime;
            }
        }
        public void piuw(){
            if(anim.GetInteger("skill")== 0){
                GameObject blastOn = Instantiate(blast,attPos.position, quaternion.identity);
                blastOn.transform.localScale = transform.localScale;
                blastOn.SetActive(true);
            }
            if(anim.GetInteger("skill") == 1){
                move = false;
                GameObject skillA = Instantiate(firstSkill, attPos.position, quaternion.identity);
                if(direction == -1){
                    skillA.transform.rotation = Quaternion.Euler(0f,180f,0f);
                }
                skillA.SetActive(true);
            }
            if(anim.GetInteger("skill") == 2){
                GameObject skillB = Instantiate(secSkill, attPos.position, quaternion.identity);
                if(direction == -1){
                    skillB.transform.rotation = Quaternion.Euler(0f,180f,0f);
                }
                skillB.SetActive(true);
            }
            if(anim.GetInteger("skill")== 3){
                GameObject skillC = Instantiate(trdSkill, attPos.position, quaternion.identity);
                if(direction == -1){
                    skillC.transform.rotation = Quaternion.Euler(0f,180f,0f);
                }
                skillC.SetActive(true);
            }
            if(anim.GetInteger("skill")== 4){
                GameObject skillD = Instantiate(frthSkill, attPos.position, quaternion.identity);
                if(direction == -1){
                    skillD.transform.rotation = Quaternion.Euler(0f,180f,0f);
                }
                skillD.SetActive(true);
            }
        }
        public void hitted(){
            hpNow--;
        }
        void Hurt()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                anim.SetTrigger("hurt");
                if (direction == 1)
                    rb.AddForce(new Vector2(-5f, 1f), ForceMode2D.Impulse);
                else
                    rb.AddForce(new Vector2(5f, 1f), ForceMode2D.Impulse);
            }
        }
        void Die()
        {
            if (hpNow <= 0)
            {
                anim.SetTrigger("die");
                alive = false;
            }
        }
        void Restart()
        {
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                anim.SetTrigger("idle");
                alive = true;
                hpNow = maxHP;
            }
        }
    }
}