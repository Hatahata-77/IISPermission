Imports Microsoft.Web.Administration
Imports System.IO
Imports System.Security
Imports System.Security.AccessControl

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SitesCombo.Items.Clear()

        'Webサイトの一覧を表示します。（Default Web Site固定でもいいかも）
        Using serverManager As New ServerManager()
            For Each Site As Site In serverManager.Sites
                SitesCombo.Items.Add(Site.Name)
            Next
        End Using
    End Sub


    Private Sub SitesCombo_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles SitesCombo.SelectedIndexChanged
        AppsCombo.Items.Clear()
        If String.IsNullOrWhiteSpace(SitesCombo.SelectedItem.ToString()) Then
            Return
        End If
        'アプリケーションの一覧を表示します。
        Dim webSite As String = SitesCombo.SelectedItem.ToString()
        Using serverManager As New ServerManager()
            Dim site As Site = serverManager.Sites.Where(Function(x) x.Name.Equals(webSite)).FirstOrDefault()
            For Each app As Application In site.Applications
                AppsCombo.Items.Add(app.Path)
            Next
        End Using
    End Sub

    Private Sub AppsCombo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AppsCombo.SelectedIndexChanged
        If String.IsNullOrWhiteSpace(AppsCombo.SelectedItem.ToString()) Then
            Return
        End If
        Dim siteName As String = SitesCombo.SelectedItem.ToString()
        Dim appName As String = AppsCombo.SelectedItem.ToString()
        Using serverManager As New ServerManager()
            'アプリケーションプール名を取得します。
            Dim app As Application = serverManager.Sites.Where(Function(x) x.Name.Equals(siteName)).FirstOrDefault().Applications.Where(Function(x) x.Path.Equals(appName)).FirstOrDefault()
            AppPoolText.Text = app.ApplicationPoolName
            'アプリケーションプールの実行ユーザーを取得します。
            Dim appPool As ApplicationPool = serverManager.ApplicationPools.Where(Function(x) x.Name.Equals(app.ApplicationPoolName)).FirstOrDefault()
            Dim password As String
            If appPool.ProcessModel.IdentityType.Equals(ProcessModelIdentityType.SpecificUser) Then
                'カスタムアカウント
                AppPoolUserText.Text = appPool.ProcessModel.UserName
                password = appPool.ProcessModel.Password
            Else
                'ビルドインアカウント
                AppPoolUserText.Text = appPool.ProcessModel.IdentityType.ToString()
                password = appPool.ProcessModel.Password
            End If
            '物理パスを取得します。
            Dim virtialDirectory As String = app.VirtualDirectories.Where(Function(x) x.Path.Equals("/")).FirstOrDefault().PhysicalPath

            Dim testFileName = $"{My.Application.Info.AssemblyName}_WriteTest.txt"
            Dim userName As String = appPool.ProcessModel.UserName
            Dim domain As String = ""
            If userName.Contains("\") Then
                domain = userName.Split("\")(0)
                userName = userName.Split("\")(1)
            End If
            Dim passwordSecureString As New System.Security.SecureString()
            For Each c As Char In password
                passwordSecureString.AppendChar(c)
            Next
            Try
                Using process As New System.Diagnostics.Process
                    process.StartInfo.FileName = "cmd.exe"
                    process.StartInfo.WorkingDirectory = virtialDirectory
                    process.StartInfo.Arguments = $"/c echo a>{testFileName}"
                    process.StartInfo.UserName = userName
                    process.StartInfo.Password = passwordSecureString
                    process.StartInfo.Domain = domain
                    process.StartInfo.UseShellExecute = False
                    process.StartInfo.CreateNoWindow = True
                    process.Start()
                    process.WaitForExit()
                    If process.ExitCode = 0 Then
                        Try
                            process.StartInfo.Arguments = $"/c del {testFileName}"
                            process.Start()
                            process.WaitForExit()
                            If Not File.Exists(Path.Combine(virtialDirectory, testFileName)) Then
                                MessageBox.Show("OK")
                            Else
                                MessageBox.Show("実行ユーザーでフォルダーに書き込みはできるが削除ができません。")
                                Try
                                    File.Delete(Path.Combine(virtialDirectory, testFileName))
                                Catch ex As Exception
                                End Try
                            End If
                        Catch ex As Exception
                            MessageBox.Show(ex.Message)
                        End Try
                    Else
                        MessageBox.Show("実行ユーザーでフォルダーに書き込みできません。")
                    End If
                End Using
            Catch ex As Exception
                MessageBox.Show($"実行ユーザーでフォルダーに書き込みできません。{ex.Message}")
            End Try
        End Using

        Dim kjncd As String = "1"
        Dim query As String = $"select * from HCOMKJN where KJNCD='{kjncd}'"

    End Sub
End Class
