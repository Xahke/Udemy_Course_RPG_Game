using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone_Skill : Skill
{
    [SerializeField] private GameObject clonePrefab;

    public void CreateClon()
    {
        GameObject newClone = Instantiate(clonePrefab);
    }

}
