# reddit.net
This is a simplistic reddit-like website done in asp.net core

## Requirements
* [.Net CORE](https://www.microsoft.com/net/core) (v 1.0.1)
* Sql Server  
  - [SQL Server 2016](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) OR
  - [SQL Server v.Next](https://www.microsoft.com/en-us/sql-server/sql-server-vnext-including-Linux)
  
#### Installation
* Install .net core and a version of Sql Server
* create a database named "redditnet"
* run `Update-Database` from the NuGet package manager console. (This will set the tables up in the database for you)
* Run the program from Visusal Studio, or
* [Publish your project](https://docs.microsoft.com/en-us/aspnet/core/publishing/)
