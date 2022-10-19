using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawController : MonoBehaviour
{
    public GameObject LinePrefab;
    public GameObject LineContent;

    private GameObject _currentLine;
    private LineRenderer _lineRenderer;
    private EdgeCollider2D _edgeCollider;
    private List<Vector2> _mousePositions = new();

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateLine();
        }
        if (Input.GetMouseButton(0))
        {
            Vector2 currMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector2.Distance(currMousePos, _mousePositions[_mousePositions.Count - 1]) > 0.1f)
            {
                UpdateLine(currMousePos);
            }
        }
    }

    private void CreateLine()
    {
        _currentLine = Instantiate(LinePrefab, Vector2.zero, Quaternion.identity);
        _currentLine.transform.parent = LineContent.transform;
        _lineRenderer = _currentLine.GetComponent<LineRenderer>();
        _edgeCollider = _currentLine.GetComponent<EdgeCollider2D>();
        _mousePositions.Clear();
        _mousePositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        _mousePositions.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        _lineRenderer.SetPosition(0, _mousePositions[0]);
        _lineRenderer.SetPosition(1, _mousePositions[1]);
        _edgeCollider.points = _mousePositions.ToArray();
    }

    private void UpdateLine(Vector2 pos)
    {
        _mousePositions.Add(pos);
        _lineRenderer.positionCount++;
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, pos);
        _edgeCollider.points = _mousePositions.ToArray();
    }

    public void ClearLineContent()
    {
        for (int i = 0; i < LineContent.transform.childCount; ++i)
        {
            GameObject.Destroy(LineContent.transform.GetChild(i).gameObject);
        }
    }
}
