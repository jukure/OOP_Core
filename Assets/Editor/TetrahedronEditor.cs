using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof (TetrahedronMesh))] 
public class TetrahedronEditor : Editor {
	[MenuItem ("GameObject/Create Other/Tetrahedron")]
	static void Create(){
		GameObject gameObject = new GameObject("TetrahedronMesh");
		TetrahedronMesh s = gameObject.AddComponent<TetrahedronMesh>();
		MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
		meshFilter.mesh = new Mesh();
		s.Rebuild();

	}
	
	public override void OnInspectorGUI ()
	{
		TetrahedronMesh obj;

		obj = target as TetrahedronMesh;

		if (obj == null)
		{
			return;
		}
	
		base.DrawDefaultInspector();
		EditorGUILayout.BeginHorizontal ();
		
		// Rebuild mesh when user click the Rebuild button
		if (GUILayout.Button("Rebuild")){
			obj.Rebuild();
		}
		EditorGUILayout.EndHorizontal ();
	}
}