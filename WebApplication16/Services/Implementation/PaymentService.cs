using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication16.Models;
using WebApplication16.Services.Interfaces;
using WebApplication16.Services;

namespace WebApplication16.Services
{
    public class PaymentService : IPaymentService
    {
        private IPaymentService ContributionPayments;

        private PaymentService(IPaymentService ContributionPayments)
        {
            this.ContributionPayments = ContributionPayments;
        }

        public void createPayment(string name, string privilege, string description, string user_status)
        {
            PaymentService.createPayment(new AddNewPayment { ContributionName = name, ContributionPrivilege = privilege, ContributionDescription = description, UserStatus = user_status });
        }

        private static void createPayment(AddNewPayment addNewPayment)
        {
            throw new NotImplementedException();
        }

        public List<AddNewPayment> getAllPayments()
        {
            return ContributionPayments.getAll();
        }

        public ApplicationContributionPayments2 getContributionByName(string name)
        {
            return ContributionPayments.GetContriburionByName(name);
        }

        public List<AddNewPayment> getAll()
        {
            throw new NotImplementedException();
        }

        public ApplicationContributionPayments2 GetContriburionByName(string name)
        {
            return ContributionPayments.GetContriburionByName(name);
        }
    }
}
