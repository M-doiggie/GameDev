using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class GoBetweenTwoPoints : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private Animator animator;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        
    }

    void GoToNextPoint()
    {
        if (points.Length == 0)
        {
            return;
        }
        agent.destination = points[destPoint].position;

        destPoint = (destPoint + 1) % points.Length;
    }

    private void Start()
    {
        GoToNextPoint();
        StartCoroutine(WaitForOneSecond());    
    }
    private void Update()
    {
        animator.SetFloat("walkingSpeed", agent.desiredVelocity.magnitude);
    }

    private IEnumerator WaitForOneSecond(){
        while (true)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f){
                agent.isStopped = true;
                yield return new WaitForSecondsRealtime(1f);
                GoToNextPoint();
                agent.isStopped = false;
            }
            else
            {
                yield return null;
            }
        }

    }
}
