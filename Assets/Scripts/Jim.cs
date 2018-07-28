using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jim : MonoBehaviour {

	private List<string> m_Dialouge = new List<string>();
	public int m_Index;
	public MessageHandler m_MessageHandler;
	public QuestHandler m_QuestHandler;
	public float m_InteractDistance;

	private void Awake() {
		m_Dialouge.Add("Hey my name is Jim");
		m_Dialouge.Add("Really need to get that wood for that fence...");
		m_Dialouge.Add("Some brown mushrooms would be nice for that stew for later...");
	}

	public void JimDialogue(){
		m_MessageHandler.ShowMessage(transform, "Jim", m_Dialouge[m_Index]);
		if(m_Index < m_Dialouge.Count)
			m_Index++;
		else
			m_Index = 0;
	}

	public bool HasQuestItem(){
		if(m_QuestHandler.m_QuestItem == "Brown Mushrooms")
		{
			m_MessageHandler.ShowMessage(transform, "Jim", "Thanks for bringing me these brown mushrooms!");
			m_QuestHandler.ResetQuestItem();
			return true;
		}else if(m_QuestHandler.m_QuestItem == "Canoe Paddle"){
			m_MessageHandler.ShowMessage(transform, "Jim", "It was on top of the tree?!?! Thanks for getting it for me.");
			m_QuestHandler.ResetQuestItem();
			return true;
		}
		return false;
	}
}
