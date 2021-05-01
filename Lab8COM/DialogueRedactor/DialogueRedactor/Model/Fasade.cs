using DialogueSerializerPrototype;
using System.Collections.Generic;

namespace DialogueRedactor.Model
{
    class Fasade
    {
        Dialogue dialogue;

        public Fasade()
        {
            dialogue = new Dialogue();
        }

        public void AddNode(string text)
        {
            dialogue.nodes.Add(new Node(text));
        }

        public int GetNodesNum()
        {
            return dialogue.nodes.Count;
        }

        public string GetNodeText(int nodeNum)
        {
            return dialogue.nodes[nodeNum].npcText;
        }

        public void EditNode(int num, string newText)
        {
            dialogue.nodes[num].npcText = newText;
        }

        public void DeleteNode(int num)
        {
            dialogue.nodes.RemoveAt(num);
        }

        public void AddAnswer(int nodeNum, string text, string endDialogue, int nextNode)
        {
            dialogue.nodes[nodeNum].answers.Add(new Answer(text, nextNode, endDialogue));
        }

        public void EditAnswer(int nodeNum, int ansNum, string text, string endDialogue, int nextNode)
        {
            
        }

        public void DeleteAnswer(int nodeNum, int num)
        {
            dialogue.nodes[nodeNum].answers.RemoveAt(num);
        }

        public List<Answer> GetAnswersList(int nodeNum)
        {
            return dialogue.nodes[nodeNum].answers;
        }

        public List<Node> GetNodesList()
        {
            return dialogue.nodes;
        }

        public void Serialize(string path)
        {
            ISerializator serializator = new XmlSerializerImp();

            serializator.Serialize(dialogue, path);
        }
    }
}
