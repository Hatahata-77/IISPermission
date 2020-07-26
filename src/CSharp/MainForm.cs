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
using System.IO;
using System.Windows.Forms.VisualStyles;

namespace WindowsFormsApp20
{
    public partial class MainForm : Form
    {
        public MainForm()
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
                var virtialDirectory = app.VirtualDirectories.Where(x => x.Path.Equals("/")).FirstOrDefault().PhysicalPath;
                var testFileName = $"{typeof(MainForm).Assembly.GetName()}_WriteTest.txt";
                var userName = appPool.ProcessModel.UserName;
                var domain = "";
                if (userName.Contains("\\")) {
                    domain = userName.Split("\\".ToCharArray())[0];
                    userName = userName.Split("\\".ToCharArray())[1];
                }
                var passwordSecureString = new System.Security.SecureString();
                foreach (var c in password)
                {
                    passwordSecureString.AppendChar(c);
                }
                try
                {
                    using (var process = new System.Diagnostics.Process())
                    {
                        process.StartInfo.FileName = "cmd.exe";
                        process.StartInfo.WorkingDirectory = virtialDirectory;
                        process.StartInfo.Arguments = $"/c echo a>{testFileName}";
                        process.StartInfo.UserName = userName;
                        process.StartInfo.Password = passwordSecureString;
                        process.StartInfo.Domain = domain;
                        process.StartInfo.UseShellExecute = false;
                        process.StartInfo.CreateNoWindow = true;
                        process.Start();
                        process.WaitForExit();
                        if (process.ExitCode == 0)
                        {
                            try
                            {
                                process.StartInfo.Arguments = $"/c del {testFileName}";
                                process.Start();
                                process.WaitForExit();
                                if (!File.Exists(Path.Combine(virtialDirectory, testFileName)))
                                {
                                    MessageBox.Show("OK");
                                }
                                else
                                {
                                    MessageBox.Show("実行ユーザーでフォルダーに書き込みはできましたが削除はできませんでした。");
                                    try
                                    {
                                        File.Delete(Path.Combine(virtialDirectory, testFileName));
                                    }
                                    catch(Exception ex)
                                    {
                                        //ここでのエラーは無視します。
                                    }
                                }
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }

                        } else {
                            MessageBox.Show("実行ユーザーではフォルダへ書き込みできませんでした。");
                        }
                    }   
                }catch(Exception ex)
                {
                    MessageBox.Show("実行ユーザーではフォルダへ書き込みできませんでした。\n\n" + ex.Message);
                }
            }
        }
    }
}
