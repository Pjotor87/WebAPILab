﻿using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Common.Helpers;
using System;
using Models;
using DAL.Contexts;

namespace WebAPILab.Controllers
{
    public class InquiryController : ApiController, IInquiryController
    {
        private readonly IDatabaseContext DbContext;

        public InquiryController(IDatabaseContext dbContext)
        {
            DbContext = dbContext;
        }

        public HttpResponseMessage GetCustomerResponseById(int customerId)
        {
            if (!ValidationHelper.IsValidIntegerForId(customerId))
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                { Content = new StringContent(Constants.Search.ErrorMessages.BAD_CUSTOMERID) };
            return this.Search(new Func<Customer, bool>
                (x => x.CustomerId == customerId));
        }

        public HttpResponseMessage GetCustomerResponseByEmail(string email)
        {
            if (!ValidationHelper.IsValidEmail(email))
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                { Content = new StringContent(Constants.Search.ErrorMessages.BAD_EMAIL) };
            return this.Search(new Func<Customer, bool>
                (x => x.CustomerEmail == email));
        }

        public HttpResponseMessage GetCustomerResponse(int customerId, string email)
        {
            if (!ValidationHelper.IsValidIntegerForId(customerId) && !ValidationHelper.IsValidEmail(email))
                return new HttpResponseMessage(HttpStatusCode.BadRequest)
                { Content = new StringContent(Constants.Search.ErrorMessages.NOSEARCHCRITERIA) };
            return this.Search(new Func<Customer, bool>
                (x => x.CustomerId == customerId && x.CustomerEmail == email));
        }

        private HttpResponseMessage Search(Func<Customer, bool> filter)
        {
            HttpResponseMessage response = null;

            Customer searchResult = DbContext.Customers.ToList().Where(filter).FirstOrDefault();
            if (searchResult == null)
                response = new HttpResponseMessage(HttpStatusCode.BadRequest)
                { Content = new StringContent(Constants.Search.ErrorMessages.NOT_FOUND) };
            else
            {
                searchResult.PopulateTransactions(DbContext.Transactions.ToList());
                searchResult.SetMostRecentTransactions(5);
                response = new HttpResponseMessage(HttpStatusCode.OK)
                { Content = new StringContent(JsonConvert.SerializeObject(searchResult), Encoding.UTF8, Constants.Search.RESPONSE_FORMAT) };
            }

            return response;
        }
    }
}