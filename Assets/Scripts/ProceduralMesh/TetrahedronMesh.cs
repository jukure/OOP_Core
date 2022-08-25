using UnityEngine;
using System.Collections;

[RequireComponent (typeof (MeshCollider))]
[RequireComponent (typeof (MeshFilter))]
[RequireComponent (typeof (MeshRenderer))]
public class TetrahedronMesh : MonoBehaviour {
	
	public bool sharedVertices = false;

    private void Awake()
    {
//		Rebuild();
    }

    public void Rebuild(){


		MeshFilter meshFilter = GetComponent<MeshFilter>();
		if (meshFilter==null){
			Debug.LogError("MeshFilter not found!");
			return;
		}
		MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
		if (meshFilter.sharedMesh == null)
			meshRenderer.material = new Material(Shader.Find("Diffuse"));

		
		Vector3 p0 = new Vector3(0,0,0);
		Vector3 p1 = new Vector3(1,0,0);
		Vector3 p2 = new Vector3(0.5f,0,Mathf.Sqrt(0.75f));
		Vector3 p3 = new Vector3(0.5f,Mathf.Sqrt(0.75f),Mathf.Sqrt(0.75f)/3);
		Vector3 pc = 0.25f*(p0+p1+p2+p3);
		p0 -= pc;
		p1 -= pc;
		p2 -= pc;
		p3 -= pc;
		
		Mesh mesh = meshFilter.sharedMesh;
		if (mesh == null){
			meshFilter.mesh = new Mesh();
			mesh = meshFilter.sharedMesh;
		}
		mesh.Clear();
		if (sharedVertices){
			mesh.vertices = new Vector3[]{p0,p1,p2,p3};
			mesh.triangles = new int[]{
				0,1,2,
				0,2,3,
				2,1,3,
				0,3,1
			};	
			// basically just assigns a corner of the texture to each vertex
			mesh.uv = new Vector2[]{
				new Vector2(0,0),
				new Vector2(1,0),
				new Vector2(0,1),
				new Vector2(1,1),
			};
		} else {
			mesh.vertices = new Vector3[]{
				p0,p1,p2,
				p0,p2,p3,
				p2,p1,p3,
				p0,p3,p1
			};
			mesh.triangles = new int[]{
				0,1,2,
				3,4,5,
				6,7,8,
				9,10,11
			};
			
			Vector2 uv0 = new Vector2(0,0);
			Vector2 uv1 = new Vector2(1,0);
			Vector2 uv2 = new Vector2(0.5f,1);
			
			mesh.uv = new Vector2[]{
				uv0,uv1,uv2,
				uv0,uv1,uv2,
				uv0,uv1,uv2,
				uv0,uv1,uv2
			};
			
		}
		
		mesh.RecalculateNormals();
		mesh.RecalculateBounds();
		mesh.Optimize();

		// Add mesh collider
		MeshCollider meshc = gameObject.AddComponent(typeof(MeshCollider)) as MeshCollider;
		meshc.sharedMesh = null;
		meshc.sharedMesh = meshFilter.sharedMesh;
		meshc.convex = true; // because non-convex non-kinematic is non-supported
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

}