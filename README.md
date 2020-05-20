## COSC2626 Cloud Computing Assignment 02
*RMIT University Melbourne*
<br>**group members:**
> Andrew Ellis - s3747746
<br>Shrey Parekh - s3710669

### Application Features
**Business Controller API:** 
>+ *Get all Companies Pay Slips*
>+ *Get a Companies Employee Pay slip*
>+ *Get all Companies Pay Agreements*
>+ *Get a Companies Employee Pay Agreement*
>+ *Add a Pay Agreement*
>+ *Update a Pay Agreement*

#### Notes
>This API was developed for use with **AWS serverless Lambda**, and as such the controllers are specifically designed for optimum compatibility. Additonally the service was as well designed in mind for the interaction with **AWS API Gateway**

#### System Requirements

**ASP.NET Core**
- .NET Core SDK 3.1.202
- .Net Core Runtime 3.1.4

- VisualStudio Version 8.5.6 (build 11)

#### Dependencies
**Project SDK**
- Microsoft.NET.Sdk.Web

**Frameworks**
- Microsoft.AspNetCore.App (3.1.3)
- Microsoft.NETCore.App (3.1.0)

**NuGet** *packages*
- Microsoft.EntityFrameworkCore.Tools
- Microsoft.AspNetCore.Identity.EntityFrameworkCore
- Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- AWSSDK.S3
- AWSSDK.Extensions.NETCore.Setup
- Amazon.Lambda.AspNetCoreServer

#### Application Architecture
The application was with ASP.NET Core Web API
