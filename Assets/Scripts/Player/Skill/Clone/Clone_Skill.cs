using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone_Skill : Skill
{
    [Header("Clone info")]
    [SerializeField] private float cloneDuration;
    [SerializeField] private GameObject clonePrefab;
    [SerializeField] private bool canAttack;

    public void CreateClon(Transform _clonePosition)
    {
        GameObject newClone = Instantiate(clonePrefab);
        newClone.GetComponent<Clone_Skill_Controller>().SetupClone(_clonePosition,cloneDuration,canAttack);
    }

}
