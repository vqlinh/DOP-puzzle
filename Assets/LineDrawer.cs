using UnityEngine;
using System.Collections.Generic;

public class LineDrawer : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider;
    private List<Vector3> points;
    public int i;

    void Start()
    {

        lineRenderer = GetComponent<LineRenderer>();
        edgeCollider = GetComponent<EdgeCollider2D>();
        points = new List<Vector3>();
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            points.Clear();
            lineRenderer.positionCount = 0;
            edgeCollider.Reset();
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;

            if (points.Count == 0 || Vector3.Distance(points[points.Count - 1], mousePosition) > 0.1f)
            {
                points.Add(mousePosition);
                lineRenderer.positionCount = points.Count;
                lineRenderer.SetPosition(points.Count - 1, mousePosition);

                // Cập nhật EdgeCollider2D
                edgeCollider.points = ConvertToVector2(points);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (i == GameManager.i.count)
            {
                GameManager.i.win = true;
            }
            points.Clear();
            lineRenderer.positionCount = 0;
            edgeCollider.Reset();
        }
    }

    private Vector2[] ConvertToVector2(List<Vector3> vector3List)
    {
        Vector2[] vector2Array = new Vector2[vector3List.Count];
        for (int i = 0; i < vector3List.Count; i++)
        {
            vector2Array[i] = new Vector2(vector3List[i].x, vector3List[i].y);
        }
        return vector2Array;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("tron"))
        {
            i++;
            Debug.Log("i");
        }
        if (collision.gameObject.CompareTag("obstacle"))
        {
            i--; Debug.Log("i--");
        }
    }
}
