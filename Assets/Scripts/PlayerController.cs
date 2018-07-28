using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

	public NavMeshAgent m_NavAgent;
	public Camera m_MainCamera;
	
	private void Update() {
		if(Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray = m_MainCamera.ScreenPointToRay(Input.mousePosition);
			
			if (Physics.Raycast(ray, out hit)) {
				Transform ObjectHit = hit.transform;

				if(ObjectHit.name.Contains("ground") || ObjectHit.name.Contains("cliff"))
					m_NavAgent.SetDestination(hit.point);
			}
		}
	} 
}
