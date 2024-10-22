using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform[] checkpoints; 
    public Transform door; 
    private NavMeshAgent agent; 
    private int currentTargetIndex = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        MoveToNextCheckpoint();
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            if (currentTargetIndex < checkpoints.Length)
            {
                ChangeCubeColor(checkpoints[currentTargetIndex].gameObject);
                currentTargetIndex++;
                MoveToNextCheckpoint();
            }
            else
            {
                MoveToDoor();
            }
        }
    }

    void MoveToNextCheckpoint()
    {
        if (currentTargetIndex < checkpoints.Length)
        {
            agent.SetDestination(checkpoints[currentTargetIndex].position);
        }
    }

    void MoveToDoor()
    {
        agent.SetDestination(door.position);
    }

    void ChangeCubeColor(GameObject cube)
    {
        Renderer renderer = cube.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material.color = Color.red; 
        }
    }
}
