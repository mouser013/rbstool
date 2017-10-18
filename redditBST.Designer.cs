namespace redditBatchSubmitTool
{
    partial class formBST
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
            this.components = new System.ComponentModel.Container();
            this.textIn = new System.Windows.Forms.TextBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.textOut = new System.Windows.Forms.TextBox();
            this.contextMenuLog = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.loggingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMain = new System.Windows.Forms.Panel();
            this.labelLinkbox = new System.Windows.Forms.Label();
            this.labelSubreddit = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelNameFla = new System.Windows.Forms.Label();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.textSubreddit = new System.Windows.Forms.TextBox();
            this.panelAcc = new System.Windows.Forms.Panel();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.panelAuth = new System.Windows.Forms.Panel();
            this.textBrowser = new System.Windows.Forms.TextBox();
            this.browserAuth = new System.Windows.Forms.WebBrowser();
            this.contextMenuLog.SuspendLayout();
            this.panelMain.SuspendLayout();
            this.panelAcc.SuspendLayout();
            this.panelAuth.SuspendLayout();
            this.SuspendLayout();
            // 
            // textIn
            // 
            this.textIn.Location = new System.Drawing.Point(258, 68);
            this.textIn.Multiline = true;
            this.textIn.Name = "textIn";
            this.textIn.Size = new System.Drawing.Size(523, 303);
            this.textIn.TabIndex = 2;
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Location = new System.Drawing.Point(402, 386);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(271, 62);
            this.buttonSubmit.TabIndex = 3;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // textOut
            // 
            this.textOut.ContextMenuStrip = this.contextMenuLog;
            this.textOut.Location = new System.Drawing.Point(12, 463);
            this.textOut.Multiline = true;
            this.textOut.Name = "textOut";
            this.textOut.ReadOnly = true;
            this.textOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textOut.Size = new System.Drawing.Size(769, 55);
            this.textOut.TabIndex = 4;
            // 
            // contextMenuLog
            // 
            this.contextMenuLog.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loggingToolStripMenuItem});
            this.contextMenuLog.Name = "contextMenuLog";
            this.contextMenuLog.Size = new System.Drawing.Size(153, 48);
            // 
            // loggingToolStripMenuItem
            // 
            this.loggingToolStripMenuItem.CheckOnClick = true;
            this.loggingToolStripMenuItem.Name = "loggingToolStripMenuItem";
            this.loggingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.loggingToolStripMenuItem.Text = "Logging";
            this.loggingToolStripMenuItem.ToolTipText = "Enable logging to file.";
            this.loggingToolStripMenuItem.Click += new System.EventHandler(this.loggingToolStripMenuItem_Click);
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.labelLinkbox);
            this.panelMain.Controls.Add(this.labelSubreddit);
            this.panelMain.Controls.Add(this.labelName);
            this.panelMain.Controls.Add(this.labelNameFla);
            this.panelMain.Controls.Add(this.buttonLogout);
            this.panelMain.Controls.Add(this.textSubreddit);
            this.panelMain.Controls.Add(this.textOut);
            this.panelMain.Controls.Add(this.buttonSubmit);
            this.panelMain.Controls.Add(this.textIn);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(793, 530);
            this.panelMain.TabIndex = 0;
            // 
            // labelLinkbox
            // 
            this.labelLinkbox.AutoSize = true;
            this.labelLinkbox.Location = new System.Drawing.Point(258, 49);
            this.labelLinkbox.Name = "labelLinkbox";
            this.labelLinkbox.Size = new System.Drawing.Size(35, 13);
            this.labelLinkbox.TabIndex = 8;
            this.labelLinkbox.Text = "Links:";
            // 
            // labelSubreddit
            // 
            this.labelSubreddit.AutoSize = true;
            this.labelSubreddit.Location = new System.Drawing.Point(12, 49);
            this.labelSubreddit.Name = "labelSubreddit";
            this.labelSubreddit.Size = new System.Drawing.Size(55, 13);
            this.labelSubreddit.TabIndex = 4;
            this.labelSubreddit.Text = "Subreddit:";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(613, 22);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(16, 13);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "---";
            // 
            // labelNameFla
            // 
            this.labelNameFla.AutoSize = true;
            this.labelNameFla.Location = new System.Drawing.Point(536, 22);
            this.labelNameFla.Name = "labelNameFla";
            this.labelNameFla.Size = new System.Drawing.Size(71, 13);
            this.labelNameFla.TabIndex = 1;
            this.labelNameFla.Text = "Logged in as:";
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(706, 17);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(75, 23);
            this.buttonLogout.TabIndex = 5;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // textSubreddit
            // 
            this.textSubreddit.Location = new System.Drawing.Point(12, 68);
            this.textSubreddit.Name = "textSubreddit";
            this.textSubreddit.Size = new System.Drawing.Size(240, 20);
            this.textSubreddit.TabIndex = 1;
            // 
            // panelAcc
            // 
            this.panelAcc.Controls.Add(this.labelAuthor);
            this.panelAcc.Controls.Add(this.buttonLogin);
            this.panelAcc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAcc.Location = new System.Drawing.Point(0, 0);
            this.panelAcc.Name = "panelAcc";
            this.panelAcc.Size = new System.Drawing.Size(793, 530);
            this.panelAcc.TabIndex = 0;
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Location = new System.Drawing.Point(641, 517);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(152, 13);
            this.labelAuthor.TabIndex = 1;
            this.labelAuthor.Text = "github.com/mouser013     WIP";
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(287, 200);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(218, 80);
            this.buttonLogin.TabIndex = 0;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // panelAuth
            // 
            this.panelAuth.Controls.Add(this.textBrowser);
            this.panelAuth.Controls.Add(this.browserAuth);
            this.panelAuth.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAuth.Location = new System.Drawing.Point(0, 0);
            this.panelAuth.Name = "panelAuth";
            this.panelAuth.Size = new System.Drawing.Size(793, 530);
            this.panelAuth.TabIndex = 2;
            // 
            // textBrowser
            // 
            this.textBrowser.Location = new System.Drawing.Point(3, 500);
            this.textBrowser.Multiline = true;
            this.textBrowser.Name = "textBrowser";
            this.textBrowser.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBrowser.Size = new System.Drawing.Size(787, 20);
            this.textBrowser.TabIndex = 0;
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
            // formBST
            // 
            this.ClientSize = new System.Drawing.Size(793, 530);
            this.Controls.Add(this.panelAcc);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelAuth);
            this.Name = "formBST";
            this.Text = "Reddit Batch Sbmit Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuLog.ResumeLayout(false);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelAcc.ResumeLayout(false);
            this.panelAcc.PerformLayout();
            this.panelAuth.ResumeLayout(false);
            this.panelAuth.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.TextBox textIn;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.TextBox textOut;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelAcc;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Panel panelAuth;
        private System.Windows.Forms.WebBrowser browserAuth;
        private System.Windows.Forms.TextBox textBrowser;
        private System.Windows.Forms.TextBox textSubreddit;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelNameFla;
        private System.Windows.Forms.Label labelLinkbox;
        private System.Windows.Forms.Label labelSubreddit;
        private System.Windows.Forms.ContextMenuStrip contextMenuLog;
        private System.Windows.Forms.ToolStripMenuItem loggingToolStripMenuItem;
        private System.Windows.Forms.Label labelAuthor;
    }
}

