<Query Kind="Program">
  <Reference Relative="..\Src\ClashClient\bin\Debug\ClashClient.Common.dll">C:\Users\kyle\Source\Repos\xDaevax\clash-client\Src\ClashClient\bin\Debug\ClashClient.Common.dll</Reference>
  <Reference Relative="..\Src\ClashClient\bin\Debug\ClashClient.dll">C:\Users\kyle\Source\Repos\xDaevax\clash-client\Src\ClashClient\bin\Debug\ClashClient.dll</Reference>
  <Reference Relative="..\Src\ClashClient\bin\Debug\log4net.dll">C:\Users\kyle\Source\Repos\xDaevax\clash-client\Src\ClashClient\bin\Debug\log4net.dll</Reference>
  <Reference Relative="..\Src\ClashClient\bin\Debug\Newtonsoft.Json.dll">C:\Users\kyle\Source\Repos\xDaevax\clash-client\Src\ClashClient\bin\Debug\Newtonsoft.Json.dll</Reference>
  <Namespace>ClashClient.Clans</Namespace>
  <Namespace>ClashClient.Net</Namespace>
  <Namespace>ClashClient.Common.Caching</Namespace>
  <AppConfig>
    <Content>
      <configuration>
        <configSections>
          <section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler,log4net" />
          <sectionGroup name="cacheConfigurationGroup">
            <section name="cacheConfiguration" type="ClashClient.Common.Caching.CacheConfigurationSection, ClashClient.Common" allowDefinition="Everywhere" allowLocation="true" />
          </sectionGroup>
        </configSections>
        <cacheConfigurationGroup>
          <cacheConfiguration>
            <preferences>
              <add preference="Default" duration="30" />
              <add preference="ShortLivedSliding" duration="2" />
              <add preference="ShortLived" duration="2" />
              <add preference="ExtendedSliding" duration="60" />
              <add preference="Extended" duration="60" />
              <add preference="LongTermSliding" duration="120" />
              <add preference="LongTerm" duration="120" />
            </preferences>
          </cacheConfiguration>
        </cacheConfigurationGroup>
      </configuration>
    </Content>
  </AppConfig>
</Query>

void Main() {
    ClashClient.Configuration.InMemoryConfigurationProvider configProvider = new ClashClient.Configuration.InMemoryConfigurationProvider();
    configProvider.AddValue("ApiVersion", "v1");
    configProvider.AddValue("Caching_Enabled", true);
    configProvider.AddValue("ClashAPI", "https://api.clashofclans.com");
    configProvider.AddValue("ApiToken", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6ImU2N2E4MmQ0LWYzZGItNDFlZC05NTRlLTNjODMxYjk5ZWNiMSIsImlhdCI6MTU1MDYwNDMzMCwic3ViIjoiZGV2ZWxvcGVyL2U3YmViN2IxLTVlODktMjY3My1iNzE3LTc3OWJiODIxN2VlZiIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjE5OC4yNC4xMjcuMiJdLCJ0eXBlIjoiY2xpZW50In1dfQ.6iZltueue1a2SDZ_xgPUSfv_WfPHJyQz7ALazJed4mb1GeG26yJsGkuaDzGaR7MSZxf2ywkB_msZsNUSWqQ4VQ");
    ICacheSettings cacheSettings = new CacheSettings(configProvider);
    ICacheProvider cacheProvider = new RuntimeCacheProvider(cacheSettings);
    
    var request = new ClanSearchRequest() { ClanName = "Pretty Useless", Method = "clans", WarFrequency = WarFrequency.Unknown, MinimumMembers = 20  };
    ApiClient client = new ApiClient(configProvider, cacheProvider);
    
    var response = client.Load<ClanSearchResponse>(request);
    
    response.Dump();

    var items = cacheProvider.GetCacheItemInfo(new List<string>() { $"ApiResponse_{request.ToCacheName(new QueryStringFormatter())}"});
    
    items.Dump();

    var nextResponse = client.Load<ClanSearchResponse>(request);
    
    nextResponse.Dump();
}

// Define other methods and classes here
