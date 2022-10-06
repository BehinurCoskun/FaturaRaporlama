using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FaturaRaporlama
{
    public partial class Form1 : Form
    {
        private List<Invoice> FinalMeskenInvoices;
        private List<Invoice> FinalSanayiInvoices;
        private List<Invoice> FinalOtherInvoices;

		private List<Invoice> FinalMeskenInvoicesWithYear;
		private List<Invoice> FinalSanayiInvoicesWithYear;
		private List<Invoice> FinalOtherInvoicesWithYear;
		public Form1()
        {
            InitializeComponent();
            string json = File.ReadAllText("sample_invoices.json");
            JsonFileRoot Invoices = JsonConvert.DeserializeObject<JsonFileRoot>(json);

            FinalMeskenInvoices = Invoices.Invoices.Where(z => z.InvoiceState.Equals("Final")
                                                            && z.ConsumerGroup.Equals("Mesken")).ToList();
            FinalSanayiInvoices = Invoices.Invoices.Where(z => z.InvoiceState.Equals("Final")
                                                            && z.ConsumerGroup.Equals("Sanayi")).ToList();
            FinalOtherInvoices = Invoices.Invoices.Where(z => z.InvoiceState.Equals("Final")
                                                              && !z.ConsumerGroup.Equals("Sanayi") && !z.ConsumerGroup.Equals("Mesken")).ToList();

        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
			if (YearComboBox.SelectedItem == null)
			{
				MessageBox.Show("Yıl secimi yapiniz!!.");
				return;
			}

			if (PeriodComboBox.SelectedItem == null)
			{
				MessageBox.Show("Dönem secimi yapiniz!!.");
				return;
			}

			int year = Convert.ToInt32(YearComboBox.SelectedItem.ToString());
			YılaGoreFaturalarıAl(year);
		}

		private void YılaGoreFaturalarıAl(int year)
		{
			if (PeriodComboBox.SelectedItem.ToString().Equals("1. Dönem"))
			{
				FinalMeskenInvoicesWithYear = FinalMeskenInvoices.Where(z => (z.InvoiceYear == year - 1 && z.InvoiceMounth >= 7)
																			  || (z.InvoiceYear == year &&  z.InvoiceMounth < 7)).ToList();

				FinalSanayiInvoicesWithYear = FinalSanayiInvoices.Where(z => (z.InvoiceYear == year - 1 && z.InvoiceMounth >= 7)
																			  || (z.InvoiceYear == year && z.InvoiceMounth < 7)).ToList();

				FinalOtherInvoicesWithYear = FinalOtherInvoices.Where(z => (z.InvoiceYear == year - 1 && z.InvoiceMounth >= 7)
																			  || (z.InvoiceYear == year && z.InvoiceMounth < 7)).ToList();
			}
			else
			{
				FinalMeskenInvoicesWithYear = FinalMeskenInvoices.Where(z => z.InvoiceYear == year).ToList();

				FinalSanayiInvoicesWithYear = FinalSanayiInvoices.Where(z => z.InvoiceYear == year).ToList();

				FinalOtherInvoicesWithYear = FinalOtherInvoices.Where(z => z.InvoiceYear == year).ToList();
			}


			MeskenSegmentleriniBulveSetle(year);
			SanayiSegmentleriniBulveSetle(year);
			DigerSegmentleriBulveSetle(year);

		}
		private void MeskenSegmentleriniBulveSetle(int year)
		{
			MeskenSegmentleri meskenSegmentleri = new MeskenSegmentleri();
			if (FinalMeskenInvoicesWithYear.Any(z => z.TotalConsumption < 1000))
			{
				meskenSegmentleri._kucuktur_1000kwh = true;
				meskenSegmentleri.Segment1ToplamTuketim = FinalMeskenInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption < 1000).ToList().Sum(x => x.TotalConsumption);
				meskenSegmentleri.Segment1ToplamTutar = FinalMeskenInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption < 1000).ToList().Sum(x => x.TotalAmount);

				meskenSegmentleri.ToplamTuketim += meskenSegmentleri.Segment1ToplamTuketim;
				meskenSegmentleri.ToplamTutar += meskenSegmentleri.Segment1ToplamTutar;
			}

			if (FinalMeskenInvoicesWithYear.Any(z => z.TotalConsumption >= 1000 && z.TotalConsumption < 2500))
			{
				meskenSegmentleri._1000_2500kwh = true;
				meskenSegmentleri.Segment2ToplamTuketim = FinalMeskenInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption >= 1000 && z.TotalConsumption < 2500).ToList().Sum(x => x.TotalConsumption);
				meskenSegmentleri.Segment2ToplamTutar = FinalMeskenInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption >= 1000 && z.TotalConsumption < 2500).ToList().Sum(x => x.TotalAmount);

				meskenSegmentleri.ToplamTuketim += meskenSegmentleri.Segment2ToplamTuketim;
				meskenSegmentleri.ToplamTutar += meskenSegmentleri.Segment2ToplamTutar;
			}

			if (FinalMeskenInvoicesWithYear.Any(z => z.TotalConsumption >= 2500 && z.TotalConsumption < 5000))
			{
				meskenSegmentleri._2500_5000kwh = true;
				meskenSegmentleri.Segment3ToplamTuketim = FinalMeskenInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption >= 2500 && z.TotalConsumption < 5000).ToList().Sum(x => x.TotalConsumption);
				meskenSegmentleri.Segment3ToplamTutar = FinalMeskenInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption >= 2500 && z.TotalConsumption < 5000).ToList().Sum(x => x.TotalAmount);

				meskenSegmentleri.ToplamTuketim += meskenSegmentleri.Segment3ToplamTuketim;
				meskenSegmentleri.ToplamTutar += meskenSegmentleri.Segment3ToplamTutar;
			}

			if (FinalMeskenInvoicesWithYear.Any(z => z.TotalConsumption >= 5000 && z.TotalConsumption < 15000))
			{
				meskenSegmentleri._5000_15000kwh = true;
				meskenSegmentleri.Segment4ToplamTuketim = FinalMeskenInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption >= 5000 && z.TotalConsumption < 15000).ToList().Sum(x => x.TotalConsumption);
				meskenSegmentleri.Segment4ToplamTutar = FinalMeskenInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption >= 5000 && z.TotalConsumption < 15000).ToList().Sum(x => x.TotalAmount);

				meskenSegmentleri.ToplamTuketim += meskenSegmentleri.Segment4ToplamTuketim;
				meskenSegmentleri.ToplamTutar += meskenSegmentleri.Segment4ToplamTutar;
			}

			if (FinalMeskenInvoicesWithYear.Any(z => z.TotalConsumption >= 15000))
			{
				meskenSegmentleri._buyuktur15000kwh = true;
				meskenSegmentleri.Segment5ToplamTuketim = FinalMeskenInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption >= 15000).ToList().Sum(x => x.TotalConsumption);
				meskenSegmentleri.Segment5ToplamTutar = FinalMeskenInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption >= 15000).ToList().Sum(x => x.TotalAmount);

				meskenSegmentleri.ToplamTuketim += meskenSegmentleri.Segment5ToplamTuketim;
				meskenSegmentleri.ToplamTutar += meskenSegmentleri.Segment5ToplamTutar;
			}

			MeskenDataGridViewDoldur(meskenSegmentleri);

		}
		private void MeskenDataGridViewDoldur(MeskenSegmentleri meskenSegmentleri)
		{
			DataTable table = new DataTable();
			table.Columns.Add("Mesken".ToString());
			table.Columns.Add("Tüketim".ToString());
			table.Columns.Add("Tutar".ToString());

			DataRow row;
			if (meskenSegmentleri._kucuktur_1000kwh)
			{
				row = table.NewRow();
				row["Mesken"] = "< 1000";
				row["Tüketim"] = meskenSegmentleri.Segment1ToplamTuketim;
				row["Tutar"] = meskenSegmentleri.Segment1ToplamTutar;
				table.Rows.Add(row);
			}
			if (meskenSegmentleri._1000_2500kwh)
			{
				row = table.NewRow();
				row["Mesken"] = "1000 - 2500";
				row["Tüketim"] = meskenSegmentleri.Segment2ToplamTuketim;
				row["Tutar"] = meskenSegmentleri.Segment2ToplamTutar;
				table.Rows.Add(row);
			}
			if (meskenSegmentleri._2500_5000kwh)
			{
				row = table.NewRow();
				row["Mesken"] = "2500 - 5000";
				row["Tüketim"] = meskenSegmentleri.Segment3ToplamTuketim;
				row["Tutar"] = meskenSegmentleri.Segment3ToplamTutar;
				table.Rows.Add(row);
			}
			if (meskenSegmentleri._5000_15000kwh)
			{
				row = table.NewRow();
				row["Mesken"] = "5000 - 15000";
				row["Tüketim"] = meskenSegmentleri.Segment4ToplamTuketim;
				row["Tutar"] = meskenSegmentleri.Segment4ToplamTutar;
				table.Rows.Add(row);
			}
			if (meskenSegmentleri._buyuktur15000kwh)
			{
				row = table.NewRow();
				row["Mesken"] = "15000 ve üzeri";
				row["Tüketim"] = meskenSegmentleri.Segment5ToplamTuketim;
				row["Tutar"] = meskenSegmentleri.Segment5ToplamTutar;
				table.Rows.Add(row);
			}

			row = table.NewRow();
			row["Mesken"] = "Toplam";
			row["Tüketim"] = meskenSegmentleri.ToplamTuketim;
			row["Tutar"] = meskenSegmentleri.ToplamTutar;
			table.Rows.Add(row);

			MeskenDataGridView.DataSource = table;
		}
		private void SanayiSegmentleriniBulveSetle(int year)
		{
			SanayiSegmentleri sanayiSegmentleri = new SanayiSegmentleri();
			if (FinalSanayiInvoicesWithYear.Any(z => z.TotalConsumption / 1000 < 20))
			{
				sanayiSegmentleri._kucuktur_20mwh = true;
				sanayiSegmentleri.Segment1ToplamTuketim = FinalSanayiInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption / 1000 < 20).ToList().Sum(x => x.TotalConsumption);
				sanayiSegmentleri.Segment1ToplamTutar = FinalSanayiInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption / 1000 < 20).ToList().Sum(x => x.TotalAmount);

				sanayiSegmentleri.ToplamTuketim += sanayiSegmentleri.Segment1ToplamTuketim;
				sanayiSegmentleri.ToplamTutar += sanayiSegmentleri.Segment1ToplamTutar;
			}

			if (FinalSanayiInvoicesWithYear.Any(z => z.TotalConsumption / 1000 >= 20 && z.TotalConsumption / 1000 < 500))
			{
				sanayiSegmentleri._20_500mwh = true;
				sanayiSegmentleri.Segment2ToplamTuketim = FinalSanayiInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption / 1000 >= 20 && z.TotalConsumption / 1000 < 500).ToList().Sum(x => x.TotalConsumption);
				sanayiSegmentleri.Segment2ToplamTutar = FinalSanayiInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption / 1000 >= 20 && z.TotalConsumption / 1000 < 500).ToList().Sum(x => x.TotalAmount);

				sanayiSegmentleri.ToplamTuketim += sanayiSegmentleri.Segment2ToplamTuketim;
				sanayiSegmentleri.ToplamTutar += sanayiSegmentleri.Segment2ToplamTutar;
			}

			if (FinalSanayiInvoicesWithYear.Any(z => z.TotalConsumption / 1000 >= 500 && z.TotalConsumption / 1000 < 2000))
			{
				sanayiSegmentleri._500_2000mwh = true;
				sanayiSegmentleri.Segment3ToplamTuketim = FinalSanayiInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption / 1000 >= 500 && z.TotalConsumption / 1000 < 2000).ToList().Sum(x => x.TotalConsumption);
				sanayiSegmentleri.Segment3ToplamTutar = FinalSanayiInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption / 1000 >= 500 && z.TotalConsumption / 1000 < 2000).ToList().Sum(x => x.TotalAmount);

				sanayiSegmentleri.ToplamTuketim += sanayiSegmentleri.Segment3ToplamTuketim;
				sanayiSegmentleri.ToplamTutar += sanayiSegmentleri.Segment3ToplamTutar;
			}

			if (FinalSanayiInvoicesWithYear.Any(z => z.TotalConsumption / 1000 >= 2000 && z.TotalConsumption / 1000 < 20000))
			{
				sanayiSegmentleri._2000_20000mwh = true;
				sanayiSegmentleri.Segment4ToplamTuketim = FinalSanayiInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption / 1000 >= 2000 && z.TotalConsumption / 1000 < 20000).ToList().Sum(x => x.TotalConsumption);
				sanayiSegmentleri.Segment4ToplamTutar = FinalSanayiInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption / 1000 >= 2000 && z.TotalConsumption / 1000 < 20000).ToList().Sum(x => x.TotalAmount);

				sanayiSegmentleri.ToplamTuketim += sanayiSegmentleri.Segment4ToplamTuketim;
				sanayiSegmentleri.ToplamTutar += sanayiSegmentleri.Segment4ToplamTutar;
			}

			if (FinalSanayiInvoicesWithYear.Any(z => z.TotalConsumption / 1000 >= 20000 && z.TotalConsumption / 1000 < 70000))
			{
				sanayiSegmentleri._20000_70000mwh = true;
				sanayiSegmentleri.Segment5ToplamTuketim = FinalSanayiInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption / 1000 >= 20000 && z.TotalConsumption / 1000 < 70000).ToList().Sum(x => x.TotalConsumption);
				sanayiSegmentleri.Segment5ToplamTutar = FinalSanayiInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption / 1000 >= 20000 && z.TotalConsumption / 1000 < 70000).ToList().Sum(x => x.TotalAmount);

				sanayiSegmentleri.ToplamTuketim += sanayiSegmentleri.Segment5ToplamTuketim;
				sanayiSegmentleri.ToplamTutar += sanayiSegmentleri.Segment5ToplamTutar;
			}

			if (FinalSanayiInvoicesWithYear.Any(z => z.TotalConsumption / 1000 >= 70000 && z.TotalConsumption / 1000 < 150000))
			{
				sanayiSegmentleri._70000_150000mwh = true;
				sanayiSegmentleri.Segment6ToplamTuketim = FinalSanayiInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption / 1000 >= 70000 && z.TotalConsumption / 1000 < 150000).ToList().Sum(x => x.TotalConsumption);
				sanayiSegmentleri.Segment6ToplamTutar = FinalSanayiInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption / 1000 >= 70000 && z.TotalConsumption / 1000 < 150000).ToList().Sum(x => x.TotalAmount);

				sanayiSegmentleri.ToplamTuketim += sanayiSegmentleri.Segment6ToplamTuketim;
				sanayiSegmentleri.ToplamTutar += sanayiSegmentleri.Segment6ToplamTutar;
			}

			if (FinalSanayiInvoicesWithYear.Any(z => z.TotalConsumption / 1000 >= 150000))
			{
				sanayiSegmentleri._buyuktur150000mwh = true;
				sanayiSegmentleri.Segment7ToplamTuketim = FinalSanayiInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption / 1000 >= 150000).ToList().Sum(x => x.TotalConsumption);
				sanayiSegmentleri.Segment7ToplamTutar = FinalSanayiInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption / 1000 >= 150000).ToList().Sum(x => x.TotalAmount);

				sanayiSegmentleri.ToplamTuketim += sanayiSegmentleri.Segment7ToplamTuketim;
				sanayiSegmentleri.ToplamTutar += sanayiSegmentleri.Segment7ToplamTutar;
			}
			SanayiDataGridViewDoldur(sanayiSegmentleri);

		}
		private void SanayiDataGridViewDoldur(SanayiSegmentleri sanayiSegmentleri)
		{
			DataTable table = new DataTable();
			table.Columns.Add("Sanayi".ToString());
			table.Columns.Add("Tüketim".ToString());
			table.Columns.Add("Tutar".ToString());

			DataRow row;
			if (sanayiSegmentleri._kucuktur_20mwh)
			{
				row = table.NewRow();
				row["Sanayi"] = "< 20";
				row["Tüketim"] = sanayiSegmentleri.Segment1ToplamTuketim;
				row["Tutar"] = sanayiSegmentleri.Segment1ToplamTutar;
				table.Rows.Add(row);
			}
			if (sanayiSegmentleri._20_500mwh)
			{
				row = table.NewRow();
				row["Sanayi"] = "20 - 500";
				row["Tüketim"] = sanayiSegmentleri.Segment2ToplamTuketim;
				row["Tutar"] = sanayiSegmentleri.Segment2ToplamTutar;
				table.Rows.Add(row);
			}
			if (sanayiSegmentleri._500_2000mwh)
			{
				row = table.NewRow();
				row["Sanayi"] = "500 - 2000";
				row["Tüketim"] = sanayiSegmentleri.Segment3ToplamTuketim;
				row["Tutar"] = sanayiSegmentleri.Segment3ToplamTutar;
				table.Rows.Add(row);
			}
			if (sanayiSegmentleri._2000_20000mwh)
			{
				row = table.NewRow();
				row["Sanayi"] = "2000 - 20000";
				row["Tüketim"] = sanayiSegmentleri.Segment4ToplamTuketim;
				row["Tutar"] = sanayiSegmentleri.Segment4ToplamTutar;
				table.Rows.Add(row);
			}
			if (sanayiSegmentleri._20000_70000mwh)
			{
				row = table.NewRow();
				row["Sanayi"] = "20000 - 70000";
				row["Tüketim"] = sanayiSegmentleri.Segment5ToplamTuketim;
				row["Tutar"] = sanayiSegmentleri.Segment5ToplamTutar;
				table.Rows.Add(row);
			}
			if (sanayiSegmentleri._70000_150000mwh)
			{
				row = table.NewRow();
				row["Sanayi"] = "70000 - 150000";
				row["Tüketim"] = sanayiSegmentleri.Segment6ToplamTuketim;
				row["Tutar"] = sanayiSegmentleri.Segment6ToplamTutar;
				table.Rows.Add(row);
			}
			if (sanayiSegmentleri._buyuktur150000mwh)
			{
				row = table.NewRow();
				row["Sanayi"] = "150000 ve üzeri";
				row["Tüketim"] = sanayiSegmentleri.Segment7ToplamTuketim;
				row["Tutar"] = sanayiSegmentleri.Segment7ToplamTutar;
				table.Rows.Add(row);
			}

			row = table.NewRow();
			row["Sanayi"] = "Toplam";
			row["Tüketim"] = sanayiSegmentleri.ToplamTuketim;
			row["Tutar"] = sanayiSegmentleri.ToplamTutar;
			table.Rows.Add(row);

			SanayiDataGridView.DataSource = table;
		}
		private void DigerSegmentleriBulveSetle(int year)
		{
			DigerSegmentleri digerSegmentleri = new DigerSegmentleri();
			if (FinalOtherInvoicesWithYear.Any(z => z.TotalConsumption / 1000 < 20))
			{
				digerSegmentleri._kucuktur_20mwh = true;
				digerSegmentleri.Segment1ToplamTuketim = FinalOtherInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption / 1000 < 20).ToList().Sum(x => x.TotalConsumption);
				digerSegmentleri.Segment1ToplamTutar = FinalOtherInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption / 1000 < 20).ToList().Sum(x => x.TotalAmount);

				digerSegmentleri.ToplamTuketim += digerSegmentleri.Segment1ToplamTuketim;
				digerSegmentleri.ToplamTutar += digerSegmentleri.Segment1ToplamTutar;
			}

			if (FinalOtherInvoicesWithYear.Any(z => z.TotalConsumption / 1000 >= 20 && z.TotalConsumption / 1000 < 500))
			{
				digerSegmentleri._20_500mwh = true;
				digerSegmentleri.Segment2ToplamTuketim = FinalOtherInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption / 1000 >= 20 && z.TotalConsumption / 1000 < 500).ToList().Sum(x => x.TotalConsumption);
				digerSegmentleri.Segment2ToplamTutar = FinalOtherInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption / 1000 >= 20 && z.TotalConsumption / 1000 < 500).ToList().Sum(x => x.TotalAmount);

				digerSegmentleri.ToplamTuketim += digerSegmentleri.Segment2ToplamTuketim;
				digerSegmentleri.ToplamTutar += digerSegmentleri.Segment2ToplamTutar;
			}

			if (FinalOtherInvoicesWithYear.Any(z => z.TotalConsumption / 1000 >= 500 && z.TotalConsumption / 1000 < 2000))
			{
				digerSegmentleri._500_2000mwh = true;
				digerSegmentleri.Segment3ToplamTuketim = FinalOtherInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption / 1000 >= 500 && z.TotalConsumption / 1000 < 2000).ToList().Sum(x => x.TotalConsumption);
				digerSegmentleri.Segment3ToplamTutar = FinalOtherInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption / 1000 >= 500 && z.TotalConsumption / 1000 < 2000).ToList().Sum(x => x.TotalAmount);

				digerSegmentleri.ToplamTuketim += digerSegmentleri.Segment3ToplamTuketim;
				digerSegmentleri.ToplamTutar += digerSegmentleri.Segment3ToplamTutar;
			}

			if (FinalOtherInvoicesWithYear.Any(z => z.TotalConsumption / 1000 >= 2000 && z.TotalConsumption / 1000 < 20000))
			{
				digerSegmentleri._2000_20000mwh = true;
				digerSegmentleri.Segment4ToplamTuketim = FinalOtherInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption / 1000 >= 2000 && z.TotalConsumption / 1000 < 20000).ToList().Sum(x => x.TotalConsumption);
				digerSegmentleri.Segment4ToplamTutar = FinalOtherInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption / 1000 >= 2000 && z.TotalConsumption / 1000 < 20000).ToList().Sum(x => x.TotalAmount);

				digerSegmentleri.ToplamTuketim += digerSegmentleri.Segment4ToplamTuketim;
				digerSegmentleri.ToplamTutar += digerSegmentleri.Segment4ToplamTutar;
			}

			if (FinalOtherInvoicesWithYear.Any(z => z.TotalConsumption / 1000 >= 20000 && z.TotalConsumption / 1000 < 70000))
			{
				digerSegmentleri._20000_70000mwh = true;
				digerSegmentleri.Segment5ToplamTuketim = FinalOtherInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption / 1000 >= 20000 && z.TotalConsumption / 1000 < 70000).ToList().Sum(x => x.TotalConsumption);
				digerSegmentleri.Segment5ToplamTutar = FinalOtherInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption / 1000 >= 20000 && z.TotalConsumption / 1000 < 70000).ToList().Sum(x => x.TotalAmount);

				digerSegmentleri.ToplamTuketim += digerSegmentleri.Segment5ToplamTuketim;
				digerSegmentleri.ToplamTutar += digerSegmentleri.Segment5ToplamTutar;
			}

			if (FinalOtherInvoicesWithYear.Any(z => z.TotalConsumption / 1000 >= 70000 && z.TotalConsumption / 1000 < 150000))
			{
				digerSegmentleri._70000_150000mwh = true;
				digerSegmentleri.Segment6ToplamTuketim = FinalOtherInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption / 1000 >= 70000 && z.TotalConsumption / 1000 < 150000).ToList().Sum(x => x.TotalConsumption);
				digerSegmentleri.Segment6ToplamTutar = FinalOtherInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption / 1000 >= 70000 && z.TotalConsumption / 1000 < 150000).ToList().Sum(x => x.TotalAmount);

				digerSegmentleri.ToplamTuketim += digerSegmentleri.Segment6ToplamTuketim;
				digerSegmentleri.ToplamTutar += digerSegmentleri.Segment6ToplamTutar;
			}

			if (FinalOtherInvoicesWithYear.Any(z => z.TotalConsumption / 1000 >= 150000))
			{
				digerSegmentleri._buyuktur150000mwh = true;
				digerSegmentleri.Segment7ToplamTuketim = FinalOtherInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption / 1000 >= 150000).ToList().Sum(x => x.TotalConsumption);
				digerSegmentleri.Segment7ToplamTutar = FinalOtherInvoicesWithYear.Where(z => z.InvoiceYear == year && z.TotalConsumption / 1000 >= 150000).ToList().Sum(x => x.TotalAmount);

				digerSegmentleri.ToplamTuketim += digerSegmentleri.Segment7ToplamTuketim;
				digerSegmentleri.ToplamTutar += digerSegmentleri.Segment7ToplamTutar;
			}
			DigerDataGridViewDoldur(digerSegmentleri);

		}
		private void DigerDataGridViewDoldur(DigerSegmentleri digerSegmentleri)
		{
			DataTable table = new DataTable();
			table.Columns.Add("Diger".ToString());
			table.Columns.Add("Tüketim".ToString());
			table.Columns.Add("Tutar".ToString());

			DataRow row;
			if (digerSegmentleri._kucuktur_20mwh)
			{
				row = table.NewRow();
				row["Diger"] = "< 20";
				row["Tüketim"] = digerSegmentleri.Segment1ToplamTuketim;
				row["Tutar"] = digerSegmentleri.Segment1ToplamTutar;
				table.Rows.Add(row);
			}
			if (digerSegmentleri._20_500mwh)
			{
				row = table.NewRow();
				row["Diger"] = "20 - 500";
				row["Tüketim"] = digerSegmentleri.Segment2ToplamTuketim;
				row["Tutar"] = digerSegmentleri.Segment2ToplamTutar;
				table.Rows.Add(row);
			}
			if (digerSegmentleri._500_2000mwh)
			{
				row = table.NewRow();
				row["Diger"] = "500 - 2000";
				row["Tüketim"] = digerSegmentleri.Segment3ToplamTuketim;
				row["Tutar"] = digerSegmentleri.Segment3ToplamTutar;
				table.Rows.Add(row);
			}
			if (digerSegmentleri._2000_20000mwh)
			{
				row = table.NewRow();
				row["Diger"] = "2000 - 20000";
				row["Tüketim"] = digerSegmentleri.Segment4ToplamTuketim;
				row["Tutar"] = digerSegmentleri.Segment4ToplamTutar;
				table.Rows.Add(row);
			}
			if (digerSegmentleri._20000_70000mwh)
			{
				row = table.NewRow();
				row["Diger"] = "20000 - 70000";
				row["Tüketim"] = digerSegmentleri.Segment5ToplamTuketim;
				row["Tutar"] = digerSegmentleri.Segment5ToplamTutar;
				table.Rows.Add(row);
			}
			if (digerSegmentleri._70000_150000mwh)
			{
				row = table.NewRow();
				row["Diger"] = "70000 - 150000";
				row["Tüketim"] = digerSegmentleri.Segment6ToplamTuketim;
				row["Tutar"] = digerSegmentleri.Segment6ToplamTutar;
				table.Rows.Add(row);
			}
			if (digerSegmentleri._buyuktur150000mwh)
			{
				row = table.NewRow();
				row["Diger"] = "150000 ve üzeri";
				row["Tüketim"] = digerSegmentleri.Segment7ToplamTuketim;
				row["Tutar"] = digerSegmentleri.Segment7ToplamTutar;
				table.Rows.Add(row);
			}
			row = table.NewRow();
			row["Diger"] = "Toplam";
			row["Tüketim"] = digerSegmentleri.ToplamTuketim;
			row["Tutar"] = digerSegmentleri.ToplamTutar;
			table.Rows.Add(row);

			DigerDataGridView.DataSource = table;
		}
	}
}
