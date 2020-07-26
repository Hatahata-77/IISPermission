using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.Administration;
using System.Security;
using System.Security.AccessControl;

namespace WindowsFormsApp20
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SitesCombo.Items.Clear();
            using (var serverManager = new ServerManager())
            {
                foreach(var Site in serverManager.Sites) SitesCombo.Items.Add(Site.Name);
            }
        }

        private void SitesCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppsCombo.Items.Clear();
            if (String.IsNullOrWhiteSpace(SitesCombo.SelectedItem.ToString())) return;
            var webSite = SitesCombo.SelectedItem.ToString();
            using (var serverManager = new ServerManager())
            {
                var site = serverManager.Sites.Where(x => x.Name.Equals(webSite)).FirstOrDefault();
                foreach (var app in site.Applications) AppsCombo.Items.Add(app.Path); 
            }

        }

        private void AppsCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AppsCombo.SelectedItem.ToString())) return;
            var siteName = SitesCombo.SelectedItem.ToString();
            var appName = AppsCombo.SelectedItem.ToString();
            using (var serverManager = new ServerManager())
            {
                var app = serverManager.Sites.Where(x => x.Name.Equals(siteName)).FirstOrDefault()
                          .Applications.Where(x => x.Path.Equals(appName)).FirstOrDefault();
                var appPool = serverManager.ApplicationPools.Where(x => x.Name.Equals(app.ApplicationPoolName))
                              .Where(x => x.Name.Equals(app.ApplicationPoolName)).FirstOrDefault();
                string password;
                if (appPool.ProcessModel.IdentityType.Equals(ProcessModelIdentityType.SpecificUser))
                {
                    //カスタムアカウント
                    AppPoolUserText.Text = appPool.ProcessModel.UserName;
                    password = appPool.ProcessModel.Password;
                } else {
                    //ビルドインアカウント
                    AppPoolUserText.Text = appPool.ProcessModel.IdentityType.ToString();
                    password = appPool.ProcessModel.Password;
                }
                var virtialDirectory = app.VirtualDirectories.Where(x => x.Path.Equals("/"));
                var testFileName = $"{typeof(Form1).Assembly.GetName()}_WriteTest.txt";
                var userName = appPool.ProcessModel.UserName;
                var domain = "";
                if (userName.Contains($"\\")) {
                    domain = userName.Split('\\')(0);

                }

            }
        }
    }
}
