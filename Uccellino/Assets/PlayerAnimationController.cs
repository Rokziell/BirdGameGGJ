using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{

    private Animator animator;
    private PlayerController playerController; 
    public ParticleSystem rparticles;
    public ParticleSystem pico_particles;
    private bool wasGrounded = false; 
    private bool firstTimeFix = false; 
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); 
        playerController = transform.parent.gameObject.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerController.CINEMATIC) return;
        //main animations handeling
        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            animator.SetBool("moving", true); 
            if(playerController.grounded && !rparticles.isPlaying) {
                rparticles.Play();
                Debug.Log("particles!");
            }
            else if(!playerController.grounded){
                rparticles.Stop();
                Debug.Log("No Particles!");
            }

        }else{
            animator.SetBool("moving", false);
            rparticles.Stop(); 
        }

        //fliping the axis
        if(Input.GetAxisRaw("Horizontal") > 0) transform.localScale = new Vector3(0.1f, transform.localScale.y, transform.localScale.z);
        //fliping the axis
        if(Input.GetAxisRaw("Horizontal") < 0) transform.localScale = new Vector3(-0.1f, transform.localScale.y, transform.localScale.z);
        //jump animation
        if(Input.GetButtonDown("Jump") && transform.parent.position.y < 0.5){
                animator.SetTrigger("jump");
        }       
        
        //fall animation 
        if(!wasGrounded && playerController.grounded){
            Debug.Log("fall!"); 
            animator.SetTrigger("grounded"); 
            if(!firstTimeFix){
                animator.SetBool("grounded", false);
                firstTimeFix = true; 
                Debug.Log("fix!"); 
            }
        }

        //pico animation
        if(playerController.grounded && Input.GetButtonDown("Fire1")){
            animator.SetTrigger("pico"); 
            //if(!pico_particles.isPlaying){ pico_particles.Play(); } 
           
        }

        wasGrounded = playerController.grounded; 
    }

    public void picoParticlesFire(){
     pico_particles.Play();
    }
    
}


