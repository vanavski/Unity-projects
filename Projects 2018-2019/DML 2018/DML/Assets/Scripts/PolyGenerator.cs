using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolyGenerator : MonoBehaviour
{
    public GameObject current;
    
    [SerializeField]
    private int verticesCount = 7;

    private MeshFilter _myMeshFilter;
    public MeshFilter MyMeshFilter
    {
        get
        {
            if (_myMeshFilter == null)
            {
                _myMeshFilter = GetComponent<MeshFilter>();
            }
            return _myMeshFilter;
        }
    }

    private List<GameObject> points = new List<GameObject>();

    private void Start()
    {
        verticesCount = Random.Range(3,15);
        // SetPointsRandomly();
        SetPointsRadially(verticesCount);

        GenerateAndAssign();
    }

    private void SetPointsRadially(int pointCount)
    {
        var createObj = Instantiate(current, new Vector3(0,0,0),Quaternion.identity);
        points.Add(new GameObject("point ZERO"));

        for (int i = 0; i < pointCount - 1; i++)
        {
            GameObject newTr = Instantiate(current, new Vector3(0,0,0),Quaternion.identity);
            newTr.transform.position = Quaternion.Euler(0f, i * (360f / (pointCount - 1)), 0f) * Vector3.forward;
            points.Add(newTr);
        }
    }

    // private void SetPointsRandomly()
    // {
    //     for (int i = 0; i < verticesCount; i++)
    //     {
    //         GameObject newTr = new GameObject("point" + i);
    //         newTr.transform.position = new Vector3(
    //             Random.Range(-5f, 5f),
    //             Random.Range(-5f, 5f),
    //             Random.Range(-5f, 5f)
    //         );
    //         points.Add(newTr);
    //     }
    // }

    private void Update()
    {
        UpdateVerticesPositions();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MyMeshFilter.mesh.RecalculateBounds();
            MyMeshFilter.mesh.RecalculateNormals();
        }
    }

    private Vector3[] GetVerticesPositions()
    {
        Vector3[] ret = new Vector3[points.Count];

        for (int i = 0; i < points.Count; i++)
        {
            ret[i] = points[i].transform.position;
        }
        return ret;
    }

    private void UpdateVerticesPositions()
    {
        MyMeshFilter.mesh.vertices = GetVerticesPositions();
    }

    private void GenerateAndAssign()
    {
        Mesh myMesh = new Mesh();
        myMesh.name = "Custom Mesh " + System.DateTime.Now.ToString();

        myMesh.vertices = new Vector3[points.Count];
        myMesh.triangles =
        //  new int[] {
        //     0,1,2,
        //     0,2,3,
        //     0,3,4,
        //     0,4,5,
        //     0,5,6,
        // };
        CalculateTriangles();
        MyMeshFilter.mesh = myMesh;
    }

    private int[] CalculateTriangles()
    {
        int[] ret = new int[(points.Count - 1) * 3];

        for (int i = 0; i < ret.Length; i += 3)
        {
            ret[i] = 0;
            ret[i + 1] = 1 + i / 3;
            ret[i + 2] = 2 + i / 3;
            Debug.Log(ret[i] + ", " + ret[i + 1] + ", " + ret[i + 2]);
        }
        ret[ret.Length - 1] = ret[1];

        return ret;
    }
}
