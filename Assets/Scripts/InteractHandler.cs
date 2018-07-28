using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractHandler : MonoBehaviour {

	public Camera m_MainCamera;
	public MessageHandler m_MessageHandler;

	void Update () {
		if(Input.GetMouseButtonDown(1)){
			RaycastHit hit;
			Ray ray = m_MainCamera.ScreenPointToRay(Input.mousePosition);
			
			if (Physics.Raycast(ray, out hit)) {
				Transform ObjectHit = hit.transform;
				Debug.DrawLine(ray.origin, hit.point, Color.blue);
					Message Message = ObjectHit.GetComponent<Message>();
					if(Message != null && m_MessageHandler.m_Target == null)
						m_MessageHandler.ShowMessage(Message.m_TargetObject, Message.m_TargetName, Message.m_Message);
					else if(m_MessageHandler.m_Target != null)
						m_MessageHandler.ResetMessage();
			}
		}
	}
}
