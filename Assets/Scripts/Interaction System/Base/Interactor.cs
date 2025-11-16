using System;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [Header("Raycast Settings")]
    [SerializeField] float raycastDistance;
    [SerializeField] Vector3 raycastOffset;
    [SerializeField] LayerMask layerMask;
    
    InputManager inputMgr;
    
    void Awake()
    {
        inputMgr = FindAnyObjectByType<InputManager>();
        if (inputMgr != null)
        {
            inputMgr.OnPlayerInteract += TryInteract;
        }
    }

    void OnDisable()
    {
        inputMgr.OnPlayerInteract -= TryInteract;
    }

    void TryInteract()
    {
        if (!DoInteractionTest(out var interactable)) return;
        if (interactable.CanInteract())
        {
            interactable.Interact(this);
        }
    }

    bool DoInteractionTest(out IInteractable interactable)
    {
        interactable = null;

        var hit = Physics2D.Raycast(transform.position + raycastOffset, Vector2.right, raycastDistance,
            layerMask);

        if (hit.collider != null)
        {
            interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                return true;
            }
        }

        return false;
    }
}
