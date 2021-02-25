using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class Trail : MonoBehaviour
{
    [SerializeField] private float pointSpacing = 0.1f; //Space between each point of linerenderer position
    [SerializeField] private Transform snake;

    private List<Vector2> points;

    private LineRenderer _line;
    private EdgeCollider2D _edgeCol;

    void Start()
    {
        _line = GetComponent<LineRenderer>(); //Line renderer reference
        _edgeCol = GetComponent<EdgeCollider2D>(); //Snake tail Collider reference

        points = new List<Vector2>();
        SetPoint();
    }
    void Update()
    {
        //Setting position after every point space

        if (Vector3.Distance(points.Last(), snake.position) > pointSpacing)
        {
            SetPoint();
        }
    }

    //Setting point of line renderer at some distance
    private void SetPoint()
    {
        if (points.Count > 1)
        {
            _edgeCol.points = points.ToArray<Vector2>();
        }

        points.Add(snake.position); //Adding points to list
        _line.positionCount = points.Count; //Setting linerenderer list count equals to points list
        _line.SetPosition(points.Count - 1, snake.position); //Setting new point to linerenderer list
    }
}
