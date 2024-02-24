using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectSystem : MonoBehaviour
{

    [SerializeField] private CursorManager.CursorType cursorType;
    [SerializeField] private int healAmount;

    private GameObject player;
    private float emptyChance;
    private Animator anim;
    private PlayerStats playerStats;

    private bool cracked = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    private void OnMouseDown()
    {
        emptyChance = Random.Range(0.0f, 1.0f);
        anim.SetTrigger("Oppen");
        if(!cracked)
        {
            playerStats.eggCnt++;
            cracked = true;
        }
    }

    private void OnMouseUp()
    {
        // empty
    }

    private void OnMouseEnter()
    {
        CursorManager.Instance.SetActiveCursorType(cursorType);
    }

    private void OnMouseExit()
    {
        CursorManager.Instance.SetActiveCursorType(CursorManager.CursorType.Aim);
    }

    private void DestroyEgg()
    {
        CursorManager.Instance.SetActiveCursorType(CursorManager.CursorType.Aim);
        if (emptyChance < 0.1f)
        {
            anim.SetBool("isEmpty", true);
        }
        else
        {
            anim.SetBool("isEmpty", false);
            playerStats.HealCharacter(healAmount);
        }
        Destroy(gameObject);
    }
}
