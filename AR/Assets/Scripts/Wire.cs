using UnityEngine;

public enum Colors
{
    Red,
    Green,
    Blue
}

[ExecuteAlways]
public class Wire : MonoBehaviour
{
    public LineRenderer line;  
    public Camera cam;

    [Space] 
    public bool canDrag;
    public LayerMask layer;

    [Space] 
    public Colors targetColor;
    
    
    private bool _dragging;

    private void Awake()
    {
        canDrag = true;
    }

    private void Update()
    {
        transform.localPosition = line.GetPosition(0);

        if (!canDrag) return;
        if (!_dragging) return;
        
        var ray = cam.ScreenPointToRay(Input.GetTouch(0).position);
        if (Physics.Raycast(ray, out var hit, 1000, layer))
        {
            line.SetPosition(0, transform.parent.InverseTransformPoint(hit.point));
        }
        
    }
    
    private void OnMouseDown()
    {
        _dragging = true;
    }

    private void OnMouseUp()
    {
        _dragging = false;
    }
}
