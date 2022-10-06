namespace FaturaRaporlama
{
	public class SanayiSegmentleri
	{
		public bool _kucuktur_20mwh { get; set; }
		public double Segment1ToplamTuketim { get; set; }
		public double Segment1ToplamTutar { get; set; }
		public bool _20_500mwh { get; set; }
		public double Segment2ToplamTuketim { get; set; }
		public double Segment2ToplamTutar { get; set; }
		public bool _500_2000mwh { get; set; }
		public double Segment3ToplamTuketim { get; set; }
		public double Segment3ToplamTutar { get; set; }
		public bool _2000_20000mwh { get; set; }
		public double Segment4ToplamTuketim { get; set; }
		public double Segment4ToplamTutar { get; set; }
		public bool _20000_70000mwh { get; set; }
		public double Segment5ToplamTuketim { get; set; }
		public double Segment5ToplamTutar { get; set; }
		public bool _70000_150000mwh { get; set; }
		public double Segment6ToplamTuketim { get; set; }
		public double Segment6ToplamTutar { get; set; }
		public bool _buyuktur150000mwh { get; set; }
		public double Segment7ToplamTuketim { get; set; }
		public double Segment7ToplamTutar { get; set; }
		public double ToplamTuketim { get; set; }
		public double ToplamTutar { get; set; }
	}
}
