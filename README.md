# IIS Permission

IISの各種設定や権限を取得するサンプルプログラムです。

## 概要

- Webサイトの一覧を取得

```C#
using (var serverManager = new ServerManager())
{  
    foreach(var Site in serverManager.Sites) SitesCombo.Items.Add(Site.Name);
}
```

- Webサイト内のアプリケーションの一覧を取得

```C#
var site = serverManager.Sites.Where(x => x.Name.Equals(webSite)).FirstOrDefault();
foreach (var app in site.Applications) AppsCombo.Items.Add(app.Path); 
```

- アプリケーションのアプリケーションプール名を取得

```C#
var app = serverManager.Sites.Where(x => x.Name.Equals(siteName)).FirstOrDefault().Applications.Where(x => x.Path.Equals(appName)).FirstOrDefault();
var appPool = serverManager.ApplicationPools.Where(x => x.Name.Equals(app.ApplicationPoolName)).Where(x => x.Name.Equals(app.ApplicationPoolName)).FirstOrDefault(); 
```

- アプリケーションプールの実行ユーザーを取得  
ビルドインアカウント または カスタムアカウント  

```C#
if (appPool.ProcessModel.IdentityType.Equals(ProcessModelIdentityType.SpecificUser))
{
    //Custom Account
    AppPoolUserText.Text = appPool.ProcessModel.UserName;
    password = appPool.ProcessModel.Password;
} else {
    //Build in Account
    AppPoolUserText.Text = appPool.ProcessModel.IdentityType.ToString();
    password = appPool.ProcessModel.Password;
}
```

- アプリケーションプールの実行ユーザーで仮想ディレクトリにテストファイルを書き込みます。  
書き込み後は削除します。

## 注意事項

管理者権限で実行する必要があります。
