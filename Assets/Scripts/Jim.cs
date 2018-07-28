using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jim : MonoBehaviour {

	private List<string> m_Dialouge = new List<string>();
	public int m_Index;
	public MessageHandler m_MessageHandler;
	public float m_InteractDistance;

	private void Awake() {
		m_Dialouge.Add("Hey my name is Jim");
		m_Dialouge.Add("Really need to get that wood for that fence...");
		m_Dialouge.Add("Some brown mushrooms would be nice for that stew for later...");
	}

	public void JimDialogue(){
		m_MessageHandler.ShowMessage(gameObject.transform, "Jim", m_Dialouge[m_Index]);
		if(m_Index < m_Dialouge.Count)
			m_Index++;
		else
			m_Index = 0;
	}

	public bool HasQuestItem(){
		return true;
	}
}
