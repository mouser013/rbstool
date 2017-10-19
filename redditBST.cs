
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
    public partial class formBST : Form
    {
        int rateLeft, rateReset;
        String subreddit;
        Properties.Settings settings;

        private void writeLineToLog(String text)
        {
            textOut.AppendText(text + '\n');
            if(settings.loggingEnabled)
            {
                using (StreamWriter writer = new StreamWriter("log.txt", append: true))
                {
                    writer.WriteLine(text + '\n');
                }
            }
        }

        private String getTitle(String url)
        {
            var response = client.GetAsync(url).Result;
            var responseStr = response.Content.ReadAsStringAsync().Result;
            String title = System.Text.RegularExpressions.Regex.Match(responseStr, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", System.Text.RegularExpressions.RegexOptions.IgnoreCase).Groups["Title"].Value;
            if (title == "")
                title = "no-title";
            return title;
        }

        private bool getUsername()
        {
            client.DefaultRequestHeaders.Add("Authorization", "bearer " + settings.accessToken);
            client.DefaultRequestHeaders.Add("User-Agent", "win.redditBST v.01");
            var response = client.GetAsync("https://oauth.reddit.com/api/v1/me").Result;
            var responseStr = response.Content.ReadAsStringAsync().Result;
            client.DefaultRequestHeaders.Remove("Authorization");
            client.DefaultRequestHeaders.Remove("User-Agent");

            if (!response.IsSuccessStatusCode)
                return false;
            idresponse resp = JsonConvert.DeserializeObject<idresponse>(responseStr);
            Properties.Settings.Default.user = resp.name;
            Properties.Settings.Default.Save();
            return true;
        }
        
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
            response.Headers.TryGetValues("x-ratelimit-remaining", out val);
            String s = string.Join("", val.Take(2));
            rateLeft = (int)Convert.ToDouble(s);
            response.Headers.TryGetValues("x-ratelimit-reset", out val);
            s = string.Join("", val.Take(2));
            rateReset = Convert.ToInt32(s);

            //writeLineToLog(responseStr);
            return response.IsSuccessStatusCode;
        }

        private void parseCode(String resUrl)
        {
            int start = resUrl.LastIndexOf('=') + 1, end = resUrl.Length;
            settings.authCode = resUrl.Substring(start, end - start);
            Properties.Settings.Default.authCode = settings.authCode;
        }

        private static readonly HttpClient client = new HttpClient();

        public formBST()
        {
            InitializeComponent();
            this.ActiveControl = panelAcc;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            settings = Properties.Settings.Default;

            if (settings.loggingEnabled)
                loggingToolStripMenuItem.Checked = true;
            else
                loggingToolStripMenuItem.Checked = false;

            panelLoad.Hide();
            panelAuth.Hide();

            if(checkAndRefreshToken())
            {
                labelName.Text = settings.user;
                panelMain.Show();
                panelAcc.Hide();
                
            }
            else
            {
                panelMain.Hide();
                panelAcc.Show();
            }
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            buttonLogout.Enabled = false;
            buttonSubmit.Enabled = false;

            String[] urls = textIn.Lines;
            String title = "no-title";
            subreddit = textSubreddit.Text;
            int nSub = 0, nFail = 0;

            for (int i = 0; i < urls.Length; i++)
            {
                String url = urls[i];

                if(url.Contains("gfycat.com"))
                    title = url.Substring(url.LastIndexOf('/') + 1);
                else
                    title = getTitle(url);

                if (submitUrl(url, title))
                {
                    writeLineToLog("Submitted: " + title + " - " + url);
                    nSub++;
                }
                else
                {
                    writeLineToLog("Failed: " + title + " - " + url);
                    nFail++;
                }

                if (rateLeft < 10)
                {
                    int t = rateReset, t2;
                    while(t >= 0)
                    {
                        if (t < 5)
                            t2 = t;
                        else
                            t2 = 5;
                        writeLineToLog(String.Format("Ratelimit reached. Please wait {0} seconds.", t));
                        textOut.Update();
                        System.Threading.Thread.Sleep(t2 * 1000);
                        t -= 5;
                    }
                    
                }
            }

            writeLineToLog(String.Format("Processed {0} urls - {1} submitted, {2} failed.\n", nSub + nFail, nSub, nFail));

            buttonSubmit.Enabled = true;
            buttonLogout.Enabled = true;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            panelAuth.Show();
            panelAcc.Hide();
            browserAuth.Navigate("https://www.reddit.com/api/v1/authorize?client_id=8DzA0_bx9X8hCA&response_type=code&state=akrnarvhburvbuyrirvb&redirect_uri=https://mouser013.github.io&duration=permanent&scope=identity submit");
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show(null, "Are you sure you want to log out?", "Confirm", MessageBoxButtons.YesNo);
            if(confirm == DialogResult.Yes)
            {
                settings.accessToken = "";
                settings.refreshToken = "";
                settings.authCode = "";
                settings.user = "---";
                settings.Save();
                panelMain.Hide();
                panelAcc.Show();
            }
        }

        private void browserAuth_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
        }

        private void browserAuth_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlDocument doc = browserAuth.Document;
            if(e.Url.Host == "mouser013.github.io")
            {
                panelLoad.Show();
                panelAuth.Hide();
                progressBarLoad.Value = 10;
                String res = doc.Url.Query;
                parseCode(res);
                progressBarLoad.Value = 20;
                retrieveToken();
                progressBarLoad.Value = 90;
                getUsername();
                progressBarLoad.Value = 100;
                labelName.Text = settings.user;
                panelMain.Show();
                panelLoad.Hide();
            }
        }

        private void loggingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loggingToolStripMenuItem.Checked)
            {
                settings.loggingEnabled = true;
                writeLineToLog("Logging enabled.");
            }
            else
            {
                settings.loggingEnabled = false;
                writeLineToLog("Logging disabled.");
            }
            settings.Save();
        }

        private void textBrowser_TextChanged(object sender, EventArgs e)
        {

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

    public class idresponse
    {
        public String name;
    }
}
