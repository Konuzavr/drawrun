using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    [SerializeField] private float radius;
    // Start is called before the first frame update
    void Start()
    {
        explode();
        
    }

   void explode()
    {
        Destroy(gameObject, 5f);
        CameraShake.Shake(.5f,.5f);
        Collider[] col = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider cols in col)
        {
            RunnerUnit runit = cols.GetComponent<RunnerUnit>();
            if (runit) runit.Die();
        }
    }
}
