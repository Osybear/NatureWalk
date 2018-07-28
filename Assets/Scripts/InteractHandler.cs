using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractHandler : MonoBehaviour {

	public Camera m_MainCamera;
	public MessageHandler m_MessageHandler;
	public QuestHandler m_QuestHandler;

	void Update () {
		if(Input.GetMouseButtonDown(1)){
			RaycastHit hit;
			Ray ray = m_MainCamera.ScreenPointToRay(Input.mousePosition);
			
			if (Physics.Raycast(ray, out hit)) {
				Transform ObjectHit = hit.transform;
				Debug.DrawLine(ray.origin, hit.point, Color.blue);

				QuestItem QuestItem = ObjectHit.GetComponent<QuestItem>();
				Message Message = ObjectHit.GetComponent<Message>();
				if(QuestItem != null && Vector3.Distance(transform.position, QuestItem.transform.position) < QuestItem.m_InteractDistance)
				{
					m_QuestHandler.SetQuestItem(QuestItem.m_ItemName, QuestItem.m_ItemImage);
					QuestItem.gameObject.SetActive(false);
					m_MessageHandler.ShowMessage(transform, "Player", "You picked up " + QuestItem.m_ItemName);
				}	
				else if(Message != null && m_MessageHandler.m_Target == null)
					m_MessageHandler.ShowMessage(Message.m_TargetObject, Message.m_TargetName, Message.m_Message);
				else if(m_MessageHandler.m_Target != null)
					m_MessageHandler.ResetMessage();

				Jim Jim = ObjectHit.GetComponent<Jim>();
				if(Jim.HasQuestItem())
					//continue here
				else if(Jim && Vector3.Distance(transform.position, Jim.transform.position) < Jim.m_InteractDistance)
					Jim.JimDialogue();
			}
		}
	}
}
