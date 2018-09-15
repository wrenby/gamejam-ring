using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SimpleMesh))]
public class MeshGUI : Editor {
    public override void OnInspectorGUI() {
        EditorGUI.BeginChangeCheck();

        serializedObject.Update();
        DrawDefaultInspector();

        if (EditorGUI.EndChangeCheck() || Event.current.commandName == "UndoRedoPerformed") {
            SimpleMesh m = (SimpleMesh)target;
            m.SetMesh();
        }
    }

    void OnSceneGUI() {
        SimpleMesh m = (SimpleMesh)target;
        EditorGUI.BeginChangeCheck();

        for (int i = 0; i < m.mesh_points.Length; i++) {
            m.mesh_points[i] = Handles.PositionHandle(m.transform.position + (Vector3)m.mesh_points[i], Quaternion.identity) - m.transform.position;
        }
        if (EditorGUI.EndChangeCheck()) {
            Undo.RecordObject(m, "SimpleMesh");
            m.SetMesh();
        }
    }
}