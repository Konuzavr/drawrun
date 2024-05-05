using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerUnit : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float offsetY;
    bool Moving;
    Vector3 target;
    [SerializeField] float speed = 1f;
    [SerializeField] private ParticleSystem deathParticle;
    bool moving;
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        StartRunning();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<NeutralUnit>())
        {
            CollideWithStickman(collision);
        }
    }
   
    public void MoveTo(Vector3 pos)
    {
        moving = true;
       target = new Vector3(pos.x,transform.position.y,pos.z);
        
    }

    private void Update()
    {
        if (moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed);
        }
        if (transform.position == target) moving = false;

    }
    public void StartRunning()
    {
        animator.SetBool("running",true);
    }
    private void CollideWithStickman(Collision stickman)
    {
        stickman.transform.parent = this.transform.parent;
        stickman.gameObject.GetComponent<NeutralUnit>().BecomePlayableUnit();
    }
    public void Die()
    {
        deathParticle.Play();
        animator.SetTrigger("death");
        transform.parent = null;
        Destroy(gameObject, 0.5f);
        this.enabled = false;
    }
   
}
