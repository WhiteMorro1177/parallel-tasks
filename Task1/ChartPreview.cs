using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
	public partial class ChartPreview : Form
	{
		public ChartPreview()
		{
			InitializeComponent();
		}

		public ChartPreview(string title, List<double> values)
		{
			InitializeComponent();

			chart.Series.Clear();
			chart.Series.Add(title);

			foreach (double value in values)
			{
				chart.Series[title].Points.Add(value);
			}

		}
	}
}
