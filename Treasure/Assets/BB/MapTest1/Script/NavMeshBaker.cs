using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshBaker : MonoBehaviour
{
    public NavMeshSurface surface;

    public void Bake()
    {
        if (surface != null)
        {
            surface.BuildNavMesh();
        }
        else
        {
            Debug.LogError("NavMeshSurface ‚ªŠ„‚è“–‚Ä‚ç‚ê‚Ä‚¢‚Ü‚¹‚ñI");
        }
    }
}
