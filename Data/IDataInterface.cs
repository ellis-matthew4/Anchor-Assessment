using Anchor_Assessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anchor_Assessment.Data
{
    public interface IDataInterface
    {
        public List<RecordModel> getData();
        public void addRecord(RecordModel rec);
        public void deleteRecord(RecordModel rec);
    }
}
