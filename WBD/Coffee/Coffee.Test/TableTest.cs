using Coffee.DAL;
using Coffee.DAL.Interface;
using Coffee.Domain.Entities;
using Coffee.Domain.Request.Table;
using NUnit.Framework;
using System.Threading.Tasks;

namespace Coffee.Test
{
    public class TableTest
    {
        private ITableRepository tableRepository;
        [SetUp]
        public void Setup()
        {
            tableRepository = new TableRepository();
        }

        [Test]
        public void CreateNewTable()
        {
            var request = new CreateTableReq()
            {
                TableCode = "T01.11"
            };
            var tableCreate = Task.Run(async () => await tableRepository.Create(request)).Result;
            Assert.IsNotNull(tableCreate);
            Assert.Greater(tableCreate.TableId,0);
        }
        [Test]
        public void CreateExistTable()
        {
            var request = new CreateTableReq()
            {
                TableCode = "T01.10"
            };
            var tableCreate = Task.Run(async () => await tableRepository.Create(request)).Result;
            Assert.IsNotNull(tableCreate);
            Assert.AreEqual(tableCreate.TableId, 0);
        }
    }
}