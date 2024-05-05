using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Transform player;
    private int numberOfStickmans;
    public CursorTrail _trail;
    [SerializeField] CursorTrail trail;
    public List<Vector3> unitPositions;
    public List<RunnerUnit> runnerUnits;
   private void Start()
    {
        numberOfStickmans = transform.childCount - 1;
        RecountUnits();
    }
    private void Update()
    {
        
    }
    public void ReroupUnits()
    {
        unitPositions.Clear();
        for (int i = 0; i < _trail.points.Count; i++)
        {
            unitPositions.Add(_trail.points[i]);
        }

        RecountUnits();
        
        for (int i = 0; i < runnerUnits.Count; i++)
        {
            int matematikCount = unitPositions.Count  / (runnerUnits.Count);
            runnerUnits[i].MoveTo(unitPositions[matematikCount * i]);
        }
    }
    void RecountUnits()
    {
        runnerUnits.Clear();
        foreach (RunnerUnit g in transform.GetComponentsInChildren<RunnerUnit>())
        {
            runnerUnits.Add(g);
        }
    }
}
