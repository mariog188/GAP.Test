FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base

# Setup NodeJs
RUN apt-get update && \
    apt-get install -y wget && \
    apt-get install -y gnupg2 && \
    wget -qO- https://deb.nodesource.com/setup_9.x | bash - && \
    apt-get install -y build-essential nodejs
# End setup
# commit 3
# commit 4
# commit 5
WORKDIR /app
EXPOSE 80