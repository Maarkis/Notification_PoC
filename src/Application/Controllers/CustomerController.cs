using System;
using System.Collections.Generic;
using System.Linq;
using Application.Domain;
using Application.Notification;
using Application.RequestResponse;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly NotificationContext _notificationContext;

        public CustomerController(ILogger<CustomerController> logger, NotificationContext notificationContext)
        {
            _logger = logger;
            _notificationContext = notificationContext;
        }

        [HttpPost]
        public CustomerResponse Post([FromBody] CustomerRequest request)
        {
            var customer = new Customer(request.Name, request.Email);

            if (customer.Invalid)
                _notificationContext.AddNotifications(customer.ValidationResult);
            
            return new CustomerResponse()
            {
                Name = customer.Name
            };
        }
    }
}
