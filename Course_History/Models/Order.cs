﻿namespace Course_History.Models
{
    public class Order
    {
        public int Id { get; set; }

        public string OrderCode { get; set; }

        public string UserName { get; set; }

        public DateTime CreatedDate { get; set; }

        public int Status { get; set; }

        public double TotalMoney { get; set; }
    }
}
