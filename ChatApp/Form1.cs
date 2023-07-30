using System.Diagnostics;
using ChatApp.Networking;

namespace ChatApp;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        NetworkPackage.Instance.OnMessage += OnMessage;
    }

    private async void hostButton_Click(object sender, EventArgs e)
    {
        Text = $"{Text} - HOST";
        Chat.Visible = true;
        Connect.Visible = false;
        await NetworkPackage.Instance.StartHost("127.0.0.1", 4444);
    }

    private async void connectButton_Click(object sender, EventArgs e)
    {
        Text = $"{Text} - AGENT";
        Chat.Visible = true;
        Connect.Visible = false;
        await NetworkPackage.Instance.StartAgent("127.0.0.1", 4444);
    }

    private void sendButton_Click(object sender, EventArgs e)
    {
        if (inputTextBox.Text == String.Empty) return;
        Debug.WriteLine($"sendButton_Click -> content in textBox is now: {inputTextBox.Text}");
        NetworkPackage.Instance.SendMessage(inputTextBox.Text);
    }

    private void OnMessage(string msg)
    {
        if (InvokeRequired)
        {
            this.Invoke(OnMessage, msg);
            return;
        }

        listBox.Items.Add(msg);
    }
}