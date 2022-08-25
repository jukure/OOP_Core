using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor (typeof (TetrahedronUVMesh))] 
public class TetrahedronEditorUV : Editor {
	[MenuItem ("GameObject/Create Other/Tetrahedron UV")]
	static void Create(){
		GameObject gameObject = new GameObject("TetrahedronUVMesh");
		TetrahedronUVMesh s = gameObject.AddComponent<TetrahedronUVMesh>();
		MeshFilter meshFilter = gameObject.GetComponent<MeshFilter>();
		meshFilter.mesh = new Mesh();
		s.Rebuild();
	}
	
	public override void OnInspectorGUI ()
	{
		TetrahedronUVMesh obj;

		obj = target as TetrahedronUVMesh;

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
