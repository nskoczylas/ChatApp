namespace ChatApp;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        listBox = new ListBox();
        sendButton = new Button();
        inputTextBox = new TextBox();
        ipTextBox = new TextBox();
        portTextBox = new TextBox();
        hostButton = new Button();
        connectButton = new Button();
        Chat = new Panel();
        Connect = new Panel();
        Chat.SuspendLayout();
        Connect.SuspendLayout();
        SuspendLayout();
        // 
        // listBox
        // 
        listBox.BackColor = Color.FromArgb(15, 15, 25);
        listBox.BorderStyle = BorderStyle.FixedSingle;
        listBox.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        listBox.ForeColor = SystemColors.Control;
        listBox.FormattingEnabled = true;
        listBox.ItemHeight = 16;
        listBox.Location = new Point(0, 0);
        listBox.Name = "listBox";
        listBox.Size = new Size(776, 402);
        listBox.TabIndex = 0;
        // 
        // sendButton
        // 
        sendButton.Location = new Point(701, 403);
        sendButton.Name = "sendButton";
        sendButton.Size = new Size(75, 23);
        sendButton.TabIndex = 1;
        sendButton.Text = "SEND";
        sendButton.UseVisualStyleBackColor = true;
        sendButton.Click += sendButton_Click;
        // 
        // inputTextBox
        // 
        inputTextBox.BackColor = Color.FromArgb(15, 15, 25);
        inputTextBox.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        inputTextBox.ForeColor = SystemColors.Control;
        inputTextBox.Location = new Point(0, 403);
        inputTextBox.Name = "inputTextBox";
        inputTextBox.Size = new Size(695, 23);
        inputTextBox.TabIndex = 2;
        // 
        // ipTextBox
        // 
        ipTextBox.Anchor = AnchorStyles.None;
        ipTextBox.BackColor = Color.FromArgb(15, 15, 25);
        ipTextBox.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        ipTextBox.ForeColor = SystemColors.Control;
        ipTextBox.Location = new Point(270, 202);
        ipTextBox.Name = "ipTextBox";
        ipTextBox.Size = new Size(161, 23);
        ipTextBox.TabIndex = 3;
        ipTextBox.Text = "127.0.0.1";
        // 
        // portTextBox
        // 
        portTextBox.BackColor = Color.FromArgb(15, 15, 25);
        portTextBox.Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
        portTextBox.ForeColor = SystemColors.Control;
        portTextBox.Location = new Point(437, 202);
        portTextBox.Name = "portTextBox";
        portTextBox.Size = new Size(69, 23);
        portTextBox.TabIndex = 4;
        portTextBox.Text = "4444";
        // 
        // hostButton
        // 
        hostButton.Location = new Point(270, 231);
        hostButton.Name = "hostButton";
        hostButton.Size = new Size(75, 23);
        hostButton.TabIndex = 5;
        hostButton.Text = "HOST";
        hostButton.UseVisualStyleBackColor = true;
        hostButton.Click += hostButton_Click;
        // 
        // connectButton
        // 
        connectButton.Location = new Point(351, 231);
        connectButton.Name = "connectButton";
        connectButton.Size = new Size(75, 23);
        connectButton.TabIndex = 6;
        connectButton.Text = "CONNECT";
        connectButton.UseVisualStyleBackColor = true;
        connectButton.Click += connectButton_Click;
        // 
        // Chat
        // 
        Chat.Controls.Add(listBox);
        Chat.Controls.Add(inputTextBox);
        Chat.Controls.Add(sendButton);
        Chat.Location = new Point(12, 12);
        Chat.Name = "Chat";
        Chat.Size = new Size(776, 426);
        Chat.TabIndex = 7;
        Chat.Visible = false;
        // 
        // Connect
        // 
        Connect.Controls.Add(hostButton);
        Connect.Controls.Add(portTextBox);
        Connect.Controls.Add(ipTextBox);
        Connect.Controls.Add(connectButton);
        Connect.Location = new Point(12, 12);
        Connect.Name = "Connect";
        Connect.Size = new Size(776, 426);
        Connect.TabIndex = 3;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(15, 15, 25);
        ClientSize = new Size(800, 450);
        Controls.Add(Connect);
        Controls.Add(Chat);
        MaximizeBox = false;
        MdiChildrenMinimizedAnchorBottom = false;
        MinimizeBox = false;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "ChatAPP";
        Chat.ResumeLayout(false);
        Chat.PerformLayout();
        Connect.ResumeLayout(false);
        Connect.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private ListBox listBox;
    private Button sendButton;
    private TextBox inputTextBox;
    private TextBox ipTextBox;
    private TextBox portTextBox;
    private Button hostButton;
    private Button connectButton;
    private Panel Chat;
    private Panel Connect;
}