using System;
using System.Collections;
using UnityEngine;

public class PickupMover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] public bool isActivated = false;

    ArcSpawn arc;
    
    Coroutine moveRoutine;
    bool canMove = false;

    void OnEnable()
    {
        arc = GetComponentInParent<ArcSpawn>();

        arc.OnFinishArc += ActivateMover;
    }

    void OnDisable()
    {
        arc.OnFinishArc -= ActivateMover;
    }

    void OnDestroy()
    {
        arc.OnFinishArc -= ActivateMover;
    }

    void ActivateMover()
    {
        isActivated = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isActivated) return;
        if (other.CompareTag("Player") && !canMove)
        {
            var player = other.gameObject;
            
            canMove = true;
            moveRoutine = StartCoroutine(MoveRoutine(player));
        }
    }
    
    void OnTriggerStay2D(Collider2D other)
    {
        if (!isActivated) return;
        if (other.CompareTag("Player") && !canMove)
        {
            var player = other.gameObject;
            
            canMove = true;
            moveRoutine = StartCoroutine(MoveRoutine(player));
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!isActivated) return;
        if (other.CompareTag("Player"))
        {
            canMove = false;
            if (moveRoutine == null) return;
            StopCoroutine(moveRoutine);
            moveRoutine = null;
        }
    }

    IEnumerator MoveRoutine(GameObject target)
    {
        var parentObj = transform.parent.gameObject;
        
        while (Vector2.Distance(transform.position, target.transform.position) > 0.01f)
        {
            parentObj.transform.position = 
                Vector2.MoveTowards(parentObj.transform.position, 
                    target.transform.position, moveSpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        
        yield return null;
        
        //TODO add to player's inventory
        
        Destroy(gameObject.transform.parent.gameObject);
    }
}
