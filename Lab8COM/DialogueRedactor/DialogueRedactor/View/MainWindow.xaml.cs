using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DialogueSerializerPrototype;

namespace DialogueRedactor
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Model.Fasade fasade; 

		public MainWindow()
		{
			InitializeComponent();
			fasade = new Model.Fasade();
		}

		private void Button_Click(object sender, RoutedEventArgs e) //Serialize button
		{
			Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
			saveFileDialog.Filter = "XML File (*.xml)|*.xml";
			if(saveFileDialog.ShowDialog() == true)
			{
				fasade.Serialize(saveFileDialog.FileName);
			}
		}

		private void NewNodeButton_Click(object sender, RoutedEventArgs e)
		{
			fasade.AddNode(NodeNPCText.Text);
			NodeComboBox.Items.Add($"Node {fasade.GetNodesNum()-1}: {NodeNPCText.Text}");
			NodeNPCText.Clear();
		}

		private void NewAnswerButton_Click(object sender, RoutedEventArgs e)
		{
			fasade.AddAnswer(NodeComboBox.SelectedIndex, AnswerText.Text, EndOfDialogue.IsChecked.ToString(), Int32.Parse(NextNodeTextBox.Text));
			AnswersComboBox.Items.Add($"Answer {AnswerText.Text} Next Node: {NextNodeTextBox.Text} End: {EndOfDialogue.IsChecked}");
			AnswerText.Clear();
			NextNodeTextBox.Clear();
		}

		private void NodeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			NodeNPCText.Text = fasade.GetNodeText(NodeComboBox.SelectedIndex);
			List<Answer> answers = fasade.GetAnswersList(NodeComboBox.SelectedIndex);
			AnswersComboBox.Items.Clear();
			AnswerText.Clear();
			NextNodeTextBox.Clear();
			foreach (Answer ans in answers)
			{
				AnswersComboBox.Items.Add($"Answer {ans.text} Next Node: {ans.nextNode} End: {ans.endDialog}");
			}    
		}
		private void DeleteAnswerButton_Click_1(object sender, RoutedEventArgs e)
		{
			fasade.DeleteAnswer(NodeComboBox.SelectedIndex, AnswersComboBox.SelectedIndex);
			AnswersComboBox.Items.RemoveAt(AnswersComboBox.SelectedIndex);
		}

		private void DeleteNodeButton_Click_1(object sender, RoutedEventArgs e)
		{
			fasade.DeleteNode(NodeComboBox.SelectedIndex);
			NodeComboBox.Items.RemoveAt(NodeComboBox.SelectedIndex);
		}

		private void ChangeAnswerButton_Click(object sender, RoutedEventArgs e)
		{

		}

		private void ChangeNodeButton_Click(object sender, RoutedEventArgs e)
		{
			NodeNPCText.Clear();
			fasade.EditNode(NodeComboBox.SelectedIndex, NodeNPCText.Text);
			NodeComboBox.Items.Clear();
			for (int i = 0; i < fasade.GetNodesList().Count; i++)
			{
				NodeComboBox.Items.Add($"Node {i}: {fasade.GetNodeText(i)}");
			}
		}

		private void NextNodeTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
		{
			if (!Char.IsDigit(e.Text, 0))
			{
				e.Handled = true;
			}
		}
	}
}
