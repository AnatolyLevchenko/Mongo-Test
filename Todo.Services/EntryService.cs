using MongoDB.Driver;
using System.Collections.Generic;
using ToDo.Domain;
using ToDo.Domain.Models;

namespace Todo.Services
{
    public class EntryService
    {
        private readonly IMongoCollection<Entry> _entries;

        public EntryService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _entries = database.GetCollection<Entry>(settings.CollectionName);
        }

        public List<Entry> GetAll()
        {
            return _entries.Find(entry => true).ToList();
        }

        public Entry GetById(string id)
        {
            return _entries.Find(entry => entry.Id==id).FirstOrDefault();
        }

        public Entry Create(Entry entry)
        {
            _entries.InsertOne(entry);
            return entry;
        }

        public void Update(string id, Entry entry)
        {
            _entries.ReplaceOne(e => e.Id == id, entry);
        }

        public void Remove(Entry entry)
        {
            _entries.DeleteOne(e => e.Id == entry.Id);
        }

        public void Remove(string id)
        {
            _entries.DeleteOne(e => e.Id == id);
        }
    }
}
