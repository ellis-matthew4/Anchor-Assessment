using Anchor_Assessment.Models;
using Anchor_Assessment.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace Anchor_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IValuesService _valuesService;
        public ValuesController (IValuesService valuesService){
            _valuesService = valuesService ?? throw new ArgumentNullException(nameof(ValuesService));
        }
        [HttpPost]
        // POST a record
        public void Post([FromBody] RecordModel rec)
        {
            if (authorize())
                _valuesService.addRecord(rec);
            else
                throw new AccessViolationException("Access denied.");
        }

        [HttpDelete]
        // DELETE a record
        public void Delete(RecordModel rec)
        {
            if (authorize())
                _valuesService.deleteRecord(rec);
            else
                throw new AccessViolationException("Access denied.");
        }

        [HttpGet("/all")]
        // GET SS for quote_currency_amount over the entire dataset
        public StatsModel ssAmountOverEntireSet()
        {
            if (authorize())
                return _valuesService.ssAmountOverEntireSet();
            throw new AccessViolationException("Access denied.");
        }

        [HttpGet("/stockBuy")]
        // GET SS for type stock_buy
        public StatsModel ssForTypeStockBuy()
        {
            if (authorize())
                return _valuesService.ssForTypeStockBuy();
            throw new AccessViolationException("Access denied.");
        }

        [HttpGet("/byType")]
        // GET SS for each type
        public Dictionary<string, StatsModel> ssByType()
        {
            if (authorize())
                return _valuesService.ssByType();
            throw new AccessViolationException("Access denied.");
        }

        [HttpGet("/byCombination")]
        // GET SS for each type and quote combination
        public Dictionary<string, StatsModel> ssByTypeAndQuoteCombination()
        {
            if (authorize())
                return _valuesService.ssByTypeAndQuoteCombination();
            throw new AccessViolationException("Access denied.");
        }

        private bool authorize()
        {
            if (Request.Headers.ContainsKey("authorization"))
            {
                var h = Request.Headers["authorization"][0];
                if (h == "sample_login_token")
                {
                    return true;
                }
            }
            return false;
        }
    }
}
