using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToClick : MonoBehaviour
{

   UnityEngine.AI.NavMeshAgent agent;

   public Vector3 destinationPoint;

   public bool moving;
   
    void Start()
    {
        agent= GetComponent<UnityEngine.AI.NavMeshAgent>();     
    }

    void Update()
    {
        
        if(Input.GetMouseButtonDown(0)){
 
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit) && hit.collider.tag=="Walkable")
            {
            
                destinationPoint=hit.point;
                
                agent.speed=20;

                agent.SetDestination(destinationPoint);

                moving=true;

            }

        }

        if(Vector3.Distance(transform.position- new Vector3(0,transform.position.y,0),destinationPoint)<=0.5f){
          
            moving=false;

        }

    }

}
