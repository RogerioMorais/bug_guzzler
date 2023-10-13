FROM mcr.microsoft.com/dotnet/sdk:7.0

ENV ASPNETCORE_ENVIRONMENT=Development 

WORKDIR /bug_guzzler/src/rmorais.bug_guzzler_api.api

EXPOSE 5000
EXPOSE 5001


ENTRYPOINT ["dotnet", "run", "--urls", "http://*:5000;http://*:5001"]