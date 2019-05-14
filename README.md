# formapp
.NET Core 3.0.100-preview5-011568 を使用したFormアプリケーションサンプル

## Purpose

* .NET Core 3.0から追加されたDesktopアプリケーションを試す.
* `/p:PublishSingleFile`オプションを試す

## Require

* Windows10
* .NET COre 3.0.100-preview5-011568

## Usage

### build

`dotnet build` or
`dotnet publish --configuration=Release -r win10-x64 --self-contained=true /p:PublishSingleFile=true`
--> build to single binaly.

### run

`dotnet run` or 
`bin/[Debug|Release]/netcoreapp3.0/win10-x64/publish/formapp.exe`

## Use Image

Comming soon.
