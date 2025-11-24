namespace Api.Providers;

public class RegionApiKeyProvider {
    public string GenerateRegionId() {
        return Guid.NewGuid().ToString("N");    
    }
    
    public ApiKeyResult GenerateApiKey() {
        throw new NotImplementedException();
    }

    public async Task StoreRegionKey(string regionId, ApiKeyResult key) {
        throw new NotImplementedException();
    }

    public async Task<bool> ValidateKey(string serverId, string plainTextKey) {
        throw new NotImplementedException();
    }
}

public class ApiKeyResult {
    public string KeyId { get; init; }
    public string PlaintextApiKey { get; init; } 
    public string KeyHash { get; init; }         
    public string Salt { get; init; }            
}