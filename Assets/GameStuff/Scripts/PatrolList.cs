using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolList : MonoBehaviour
{
    public string patrolName;
    [SerializeField] public List<GameObject> transformList = new List<GameObject>();

    public List<GameObject> getList()
    {
        return transformList;
    }
}
