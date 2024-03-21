using ApiAngularJose.Configuration;
using ApiAngularJose.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ApiAngularJose.Services
{
    public class ResumeServices
    {
        private readonly IMongoCollection<Resume> _resumeCollection;

        public ResumeServices(IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);

            var mongoDB = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _resumeCollection = mongoDB.GetCollection<Resume>(databaseSettings.Value.CollectionName);
        }




        public async Task<List<Resume>> GetAsync() => await _resumeCollection.Find(_ => true).ToListAsync();

        public async Task<Resume> GetResumeById(string Id)
        {
            return await _resumeCollection.FindAsync(new BsonDocument { { "_id", new ObjectId(Id) } }).Result.FirstAsync();
        }

        public async Task InsertResume(Resume resume)
        {
            await _resumeCollection.InsertOneAsync(resume);
        }

        public async Task UpdateResume(Resume resume)
        {
            var filter = Builders<Resume>.Filter.Eq(s => s.Id, resume.Id);
            await _resumeCollection.ReplaceOneAsync(filter, resume);
        }

        //public async Task DeleteRes(string Id)
        //{
        //    var filter = Builders<Resume>.Filter.Eq(s => s.Id, Id);
        //    await _resumeCollection.DeleteOneAsync(filter);
        //}
    }
}
