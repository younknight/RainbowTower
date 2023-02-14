using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimation : MonoBehaviour
{
    Animator animator;
    int weaponIndex = 0;
    private void Awake()
    {
        if (PlayerManager.PlayerStatus[equipment.weapon] != null)
        {

            weaponIndex = PlayerManager.PlayerStatus[equipment.weapon].index;
            animator = GetComponent<Animator>();
            animator.SetInteger("weaponIndex", weaponIndex);
        }
    }
}
