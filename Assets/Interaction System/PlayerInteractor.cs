using UnityEngine;
using UnityEngine.InputSystem;

/**
 * PlayerInteractor goes on the player and detects 
 * the colsest object to interact with
 * 
 * Uses OverlapSphereNonAlloc to optimize physics
 * query performance
 */

public class PlayerInteractor : MonoBehaviour
{    
    [SerializeField] private LayerMask interactableLayer; // which layers of colliders to use
    [SerializeField] private InputAction eKey;
    [SerializeField] private InteractPrompt prompt;
    [SerializeField] private int numberOfInteractables;

    private Collider[] buffer;
    private float radius = 5f; // radius from player
    private IInteractable focusedOn;


    private void Start()
    {
        buffer = new Collider[numberOfInteractables];
    }

    private void Update()
    {
        IInteractable nearest = FindNearestInteractable();
        UpdateFocus(nearest);

        if(focusedOn != null && eKey.triggered)
        {
            if (focusedOn.CanInteract())
            {
                focusedOn.Interact();
            }
        }
    }

    private void OnEnable()
    {
        eKey.Enable();
    }

    private void OnDisable()
    {
        eKey.Disable();
    }

    public IInteractable FindNearestInteractable()
    {
        int collideCount = Physics.OverlapSphereNonAlloc(transform.position, radius, buffer, interactableLayer, QueryTriggerInteraction.Collide);
        IInteractable nearest = null;
        float closestDistance = float.MaxValue;

        for(int i = 0; 0 < collideCount; i++)
        {
            Collider collideObject = buffer[i];

            if (collideObject == null) continue;

            IInteractable interactable = collideObject.GetComponentInParent<IInteractable>();

            if (interactable == null) continue;

            float distance = (collideObject.transform.position - transform.position).sqrMagnitude;

            // update best closest distance
            if(distance < closestDistance)
            {
                closestDistance = distance;
                nearest = interactable;
            }
        }
        return nearest;
    }

    private void UpdateFocus(IInteractable nearest)
    {
        if (ReferenceEquals(nearest, focusedOn)) return;
        focusedOn?.OnFocusLost(); // OnFocusLost is called when focusedOn is not null
        focusedOn = nearest;

        if(focusedOn != null)
        {
            focusedOn.OnFocusGained();
            prompt.Show(focusedOn);
        }
        else
        {
            prompt.Hide();
        }
    }
}
