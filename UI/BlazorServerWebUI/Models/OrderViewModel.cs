using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorServerWebUI.Models
{
	public class OrderViewModel
	{
        public int Order_Id { get; set; }
        public string Name { get; set; }
        public string Customer_Id { get; set; }
    }
}

