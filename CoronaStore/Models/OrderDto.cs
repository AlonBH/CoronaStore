using System;

namespace CoronaStore.Models
{
    public class OrderDto
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public DateTime Date { get; set; }

    }
}