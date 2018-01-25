using Microsoft.Extensions.Logging;

namespace Com.Bekijkhet.SerilogTablestorageExample {
    public class App
    {
        private readonly ILogger<App> _logger;
    
        public App(ILogger<App> logger)
        {
            _logger = logger;
        }
    
        public void Run()
        {
            _logger.LogDebug("Testing 123");
            _logger.LogDebug("Testing 456");
            _logger.LogDebug("Testing 789");
            System.Console.ReadKey();
        }
    }
}
