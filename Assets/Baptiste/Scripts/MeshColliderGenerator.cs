using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshColliderGenerator : MonoBehaviour
{
    void Start()
    {
        // Trouver tous les MeshFilter dans l'arborescence des enfants
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>(true);

        // Combiner les Mesh
        CombineInstance[] combineInstances = new CombineInstance[meshFilters.Length];
        for (int i = 0; i < meshFilters.Length; i++)
        {
            combineInstances[i].mesh = meshFilters[i].sharedMesh;
            combineInstances[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false); // Désactiver l'objet d'origine pour éviter les conflits de colliders
        }

        // Créer un nouveau GameObject pour le Mesh combiné
        GameObject combinedMesh = new GameObject("CombinedMesh");
        combinedMesh.transform.SetParent(transform); // Ajouter le nouveau GameObject au parent actuel
        MeshFilter meshFilter = combinedMesh.AddComponent<MeshFilter>();
        meshFilter.mesh = new Mesh();
        meshFilter.mesh.CombineMeshes(combineInstances);

        // Ajouter un MeshCollider au nouveau GameObject
        MeshCollider meshCollider = combinedMesh.AddComponent<MeshCollider>();
        meshCollider.sharedMesh = meshFilter.mesh;

        // Réactiver tous les MeshFilter
        for (int i = 0; i < meshFilters.Length; i++)
        {
            meshFilters[i].gameObject.SetActive(true);
        }
    }
}
