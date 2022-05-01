using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publisher
{
    public class BookingBackgroundWorker : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                //await DoSomethingAsync();
                //
                
                Task.Delay(5000).Wait();

            }
            return Task.CompletedTask;
        }
    }
}
