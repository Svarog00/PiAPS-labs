using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


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
			saveFileDialog.FileName = "New Dialogue";
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
            try
            {
				fasade.AddAnswer(NodeComboBox.SelectedIndex, AnswerText.Text, EndOfDialogue.IsChecked.ToString(), int.Parse(NextNodeTextBox.Text));
				AnswersComboBox.Items.Add($"Answer {AnswerText.Text} Next Node: {NextNodeTextBox.Text} End: {EndOfDialogue.IsChecked}");
				AnswerText.Clear();
				NextNodeTextBox.Clear();
            }
			catch(Exception exc)
            {
				MessageBox.Show(exc.Message);
            }
		}
        private void AnswersComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AnswersComboBox.HasItems)
            {
				AnswerText.Text = fasade.GetAnswerText(NodeComboBox.SelectedIndex, AnswersComboBox.SelectedIndex);
				NextNodeTextBox.Text = fasade.GetAnswerNextNode(NodeComboBox.SelectedIndex, AnswersComboBox.SelectedIndex).ToString();
				EndOfDialogue.IsChecked = fasade.GetAnswerEndFlag(NodeComboBox.SelectedIndex, AnswersComboBox.SelectedIndex);

            }
        }

		private void NodeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if(NodeComboBox.HasItems)
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
		}
		private void DeleteAnswerButton_Click_1(object sender, RoutedEventArgs e)
		{
            try
            {
				AnswerText.Clear();
				fasade.DeleteAnswer(NodeComboBox.SelectedIndex, AnswersComboBox.SelectedIndex);
				AnswersComboBox.Items.RemoveAt(AnswersComboBox.SelectedIndex);
            }
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}

		private void DeleteNodeButton_Click_1(object sender, RoutedEventArgs e)
		{
            try
            {
				NodeNPCText.Clear();
				fasade.DeleteNode(NodeComboBox.SelectedIndex);
				NodeComboBox.Items.RemoveAt(NodeComboBox.SelectedIndex);
            }
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}

		private void ChangeAnswerButton_Click(object sender, RoutedEventArgs e)
		{
            try
            {
				fasade.EditAnswer(NodeComboBox.SelectedIndex, AnswersComboBox.SelectedIndex, AnswerText.Text, EndOfDialogue.IsChecked.ToString(), int.Parse(NextNodeTextBox.Text));
				AnswerText.Clear();
				AnswersComboBox.Items.Clear();
				List<Answer> answers = fasade.GetAnswersList(NodeComboBox.SelectedIndex);
				foreach (Answer ans in answers)
				{
					AnswersComboBox.Items.Add($"Answer {ans.text} Next Node: {ans.nextNode} End: {ans.endDialog}");
				}
            }
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
			}
		}

		private void ChangeNodeButton_Click(object sender, RoutedEventArgs e)
		{
            try
            {
				fasade.EditNode(NodeComboBox.SelectedIndex, NodeNPCText.Text);
				NodeNPCText.Clear();
				NodeComboBox.Items.Clear();
				for (int i = 0; i < fasade.GetNodesList().Count; i++)
				{
					NodeComboBox.Items.Add($"Node {i}: {fasade.GetNodeText(i)}");
				}
            }
			catch (Exception exc)
			{
				MessageBox.Show(exc.Message);
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
