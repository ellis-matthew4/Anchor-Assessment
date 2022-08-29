using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Anchor_Project.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpPost]
        // POST a record
        public void Post([FromBody] string value)
        {
        }

        [HttpDelete]
        // DELETE a record
        public void Delete(int id)
        {
        }

        [HttpGet]
        // GET SS for quote_currency_amount over the entire dataset
        public void ssAmountOverEntireSet()
        {
        }

        [HttpGet]
        // GET SS for type stock_buy
        public void ssForTypeStockBuy()
        {
        }

        [HttpGet]
        // GET SS for each type
        public void ssByType()
        {
        }

        [HttpGet]
        // GET SS for each type and quote combination
        public void ssByTypeAndQuoteCombination()
        {
        }
    }
}
