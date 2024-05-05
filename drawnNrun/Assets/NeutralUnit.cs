using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeutralUnit : MonoBehaviour
{
    private RunnerUnit runner;
    [SerializeField] SkinnedMeshRenderer smesh;
    [SerializeField] Material greeenMat;
    private Material[] materialsCopy;
    public int index = 3;
    private void Awake()
    {
        runner = GetComponent<RunnerUnit>();
    }
    public void BecomePlayableUnit()
    {
        materialsCopy = smesh.materials;
        materialsCopy[0] = greeenMat;
        smesh.materials = materialsCopy;
        gameObject.layer = 7;
        runner.enabled = true;
      
        this.enabled = false;
    }
}
