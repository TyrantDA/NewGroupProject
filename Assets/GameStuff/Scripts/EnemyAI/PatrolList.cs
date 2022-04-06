using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolList : MonoBehaviour
{
    public string patrolName;
    [SerializeField] public List<GameObject> transformList = new List<GameObject>();
    [SerializeField] public List<int> patrolWait = new List<int>();

    public List<GameObject> getList()
    {
        return transformList;
    }

    public List<int> getWait()
    {
        return patrolWait;
    }
}
