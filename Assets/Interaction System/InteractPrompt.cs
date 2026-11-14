using TMPro;
using UnityEngine;

public class InteractPrompt : MonoBehaviour
{
    [SerializeField] private Vector3 offset = new(0f, 1f, 0f);

    private TMP_Text label;
    private Camera camera;
    private Transform target;
    private Canvas canvas;
    private RectTransform canvasRect;
    private RectTransform labelRect;

    private void Awake()
    {
        camera = Camera.main;
        labelRect = label.rectTransform;
        canvas = label.GetComponentInParent<Canvas>();
        canvasRect = canvas.GetComponent<RectTransform>();
        Hide();
    }

    private void LateUpdate()
    {
        if (target == null) return;

        if (!label.gameObject.activeSelf)
        {
            label.gameObject.SetActive(true);
        }
        Vector3 worldPos = target.position + offset;
        Vector3 screenPos = camera.WorldToScreenPoint(worldPos);
        Camera uiCam = canvas.renderMode == RenderMode.ScreenSpaceOverlay ? null : camera;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPos, uiCam, out Vector2 localPoint))
        {
            labelRect.anchoredPosition = localPoint;
        }

    }
    public void Show(IInteractable focusedOn)
    {
        // enable prompt
        if(focusedOn == null)
        {
            Hide();
            return;
        }
        target = focusedOn.transform;
        label.text = "[E] Read";
        label.gameObject.SetActive(true);
    }

    public void Hide()
    {
        // disable prompt
        label.gameObject.SetActive(false);
        target = null;
    }
}
