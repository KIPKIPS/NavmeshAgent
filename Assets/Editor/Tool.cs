using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class Tool:MonoBehaviour {
    [MenuItem("Tool/Export Navmesh Data")]
    public static void ExportNavMeshData() {
        NavMeshTriangulation data = NavMesh.CalculateTriangulation();
    }
}
