using System;
using Serilog.Events;
using Serilog.Sinks.AzureTableStorage.KeyGenerator;

namespace Com.Bekijkhet.SerilogTablestorageExample {
    public class MyKeyGenerator : IKeyGenerator
    {
        string IKeyGenerator.GeneratePartitionKey(LogEvent logEvent)
        {
            return (DateTime.MaxValue.Ticks - logEvent.Timestamp.Ticks).ToString().Substring(0, 9);
        }

        string IKeyGenerator.GenerateRowKey(LogEvent logEvent, string suffix)
        {
            return (DateTime.MaxValue.Ticks - logEvent.Timestamp.Ticks).ToString()+"."+Guid.NewGuid().ToString();
        }
    }
}
