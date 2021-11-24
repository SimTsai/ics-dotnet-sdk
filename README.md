# 跨境无忧ICS dotnet SDK

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
