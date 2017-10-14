namespace redditBatchSubmitTool
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textIn = new System.Windows.Forms.TextBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.textOut = new System.Windows.Forms.TextBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelAcc = new System.Windows.Forms.Panel();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.textPass = new System.Windows.Forms.TextBox();
            this.textUser = new System.Windows.Forms.TextBox();
            this.panelAuth = new System.Windows.Forms.Panel();
            this.browserAuth = new System.Windows.Forms.WebBrowser();
            this.textBrowser = new System.Windows.Forms.TextBox();
            this.textSubreddit = new System.Windows.Forms.TextBox();
            this.panelMain.SuspendLayout();
            this.panelAcc.SuspendLayout();
            this.panelAuth.SuspendLayout();
            this.SuspendLayout();
            // 
            // textIn
            // 
            this.textIn.Location = new System.Drawing.Point(258, 12);
            this.textIn.Multiline = true;
            this.textIn.Name = "textIn";
            this.textIn.Size = new System.Drawing.Size(523, 303);
            this.textIn.TabIndex = 0;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(409, 340);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(271, 62);
            this.buttonSubmit.TabIndex = 2;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // textOut
            // 
            this.textOut.Location = new System.Drawing.Point(12, 463);
            this.textOut.Multiline = true;
            this.textOut.Name = "textOut";
            this.textOut.ReadOnly = true;
            this.textOut.Size = new System.Drawing.Size(769, 55);
            this.textOut.TabIndex = 1;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.textSubreddit);
            this.panelMain.Controls.Add(this.textOut);
            this.panelMain.Controls.Add(this.buttonSubmit);
            this.panelMain.Controls.Add(this.textIn);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(793, 530);
            this.panelMain.TabIndex = 3;
            // 
            // panelAcc
            // 
            this.panelAcc.Controls.Add(this.buttonLogin);
            this.panelAcc.Controls.Add(this.textPass);
            this.panelAcc.Controls.Add(this.textUser);
            this.panelAcc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAcc.Location = new System.Drawing.Point(0, 0);
            this.panelAcc.Name = "panelAcc";
            this.panelAcc.Size = new System.Drawing.Size(793, 530);
            this.panelAcc.TabIndex = 4;
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(334, 189);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(75, 23);
            this.buttonLogin.TabIndex = 2;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // textPass
            // 
            this.textPass.Location = new System.Drawing.Point(324, 143);
            this.textPass.Name = "textPass";
            this.textPass.Size = new System.Drawing.Size(100, 20);
            this.textPass.TabIndex = 1;
            // 
            // textUser
            // 
            this.textUser.Location = new System.Drawing.Point(324, 95);
            this.textUser.Name = "textUser";
            this.textUser.Size = new System.Drawing.Size(100, 20);
            this.textUser.TabIndex = 0;
            // 
            // panelAuth
            // 
            this.panelAuth.Controls.Add(this.textBrowser);
            this.panelAuth.Controls.Add(this.browserAuth);
            this.panelAuth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAuth.Location = new System.Drawing.Point(0, 0);
            this.panelAuth.Name = "panelAuth";
            this.panelAuth.Size = new System.Drawing.Size(793, 530);
            this.panelAuth.TabIndex = 5;
            // 
            // browserAuth
            // 
            this.browserAuth.Location = new System.Drawing.Point(0, 0);
            this.browserAuth.MinimumSize = new System.Drawing.Size(20, 20);
            this.browserAuth.Name = "browserAuth";
            this.browserAuth.ScriptErrorsSuppressed = true;
            this.browserAuth.Size = new System.Drawing.Size(793, 493);
            this.browserAuth.TabIndex = 0;
            this.browserAuth.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.browserAuth_DocumentCompleted);
            this.browserAuth.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.browserAuth_Navigating);
            // 
            // textBrowser
            // 
            this.textBrowser.Location = new System.Drawing.Point(3, 500);
            this.textBrowser.Multiline = true;
            this.textBrowser.Name = "textBrowser";
            this.textBrowser.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBrowser.Size = new System.Drawing.Size(787, 20);
            this.textBrowser.TabIndex = 1;
            // 
            // textSubreddit
            // 
            this.textSubreddit.Location = new System.Drawing.Point(12, 28);
            this.textSubreddit.Name = "textSubreddit";
            this.textSubreddit.Size = new System.Drawing.Size(240, 20);
            this.textSubreddit.TabIndex = 3;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(793, 530);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelAuth);
            this.Controls.Add(this.panelAcc);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelAcc.ResumeLayout(false);
            this.panelAcc.PerformLayout();
            this.panelAuth.ResumeLayout(false);
            this.panelAuth.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textIn;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.TextBox textOut;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelAcc;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.TextBox textPass;
        private System.Windows.Forms.TextBox textUser;
        private System.Windows.Forms.Panel panelAuth;
        private System.Windows.Forms.WebBrowser browserAuth;
        private System.Windows.Forms.TextBox textBrowser;
        private System.Windows.Forms.TextBox textSubreddit;
    }
}

