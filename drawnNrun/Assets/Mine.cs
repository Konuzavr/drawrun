using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private GameObject Explodion;
  
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(Explodion, transform.position, Quaternion.identity);
     
        Destroy(gameObject);
    }
}
