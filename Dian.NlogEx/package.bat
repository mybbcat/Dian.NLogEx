nuget pack Dian.NLogEx.csproj
ping /n 2 127.1 >nul
nuget push Dian.NLogEx*.nupkg e69a7d51-8f6f-495f-82ec-50d0db75cf42 -Source https://www.nuget.org/
ping /n 2 127.1 >nul
del Dian.NLogEx*.nupkg