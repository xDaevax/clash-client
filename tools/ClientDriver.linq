<Query Kind="Program">
  <Reference Relative="..\Src\ClashClient\bin\Debug\ClashClient.Common.dll">C:\Users\kyle\Source\Repos\xDaevax\clash-client\Src\ClashClient\bin\Debug\ClashClient.Common.dll</Reference>
  <Reference Relative="..\Src\ClashClient\bin\Debug\ClashClient.dll">C:\Users\kyle\Source\Repos\xDaevax\clash-client\Src\ClashClient\bin\Debug\ClashClient.dll</Reference>
  <Reference Relative="..\Src\ClashClient\bin\Debug\log4net.dll">C:\Users\kyle\Source\Repos\xDaevax\clash-client\Src\ClashClient\bin\Debug\log4net.dll</Reference>
  <Reference Relative="..\Src\ClashClient\bin\Debug\Newtonsoft.Json.dll">C:\Users\kyle\Source\Repos\xDaevax\clash-client\Src\ClashClient\bin\Debug\Newtonsoft.Json.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Web.dll</Reference>
  <Namespace>ClashClient.Clans</Namespace>
  <Namespace>ClashClient.Common.Caching</Namespace>
  <Namespace>ClashClient.Net</Namespace>
  <Namespace>ClashClient.Players</Namespace>
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
    configProvider.AddValue("ApiToken", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6ImM1NjNmNTkxLTUyYzEtNDQyYS1iYjdiLWEwMTg0MGE3Njg5OSIsImlhdCI6MTU1NTM2MTgzNCwic3ViIjoiZGV2ZWxvcGVyL2U3YmViN2IxLTVlODktMjY3My1iNzE3LTc3OWJiODIxN2VlZiIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjEwNC4yMzAuMzMuMTczIl0sInR5cGUiOiJjbGllbnQifV19.xjkuVjPQLJH_8BgdqDqYa41nYjUsVCY-iXCT_toKSXvMkSLlcwR7IHTVHki-vbJ2eaOMh4dYM3G17quSNzdIZA");
    ICacheSettings cacheSettings = new CacheSettings(configProvider);
    ICacheProvider cacheProvider = new RuntimeCacheProvider(cacheSettings);
    
    var searchRequest = new ClanSearchRequest() { ClanName = "Pretty Useless", WarFrequency = WarFrequency.Unknown, MinimumMembers = 20, Limit = 20  };
    var detailRequest = new ClanInfoRequest() { Tag = "#9RP9PLY0" };
    var memberRequest = new ClanMembersRequest() { Tag = "#9RP9PLY0" };
    var warLogRequest = new ClanWarLogRequest() { Tag = "#9RP9PLY0", Limit = 100 };
    var playerRequest = new PlayerInfoRequest() { Tag = "#JY2LJVRU" };
    
    ApiClient client = new ApiClient(configProvider, cacheProvider);
    
    var response = client.Load<ClanSearchResponse>(searchRequest);
    var detailResponse = client.Load<DetailedClanResult>(detailRequest);
    var memberResponse = client.Load<ClanMembersResponse>(memberRequest);
    var warLogResponse = client.Load<ClanWarLogResponse>(warLogRequest);
    var playerResponse = client.Load<DetailedPlayerResult>(playerRequest);
    
    response.Dump();
    var nextPage = new ClanSearchRequest() { ClanName = "Pretty Useless", WarFrequency = WarFrequency.Unknown, MinimumMembers = 20, Limit = 20, After = response.Data.Pager.Cursors.After };
    var nextPageResponse = client.Load<ClanSearchResponse>(nextPage);
    nextPageResponse.Dump();
    detailResponse.Dump();
    memberResponse.Dump();
    warLogResponse.Dump();
    playerResponse.Dump();

    var items = cacheProvider.GetCacheItemInfo(new List<string>() { $"ApiResponse_{searchRequest.ToCacheName(new QueryStringFormatter())}", $"ApiResponse_{detailRequest.ToCacheName(new QueryStringFormatter())}", $"ApiResponse_{memberRequest.ToCacheName(new QueryStringFormatter()) }", $"ApiResponse_{nextPage.ToCacheName(new QueryStringFormatter()) }" });
    items.Dump();
    
}

// Define other methods and classes here