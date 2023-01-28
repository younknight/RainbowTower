using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimation : MonoBehaviour
{
    Animator animator;
    int weaponIndex = 0;
    private void Awake()
    {
        weaponIndex = PlayerManager.playerStatus[equipment.weapon].index;
        animator = GetComponent<Animator>();
        animator.SetInteger("weaponIndex", weaponIndex);
    }
}
