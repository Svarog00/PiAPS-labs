using System.Xml.Serialization;
using System.Collections.Generic;

namespace DialogueRedactor
{
	[XmlRoot("dialogue")]
	[System.Serializable]
	public class Dialogue
	{
		[XmlElement("node")]
		public List<Node> nodes;

		public Dialogue()
        {
			nodes = new List<Node>();
        }
	}

	[System.Serializable]
	public class Node
	{
		[XmlElement("npctext")]
		public string npcText;

		[XmlArray("answers")]//Массив ответов в XML файле
		[XmlArrayItem("answer")]
		public List<Answer> answers;

		public Node() 
		{
			answers = new List<Answer>();
		}

		public Node(string text)
        {
			npcText = text;
			answers = new List<Answer>();
		}
	}

	[System.Serializable]
	public class Answer
	{
		[XmlElement("text")]
		public string text; //сам текст диалога
		[XmlAttribute("tonode")]
		public int nextNode; //переход к какому-то другому узлу диалогов

		[XmlElement("dialend")]
		public string endDialog; //конец диалога или нет
		[XmlAttribute("questvalue")]
		public int questValue; //значение на каком этапе находится квест
		[XmlAttribute("neededquestvalue")]
		public int neededQuestValue; //нужный этап квеста для появления строчки диалога
		[XmlElement("questname")]
		public string questName; //название квеста

		public Answer() { }

		public Answer(string text, int nextNode, string endDialogue)
        {
			this.text = text;
			this.nextNode = nextNode;
			this.endDialog = endDialogue;
			this.questValue = -1;
			this.neededQuestValue = -1;
			this.questName = null;
        }
	}
}
