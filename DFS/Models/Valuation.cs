using System;
using SQLite;

namespace DFS
{
    public class Valuation
    {

        [PrimaryKey, AutoIncrement]
        public Int64 Id { get; set; }
        [Indexed]
        public int StockId { get; set; }
        public DateTime Time { get; set; }
        public decimal Price { get; set; }

        public Valuation()
        {
        }
    }
}
