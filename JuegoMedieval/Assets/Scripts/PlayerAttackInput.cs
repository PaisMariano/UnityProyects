using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackInput : MonoBehaviour
{
    
    private CharacterAnimations playerAnimation;

    void Awake()
    {
        playerAnimation = GetComponent<CharacterAnimations>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            playerAnimation.Defend(true);
        }

        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            playerAnimation.UnFreezeAnimation();
            playerAnimation.Defend(false);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (Random.Range(0, 2) > 0)
            {
                playerAnimation.Attack_1();
            }
            else
            {
                playerAnimation.Attack_2();
            }
        }

    }        
}
