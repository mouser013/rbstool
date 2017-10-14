using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using RedditSharp;
using System.Net.Http;
//using CefSharp.WinForms;

namespace redditBatchSubmitTool
{
    public partial class Form1 : Form
    {

        String token, subreddit;
        //Reddit reddit;
        //RedditSharp.Things.AuthenticatedUser user;

        private async void submitUrl(String url, String title)
        {
            var values = new Dictionary<string, string>
            {
                {"title",title},
                {"url",url},
                {"sr",subreddit},
                {"kind","link"},
                {"uh",""}
            };
            IEnumerable<String> val;
            client.DefaultRequestHeaders.TryGetValues("Authorization",out val);
            if(val == null)
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + token);
            client.DefaultRequestHeaders.TryGetValues("User-Agent", out val);
            if (val == null)
                client.DefaultRequestHeaders.Add("User-Agent", "win.redditBST v.01");
            var content = new FormUrlEncodedContent(values);
            var response = client.PostAsync("https://oauth.reddit.com/api/submit", content).Result;
            var responseStr = response.Content.ReadAsStringAsync().Result;
            textOut.AppendText(responseStr + '\n');
        }

        private void parseResponse(String resUrl)
        {
            int start = resUrl.IndexOf('=') + 1, end = resUrl.IndexOf("&");
            token = resUrl.Substring(start, end - start);
        }

        private static readonly HttpClient client = new HttpClient();

        public Form1()
        {
            InitializeComponent();
            this.ActiveControl = panelAcc;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panelMain.Hide();
            panelAuth.Hide();
            panelAcc.Show();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            String[] urls = textIn.Lines;
            String title = "no-title";
            subreddit = textSubreddit.Text;

            for (int i = 0; i < urls.Length; i++)
            {
                String url = urls[i];
                if(url.Contains("gfycat.com"))
                {
                    title = url.Substring(url.LastIndexOf('/') + 1);
                }
                submitUrl(url, title);
                textOut.AppendText(title + " : " + url + '\n'); 
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            bool auth = false;
            //auth code
            //if(auth)
            {
                //user = reddit.LogIn(textUser.Text, textPass.Text);
                //panelMain.Show();
                panelAuth.Show();
                panelAcc.Hide();
            }
            browserAuth.Navigate("https://www.reddit.com/api/v1/authorize?client_id=8DzA0_bx9X8hCA&response_type=token&state=akrnarvhburvbuyrirvb&redirect_uri=https://mouser013.github.io&scope=identity submit");
        }

        private void browserAuth_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            //HtmlDocument doc = browserAuth.Document;
            //String res = e.Url.Fragment;
            //if(e.Url.Host == "127.0.0.1")
            {
                //panelAuth.Hide();
                //panelMain.Show();
                //textBrowser.AppendText(res+"\n");
                //textOut.AppendText(res);
            }
        }

        private void browserAuth_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlDocument doc = browserAuth.Document;
            //String res = doc.Url.AbsoluteUri;
            String res = doc.Url.Fragment;
            if(e.Url.Host == "mouser013.github.io")
            {
                parseResponse(res);
                panelAuth.Hide();
                panelMain.Show();
                //textBrowser.AppendText(res + "\n");
                //textOut.AppendText(res);
                //textOut.AppendText(token);
            }
        }
    }
}
