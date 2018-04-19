#使用microsoft/dotnet:sdk镜像作为编译环境
FROM microsoft/aspnetcore-build:2.0 AS build-env
#设置应用在docker中的工作路径
WORKDIR /app
#拷贝所有csproj文件到/app下
COPY ./ApiGateWayApp/*.csproj  ./
#执行还原命令
RUN dotnet restore
#拷贝所有文件到/app下
COPY ./ApiGateWayApp/ ./
#执行发布命令，编译的发布文件生成到/app/out目录下
RUN dotnet publish -c Release -o out

#使用microsoft/dotnet:runtime镜像作为运行环境
FROM microsoft/aspnetcore:2.0
EXPOSE 80
#设置应用在docker中的工作路径
WORKDIR /app
#从build-env生成/app/out目录下的所有文件拷贝到/app下
COPY --from=build-env /app/out ./
#设置应用的启动命令
ENTRYPOINT [ "dotnet","ApiGateWayApp.dll" ]

