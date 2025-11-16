using UnityEngine;

public class ResourceInteractable : MonoBehaviour, IInteractable
{
    [Header("Resource")]
    [SerializeField] GameObject resourcePrefab;
    
    [Space(15f)]
    [Header("Resource Spawn Settings")]
    [SerializeField] float horizontalForce;
    [SerializeField] float upwardThrust;
    
    [Space(15f)]
    [Header("Interaction Settings")]
    [SerializeField] int interactionsLeft = 3;
    [SerializeField] float selfDestructTime = 0.25f;
    [SerializeField] float interactBuffer = 0.5f;
    float interactCooldown = -1f;
    
    public bool CanInteract()
    {
        // check if we already interacted and we have a valid # of interactions left
        if (Time.time > interactCooldown & interactionsLeft > 0)
        {
            return true;
        }

        return false;
    }

    public bool Interact(Interactor interactor)
    {
        interactCooldown = Time.time + interactBuffer;
        interactionsLeft--;
        
        SpawnResource();

        if (interactionsLeft <= 0)
        {
            Destroy(gameObject, selfDestructTime);
        }
        
        return true;
    }
    
    void SpawnResource()
    {
        // choose a direction spawn resource towards
        GetSpawnDirection(out var direction);

        // spawn the resource
        var resource = Instantiate(resourcePrefab, transform.position, Quaternion.identity);
        var res_arc = resource.GetComponent<ArcSpawn>();
        res_arc.direction = direction;
        res_arc.origin = transform.position;
    }

    void GetSpawnDirection(out int direction)
    {
        Random.InitState(System.DateTime.Now.Millisecond);
        var range = Random.Range(0, 2);
        direction = 0;
        if (range == 0)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
    }
}
