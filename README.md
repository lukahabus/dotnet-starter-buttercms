# .NET ButterCMS Starter Project

This .NET starter project fully integrates with dynamic sample content from your ButterCMS account, including main menu, pages, blog posts, categories, and tags, all with a beautiful, custom theme with already-implemented search functionality. All of the included sample content is automatically created in your account dashboard when you sign up for a free trial of ButterCMS.

You can view a [live demo hosted on hosting provider](https://dotnet-starter-buttercms.azurewebsites.net), or you can click the button below to deploy your own copy of our starter project to the provider of your choice.

[![Deploy to Azure](https://aka.ms/deploytoazurebutton)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fvlnevyhosteny%2FButterCMS.Starter%2Fmain%2F.azure%2Ftemplate%2Ftemplate.json)

## 1. Installation

First, clone the repo and install the dependencies by running `dotnet restore`:

```console
$ git clone https://github.com/ButterCMS/dotnet-starter-buttercms.git

$ cd dotnet-starter-buttercms

$ dotnet restore
```

### 2. Set API Token

To fetch your ButterCMS content, add your API token as an environment variable.

```console
$ dotnet user-secrets set "ButterCMS:APIKey" "<YOUR API Token"
```

### 3. Run local server

To view the app in the browser, you'll need to run the local development server:

```console
$ dotnet run
```

Congratulations! Your starter project is now live. To view your project, point your browser to [https://localhost:5001](https://localhost:5001).

## 4. Deploy on Azure

Deploy your .NET app using Azure. With the click of a button, you'll create a copy of your starter project in your Git provider account, instantly deploy it, and institute a full content workflow connected to your ButterCMS account. Smooth.

[![Deploy to Azure](https://aka.ms/deploytoazurebutton)](https://portal.azure.com/#create/Microsoft.Template/uri/https%3A%2F%2Fraw.githubusercontent.com%2Fvlnevyhosteny%2FButterCMS.Starter%2Fmain%2F.azure%2Ftemplate%2Ftemplate.json)
