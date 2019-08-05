using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polyleg : MonoBehaviour
{
    [SerializeField]
    public int steps = 10;
    [SerializeField]
    public float stepLength = 2f;
    [SerializeField]
    public float stepRandomTurn = 10f;

    #region Properties
    private MeshFilter _myMeshFilter;
    protected MeshFilter MyMeshFilter
    {
        get
        {
            if (_myMeshFilter == null)
            {
                _myMeshFilter = GetComponent<MeshFilter>();
            }
            if (_myMeshFilter == null)
            {
                _myMeshFilter = gameObject.AddComponent<MeshFilter>();
            }
            return _myMeshFilter;
        }
    }

    private MeshRenderer _myMeshRenderer;
    protected MeshRenderer MyMeshRenderer
    {
        get
        {
            if (_myMeshRenderer == null)
            {
                _myMeshRenderer = GetComponent<MeshRenderer>();
            }
            if (_myMeshRenderer == null)
            {
                _myMeshRenderer = gameObject.AddComponent<MeshRenderer>();
            }
            return _myMeshRenderer;
        }
    }

    #endregion

    #region Methods
    // Use this for initialization
    void Start()
    {
        Clear();
        Initialize();
        Generate();
    }

    private void Clear()
    {
        MyMeshFilter.mesh = null;
    }

    private void Initialize()
    {
        CreateEmptyMesh();
        SetMaterials();
    }

    private void CreateEmptyMesh()
    {
        Mesh mesh = new Mesh();
        mesh.name = gameObject.name;
        MyMeshFilter.mesh = mesh;
    }


    private void SetMaterials()
    {
        Material mat = new Material(Shader.Find("Standard"));
        MyMeshRenderer.material = mat;
    }

    private void Generate()
    {
        Mesh mesh = MyMeshFilter.mesh;
        Vector3[] vertices = new Vector3[steps * 4];
        int[] triangles = new int[(steps - 1) * (4 * 2 * 3)];

        Vector3 lastCenterPoint = new Vector3();
        Vector3 lastCenterPointDirection = Vector3.forward;

        for (int i = 0; i < steps; i++)
        {
            lastCenterPointDirection = Quaternion.Euler(
                Random.Range(-stepRandomTurn, stepRandomTurn),
                Random.Range(-stepRandomTurn, stepRandomTurn),
                Random.Range(-stepRandomTurn, stepRandomTurn))
            * lastCenterPointDirection;
            lastCenterPoint += lastCenterPointDirection * stepLength;

            vertices[i * 4 + 0] =
                lastCenterPoint +
                Quaternion.LookRotation(lastCenterPointDirection) * new Vector3(-1f, 1f, 0f);
            vertices[i * 4 + 1] = lastCenterPoint +
            Quaternion.LookRotation(lastCenterPointDirection) * new Vector3(1f, 1f, 0f);
            vertices[i * 4 + 2] = lastCenterPoint +
            Quaternion.LookRotation(lastCenterPointDirection) * new Vector3(1f, -1f, 0f);
            vertices[i * 4 + 3] = lastCenterPoint +
            Quaternion.LookRotation(lastCenterPointDirection) * new Vector3(-1f, -1f, 0f);
        }

        mesh.vertices = vertices;


        for (int i = 0; i < steps - 1; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                triangles[(i * 24) + j * 6] = (i * 4) + (0 + j);
                triangles[((i *24) + 1) + j * 6] = (i * 4) + 4 + j;
                triangles[((i *24) + 2) + j * 6] = (i * 4) + 5 + j;
                triangles[((i *24) + 3) + j * 6] = (i * 4) + 0 + j;
                triangles[((i *24) + 4) + j * 6] = (i * 4) + 5 + j;
                triangles[((i *24) + 5) + j * 6] = (i * 4) + 1 + j;
            }
            triangles[(i+1)*24 - 4] = triangles[(i*24)+1];
            triangles[(i+1)*24 - 2] = triangles[(i*24)+1];
            triangles[(i+1)*24 - 1] = triangles[(i*24)+3];
        }

        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }
    #endregion

    private void OnDrawGizmos()
    {
        if (Application.isPlaying)
        {
            Vector3[] vertices = MyMeshFilter.mesh.vertices;
            for (int i = 0; i < vertices.Length; i++)
            {
                Gizmos.color = Color.HSVToRGB((float)i / (float)(vertices.Length), 1f, 1f);
                Gizmos.DrawSphere(vertices[i], 0.1f);
            }
        }
    }
}
