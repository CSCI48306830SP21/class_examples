using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GoOnClick : MonoBehaviour
{
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent.speed = 4.5f;
    }

    // Update is called once per frame
    void Update()
    {
        agent.GetComponent<Animator>().SetFloat("speed", agent.velocity.magnitude);
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(this.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition), out hit))
            {
                
                agent.SetDestination(hit.point);
                
            }
        }
        
    }
}
