#if(UNITY_EDITOR)

using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(InvertMesh))]
public class AddInvertedMeshColliderEditor : Editor
{

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        InvertMesh script = (InvertMesh)target;
        if (GUILayout.Button("Create Inverted Mesh Collider"))
            script.CreateInvertedMeshCollider();
    }

}
#endif

