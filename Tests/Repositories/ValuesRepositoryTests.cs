using Anchor_Assessment.Data;
using Anchor_Assessment.Models;
using Anchor_Assessment.Repositories;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anchor_Assessment.Tests.Repositories
{
    public class ValuesRepositoryTests
    {
        public Mock<IDataInterface> _dataInterface;
        public ValuesRepository repo;

        [SetUp]
        public void Setup()
        {
            _dataInterface = new Mock<IDataInterface>();
            _dataInterface.Setup(_ => _.addRecord(It.IsAny<RecordModel>())).Verifiable();
            _dataInterface.Setup(_ => _.deleteRecord(It.IsAny<RecordModel>())).Verifiable();
            _dataInterface.Setup(_ => _.getData()).Returns(new List<RecordModel>
            {
                new RecordModel
                {
                    type = "a",
                    status = "b",
                    quote_currency = "c",
                    quote_currency_amount = (double) 1.0
                },
                new RecordModel
                {
                    type = "a",
                    status = "b",
                    quote_currency = "d",
                    quote_currency_amount = (double) 2.0
                },
                new RecordModel
                {
                    type = "a",
                    status = "b",
                    quote_currency = "e",
                    quote_currency_amount = (double) 3.0
                },
            });

            repo = new ValuesRepository(_dataInterface.Object);
        }

        [Test]
        public void addRecord_does_not_throw()
        {
            Assert.DoesNotThrow(() => repo.addRecord(new RecordModel()));
        }

        [Test]
        public void deleteRecord_does_not_throw()
        {
            Assert.DoesNotThrow(() => repo.deleteRecord(new RecordModel()));
        }

        [Test]
        public void getssAmountOverEntireSet_returns_correct_value()
        {
            StatsModel result = repo.ssAmountOverEntireSet();
            Assert.AreEqual(result.average, 2);
            Assert.AreEqual(result.min, 1);
            Assert.AreEqual(result.max, 3);
        }

        // No test data contains stock_buy, so should return all zeroes
        [Test]
        public void ssForTypeStockBuy_returns_zero_values()
        {
            StatsModel result = repo.ssForTypeStockBuy();
            Assert.AreEqual(result.average, 0);
            Assert.AreEqual(result.min, 0);
            Assert.AreEqual(result.max, 0);
        }

        // Only one type, so should return one value
        [Test]
        public void ssByType_returns_correct_value()
        {
            Dictionary<string, StatsModel> result = repo.ssByType();
            Assert.AreEqual(result.Keys.Count, 1);
        }

        // One type, but three quote_currency, so should be 3
        [Test]
        public void ssByTypeAndQuoteCombination_returns_correct_value()
        {
            Dictionary<string, StatsModel> result = repo.ssByTypeAndQuoteCombination();
            Assert.AreEqual(result.Keys.Count, 3);
        }
    }
}
