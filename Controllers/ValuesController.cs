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
        public ActionResult Post([FromBody] RecordModel rec)
        {
            if (authorize())
            {
                _valuesService.addRecord(rec);
                return Ok();
            }
            else
                return Unauthorized();
        }

        [HttpDelete]
        // DELETE a record
        public ActionResult Delete(RecordModel rec)
        {
            if (authorize())
            {
                _valuesService.deleteRecord(rec);
                return Ok();
            }
            else
                return Unauthorized();
        }

        [HttpGet("/all")]
        // GET SS for quote_currency_amount over the entire dataset
        public ActionResult<StatsModel> ssAmountOverEntireSet()
        {
            if (authorize())
                return Ok(_valuesService.ssAmountOverEntireSet());
            return Unauthorized();
        }

        [HttpGet("/stockBuy")]
        // GET SS for type stock_buy
        public ActionResult<StatsModel> ssForTypeStockBuy()
        {
            if (authorize())
                return Ok(_valuesService.ssForTypeStockBuy());
            return Unauthorized();
        }

        [HttpGet("/byType")]
        // GET SS for each type
        public ActionResult<Dictionary<string, StatsModel>> ssByType()
        {
            if (authorize())
                return Ok(_valuesService.ssByType());
            return Unauthorized();
        }

        [HttpGet("/byCombination")]
        // GET SS for each type and quote combination
        public ActionResult<Dictionary<string, StatsModel>> ssByTypeAndQuoteCombination()
        {
            if (authorize())
                return Ok(_valuesService.ssByTypeAndQuoteCombination());
            return Unauthorized();
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
