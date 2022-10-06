using System;

namespace FaturaRaporlama
{
	public class Invoice
	{
		public int InvoiceId { get; set; }
		private string _InvoicePeriod = "";
		public string InvoicePeriod 
		{
			get => _InvoicePeriod;
			set
			{
				_InvoicePeriod = value;
				InvoiceYear = Convert.ToInt32(value.Substring(0, 4));
				InvoiceMounth = Convert.ToInt32(value.Substring(5, 2));
			}
		}
		public int InvoiceYear { get; set; }
		public int InvoiceMounth { get; set; }
		public string InvoiceState { get; set; }
		public string ConsumerGroup { get; set; }
		public string CommercialTitle { get; set; }
		public double TotalConsumption { get; set; }
		public double TotalAmount { get; set; }
	}
}
