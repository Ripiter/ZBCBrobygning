using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Wire : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public bool IsLeftWire;
    private Image image;
    public Color CustomColor;
    public WireTask wireTask;

    private LineRenderer lineRenderer;
    private Canvas canvas;
    private bool isDragStarted = false;
    public bool IsSuccess = false;

    public TextMeshProUGUI text;

    private void Start()
    {
    }
    private void Awake()
    {
        image = GetComponent<Image>();
        lineRenderer = GetComponent<LineRenderer>();
        canvas = GetComponentInParent<Canvas>();
        wireTask = GetComponentInParent<WireTask>();
    }


    // Update is called once per frame
    void Update()
    {
        if (isDragStarted)
        {
            Vector2 movePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, canvas.worldCamera, out movePos);
            lineRenderer.startWidth = 0.01f;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, canvas.transform.TransformPoint(movePos));
        }
        else
        {
            if (!IsSuccess)
            {
                lineRenderer.startWidth = 0.5f;
                lineRenderer.SetPosition(0, Vector3.zero);
                lineRenderer.SetPosition(1, Vector3.zero);
            }
        }

        bool isHovered = RectTransformUtility.RectangleContainsScreenPoint(transform as RectTransform, Input.mousePosition, canvas.worldCamera);
        if (isHovered)
        {
            wireTask.CurrentHoveredWire = this;
        }
    }

    public void SetColor(Color color)
    {
        image.color = color;
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;
        CustomColor = color;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //needed for drag but not used
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        

        if (!IsLeftWire)
        {
            return;
        }
        //IF is succesfull dont draw more lines
        if (IsSuccess)
        {
            return;
        }
        isDragStarted = true;
        wireTask.CurrentDraggedWire = this;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (wireTask.CurrentHoveredWire != null)
        {
            if (wireTask.CurrentHoveredWire.CustomColor == CustomColor && !wireTask.CurrentHoveredWire.IsLeftWire)
            {
                IsSuccess = true;
                //Set succesful on the right wire as well
                wireTask.CurrentHoveredWire.IsSuccess = true;

            }
        }
        isDragStarted = false;
        wireTask.CurrentDraggedWire = null;
    }
}
