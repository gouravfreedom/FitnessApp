using System;
using SQLite;

namespace DFS
{
    [Table("STOCK_TABLE")]
    public class Stock
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Symbol { get; set; }

        public Stock()
        {
        }
    }
}
