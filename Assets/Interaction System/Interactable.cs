using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/**
 * Interactable goes on the object to interact with
 */

public class Interactable : MonoBehaviour, IInteractable
{
    [SerializeField] private string text = "E";
    [SerializeField] private bool isEnabled = true;
    [SerializeField] private UnityEvent onInteract;

    private Outline outline;

    //public string DisplayText => text;

    public bool CanInteract() => isEnabled;

    private void Awake()
    {
        outline = gameObject.AddComponent<Outline>();
        outline.OutlineMode = Outline.Mode.OutlineVisible;
        outline.OutlineColor = Color.lightPink;
        outline.OutlineWidth = 5.0f;
        outline.enabled = false;
    }

    public void Interact()
    {
        onInteract?.Invoke();
    }

    public void OnFocusGained()
    {
        outline.enabled = true;
    }

    public void OnFocusLost()
    {
        outline.enabled = false;
    }

    public void SetInteractionEnabled(bool enabled)
    {
        isEnabled = enabled;
    }

}
