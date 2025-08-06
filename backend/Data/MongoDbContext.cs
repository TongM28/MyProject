using BackendProject.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BackendProject.Data
{
public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IOptions<MongoDbSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        _database = client.GetDatabase(settings.Value.DatabaseName);
    }

    // Lưu ý: nếu collection tên là car_information thì đặt đúng tên
    public IMongoCollection<Car> Cars => _database.GetCollection<Car>("car_information");
}

}
