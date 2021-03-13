using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class Tail : MonoBehaviour
{
    public float PointSpacing = 0.1f;
    List<Vector2> Points; // to gets the points in the space
    LineRenderer Line;
    [SerializeField]
    private Transform m_Snake;
    private EdgeCollider2D m_EdgeCollider;

    void Start()
    {
        Line = GetComponent<LineRenderer>();
        Points = new List<Vector2>();
        SetPoint();
        m_EdgeCollider = GetComponent<EdgeCollider2D>();
    }

    void Update()
    {
        if(Vector3.Distance(Points.Last(), m_Snake.position) > PointSpacing) 
        {
            SetPoint();
        }
    }

    // to create the points in the runtime by changing the position
    void SetPoint()
    {
        if (Points.Count > 1) // to make sure that there should be atleast 2 points
        {
            m_EdgeCollider.points = Points.ToArray<Vector2>();// converted our positon array for storing the same vale for the edge collider
        }
        Points.Add(m_Snake.position);
        Line.numPositions = Points.Count;
        Line.SetPosition(Points.Count - 1, m_Snake.position);
    }
}
