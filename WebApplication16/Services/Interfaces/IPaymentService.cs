using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication16.Models;

namespace WebApplication16.Services.Interfaces
{
    interface IPaymentService
    {
        List<AddNewPayment> getAll();
        ApplicationContributionPayments2 GetContriburionByName(string name);
        void createPayment(string name, string privilege, string description, string user_status);
    }
}
