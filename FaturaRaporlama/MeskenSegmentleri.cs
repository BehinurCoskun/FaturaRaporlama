namespace FaturaRaporlama
{
	public class MeskenSegmentleri
	{
		public bool _kucuktur_1000kwh { get; set; }
		public double Segment1ToplamTuketim { get; set; }
		public double Segment1ToplamTutar { get; set; }
		public bool _1000_2500kwh { get; set; }
		public double Segment2ToplamTuketim { get; set; }
		public double Segment2ToplamTutar { get; set; }
		public bool _2500_5000kwh { get; set; }
		public double Segment3ToplamTuketim { get; set; }
		public double Segment3ToplamTutar { get; set; }
		public bool _5000_15000kwh { get; set; }
		public double Segment4ToplamTuketim { get; set; }
		public double Segment4ToplamTutar { get; set; }
		public bool _buyuktur15000kwh { get; set; }
		public double Segment5ToplamTuketim { get; set; }
		public double Segment5ToplamTutar { get; set; }
		public double ToplamTuketim { get; set; }
		public double ToplamTutar { get; set; }
	}
}
