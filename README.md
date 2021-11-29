# 跨境无忧ICS dotnet SDK
===
![Nuget](https://img.shields.io/nuget/v/ics-dotnet-sdk)

## How to use

### Non DI
- app.config or web.config
```xml
<configuration>
  <configSections>
    <section name="ics" type="Ics.OpenApi.ConfigurationSection.IcsConfigurationSection, Ics.OpenApi"/>
  </configSections>
  <ics environment="Test" tokenStorageIn="Redis">
    <account
      user=""
      password="" />
    <redisOptions connectionString="192.168.1.223:6379" />
  </ics>
</configuration>
```

- 使用
```csharp
using var icsService =  IcsServiceFactory.CreateIcsService();
```

### With DI (IServiceCollection)
- in startup ConfigureServices
```csharp
service.AddIcs()
```
- appsettings.{?}.json
```json
{
  "Ics": {
    "Environment": "Test",  // 连接ICS的环境 Test OR Production
    "Account": { // ICS提供的账号信息
        "User": "",
        "Password": ""
    },
    "TokenStorageIn": "Redis", // Token存储位置 Redis OR InMemory
    "InMemoryOptions": { // see also Microsoft.Extensions.Caching.Memory.MemoryCacheOptions
        "ExpirationScanFrequency": "",
        "SizeLimit": "",
        "CompactionPercentage": 
    },
    "RedisOptions": { // see also Microsoft.Extensions.Caching.StackExchangeRedis.RedisCacheOptions
      "Configuration": "192.168.1.223:6379",
      "InstanceName": ""
    }
  }
}
```


### 已实现方法
|接口文档|DI|NonDI|实现版本|
|-|-|-|-|
|1.2 api获取令牌（token）|-|-|1.10.28-dev.1|
|2.1 获取报关单及制单明细|`IIcsDeclareService`<br />`.GetDelegateAsync`|`IIcsService`<br />`.IcsDeclareService`<br />`.GetDelegateAsync`|1.10.28-dev.1|
|2.2 发送报关单及申报明细|`IIcsDeclareService`<br />`.TransferDelegateAsync`|`IIcsService`<br />`.IcsDeclareService`<br />`.TransferDelegateAsync`|1.10.28-dev.2|
|2.4 发送审核状态|`IIcsDeclareService`<br />`.TransferStatusAsync`|`IIcsService`<br />`.IcsDeclareService`<br />`.TransferStatusAsync`|1.10.28-dev.2|
|2.5 获取报关单集装箱明细|`IIcsDeclareService`<br />`.GetDelegateBoxAsync`|`IIcsService`<br />`.IcsDeclareService`<br />`.GetDelegateBoxAsync`|1.10.28-dev.2|
|2.6 发送报关单集装箱明细|`IIcsDeclareService`<br />`.TransferDelegateBoxAsync`|`IIcsService`<br />`.IcsDeclareService`<br />`.TransferDelegateBoxAsync`|1.10.28-dev.2|
|2.7 获取随附单证|`IIcsDeclareService`<br />`.GetBFSCicAsync`|`IIcsService`<br />`.IcsDeclareService`<br />`.GetBFSCicAsync`|1.10.28-dev.2|
|2.8 发送随附单证|`IIcsDeclareService`<br />`.TransferBFSCicAsync`|`IIcsService`<br />`.IcsDeclareService`<br />`.TransferBFSCicAsync`|1.10.28-dev.2|
