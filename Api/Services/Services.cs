using Api.DAL;
using Api.Database;
using Api.Providers.Email;
using Api.Providers.Token;

namespace Api.Services;

public class Services {
    public readonly UserService UserService;
    public readonly CleanupService CleanupService;
    public Services() {
        throw new NotImplementedException();
        // UserService = new UserService();
        // CleanupService = new CleanupService();
    }
}