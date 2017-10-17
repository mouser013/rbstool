﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using Newtonsoft.Json;

namespace redditBatchSubmitTool
{
    public partial class Form1 : Form
    {

        String subreddit;
        Properties.Settings settings;
        
        private bool retrieveToken()
        {
            if (settings.authCode == null)
                return false;

            
            var values = new Dictionary<string, string>{
                {"grant_type","authorization_code"},
                {"code",settings.authCode},
                {"redirect_uri","https://mouser013.github.io"},
            };
            string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes("8DzA0_bx9X8hCA:"));
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + svcCredentials);
            var content = new FormUrlEncodedContent(values);
            var response = client.PostAsync("https://www.reddit.com/api/v1/access_token", content).Result;
            var responseStr = response.Content.ReadAsStringAsync().Result;
            client.DefaultRequestHeaders.Remove("Authorization");
            if (!response.IsSuccessStatusCode)
                return false;
            tokenresponse resp = JsonConvert.DeserializeObject<tokenresponse>(responseStr);
            Properties.Settings.Default.accessToken = resp.access_token;
            Properties.Settings.Default.refreshToken = resp.refresh_token;
            Properties.Settings.Default.tokenIssueTime = DateTime.Now;
            Properties.Settings.Default.Save();
            return true;
        }

        private bool refreshToken()
        {
            var values = new Dictionary<string, string>{
                {"grant_type","refresh_token"},
                {"refresh_token",Properties.Settings.Default.refreshToken},
            };
            string svcCredentials = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes("8DzA0_bx9X8hCA:"));
            client.DefaultRequestHeaders.Add("Authorization", "Basic " + svcCredentials);
            var content = new FormUrlEncodedContent(values);
            var response = client.PostAsync("https://www.reddit.com/api/v1/access_token", content).Result;
            var responseStr = response.Content.ReadAsStringAsync().Result;
            client.DefaultRequestHeaders.Remove("Authorization");
            if (!response.IsSuccessStatusCode)
                return false;
            tokenresponse resp = JsonConvert.DeserializeObject<tokenresponse>(responseStr);
            Properties.Settings.Default.accessToken = resp.access_token;
            Properties.Settings.Default.tokenIssueTime = DateTime.Now;
            Properties.Settings.Default.Save();
            return true;
        }

        private bool checkAndRefreshToken()
        {
            if (Properties.Settings.Default.accessToken == "")
                return false;
            else
            {
                DateTime issue = Properties.Settings.Default.tokenIssueTime;
                if (DateTime.Now > issue.AddHours(1))
                    refreshToken();
                return true;
            }
        }

        private bool submitUrl(String url, String title)
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
                client.DefaultRequestHeaders.Add("Authorization", "bearer " + settings.accessToken);
            client.DefaultRequestHeaders.TryGetValues("User-Agent", out val);
            if (val == null)
                client.DefaultRequestHeaders.Add("User-Agent", "win.redditBST v.01");
            var content = new FormUrlEncodedContent(values);
            var response = client.PostAsync("https://oauth.reddit.com/api/submit", content).Result;
            var responseStr = response.Content.ReadAsStringAsync().Result;
            //textOut.AppendText(responseStr + '\n');
            return response.IsSuccessStatusCode;
        }

        private void parseCode(String resUrl)
        {
            int start = resUrl.LastIndexOf('=') + 1, end = resUrl.Length;
            settings.authCode = resUrl.Substring(start, end - start);
            Properties.Settings.Default.authCode = settings.authCode;
        }

        private static readonly HttpClient client = new HttpClient();

        public Form1()
        {
            InitializeComponent();
            this.ActiveControl = panelAcc;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            settings = Properties.Settings.Default;
            if(checkAndRefreshToken())
            {
                panelMain.Show();
                panelAuth.Hide();
                panelAcc.Hide();
            }
            else
            {
                panelMain.Hide();
                panelAuth.Hide();
                panelAcc.Show();
            }
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
                if(submitUrl(url, title))
                    textOut.AppendText("Submitted: "+title + " - " + url + '\n'); 
                else
                    textOut.AppendText("Failed: " + title + " - " + url + '\n'); 
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            panelAuth.Show();
            panelAcc.Hide();
            browserAuth.Navigate("https://www.reddit.com/api/v1/authorize?client_id=8DzA0_bx9X8hCA&response_type=code&state=akrnarvhburvbuyrirvb&redirect_uri=https://mouser013.github.io&duration=permanent&scope=identity submit");
        }

        private void browserAuth_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
        }

        private void browserAuth_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlDocument doc = browserAuth.Document;
            if(e.Url.Host == "mouser013.github.io")
            {
                String res = doc.Url.Query;
                parseCode(res);
                retrieveToken();
                panelAuth.Hide();
                panelMain.Show();
                //textBrowser.AppendText(res + "\n");
                //textOut.AppendText(res);
                //textOut.AppendText(settings.authCode);
            }
        }
    }

    public class tokenresponse
    {
        public String access_token;
        public String token_type;
        public String expires_in;
        public String scope;
        public String refresh_token;
    };
}
