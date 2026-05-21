using CommandService.Models;
using Confluent.Kafka;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Text.Json;
using static Confluent.Kafka.ConfigPropertyNames;

namespace CommandService.Services
{
    public class UserService : IUserService
    {
        private readonly string _connectionString;
        private readonly IProducer<Null, string> _producer;
        public UserService(IConfiguration cfg)
        {
            _connectionString = cfg.GetConnectionString("cnnStr")!;
            var producerConfig = new ProducerConfig()
            {
                BootstrapServers = cfg["Kafka:BootstrapServers"]
            };
            _producer = new ProducerBuilder<Null, string>(producerConfig).Build();
        }
        public async Task CreateUserAsync(User user)
        {
            var @event = new
            {
                EventId = Guid.NewGuid(),
                EventType = "UserCreated",
                AggregateId = user.Id,
                Data = user,
                CreateAt = DateTime.UtcNow,
            };
            using var connection = new SqlConnection(_connectionString);
            var sql = "INSERT INTO Events(EvenId, EventType, AggregateId," + "Data, CreateAt) VALUES (@EventId,@EventType,@AggregateId," + "@Data, @CreateAt)";
            await connection.ExecuteAsync(sql, new
            {
                @event.EventId,
                @event.EventType,
                @event.AggregateId,
                Data = JsonSerializer.Serialize(@event.Data),
                @event.CreateAt
            });
            var json = JsonSerializer.Serialize(@event.Data);
            await _producer.ProduceAsync("users-event", new Message<Null, string> { Value = json });
        }
        
    }
}
