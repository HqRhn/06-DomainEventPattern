using OrderManagement.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Common
{
    public class EmailService : IEmailService
    {
        public Task SendOrderAcceptedConfirmationEmailAsync()
        {
            return Task.CompletedTask;
        }
    }
}
