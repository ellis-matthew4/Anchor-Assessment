using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anchor_Assessment.Models;
using Anchor_Assessment.Repositories;

namespace Anchor_Assessment.Services
{
    public interface IValuesService
    {
        public void addRecord(RecordModel rec);
        public void deleteRecord(RecordModel rec);
        public StatsModel ssAmountOverEntireSet();
        public StatsModel ssForTypeStockBuy();
        public Dictionary<string, StatsModel> ssByType();
        public Dictionary<string, StatsModel> ssByTypeAndQuoteCombination();
    }
}
