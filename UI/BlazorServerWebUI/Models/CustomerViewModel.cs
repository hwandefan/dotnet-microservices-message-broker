using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorServerWebUI.Models
{
	public class CustomerViewModel
	{
        public int Customer_Id { get; set; }
        public string CustomerName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
    }
}

