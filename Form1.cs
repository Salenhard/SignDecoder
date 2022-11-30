using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace Seti_1
{   
    public partial class Form1 : Form
    {
        Series PointsOfSings = new Series();
        private string makeGraph(string str)
        {
            string result = "";
            string previous = "0";
            string code;
            int i = 0;
            while (i < str.Length)
            {
                code = "";
                for (int k = 0; k < 4; k++)
                    code += str[i + k];

                if (code == "0000" && previous == "0000")
                {
                    previous = "";
                    result += "0-0";
                }
                if (code == "0000" && previous != "0000")
                {
                    result += "+0+";
                    previous = "0000";
                }
                if (code == "0001")
                {
                    result += "0−+";
                }
                if (code == "0010")
                {
                    result += "+-0";
                }
                if (code == "0011" && previous == "0011")
                {
                    result += "--0";
                    previous = "";
                }
                if (code == "0011" && previous != "0011")
                {
                    result += "00+";
                    previous = "0011";
                }
                if (code == "0100")
                {
                    result += "-+0";
                }
                if (code == "0101" && previous == "0101")
                {
                    result += "0++";
                    previous = "";
                }
                if (code == "0101" && previous != "0101")
                {
                    result += "-+0";
                    previous = "0101";
                }
                if (code == "0110" && previous == "0110")
                {
                    result += "--+";
                    previous = "";
                }
                if (code == "0110" && previous != "0110")
                {
                    result += "-++";
                    previous = "-++";
                }
                if (code == "0111")
                {
                    result += "-0+";
                }
                if (code == "1000" && previous == "1000")
                {
                    previous = "";
                    result += "0--";
                }
                if (code == "1000" && previous != "1000")
                {
                    result += "+00";
                    previous = "1000";
                }
                if (code == "1001" && previous == "1001")
                {
                    result += "---";
                    previous = "";
                }
                if (code == "1001" && previous != "1001")
                {
                    result += "+-+";
                    previous = "1001";
                }
                if (code == "1010" && previous == "1010")
                {
                    result += "++-";
                    previous = "";
                }
                if (code == "1010" && previous != "1010")
                {
                    result += "++-";
                    previous = "1010";
                }
                if (code == "1100" && previous == "1100")
                {
                    result += "-+-";
                    previous = "";
                }
                if (code == "1100" && previous != "1100")
                {
                    result += "+++";
                    previous = "1100";
                }
                if (code == "1101" && previous == "1101")
                {
                    result += "-0-";
                    previous = "";
                }
                if (code == "1101" && previous != "1101")
                {
                    result += "0+0";
                    previous = "1101";
                }
                if (code == "1110")
                {
                    result += "0+-";
                }
                if (code == "1111" && previous == "1111")
                {
                    result += "00-";
                    previous = "";
                }
                if (code == "1111" && previous != "1111")
                {
                    result += "++0";
                    previous = "1111";
                }
                i += 4;
            }
                return result;
        }


        private int getPoint(char symbol)
        {
            if (symbol == '0')
                return 5;
            if (symbol == '+')
                return 10;
            if (symbol == '-')
                return 0;

            return -10;
        }


        public Form1()
        {
            InitializeComponent();
            chart1.ChartAreas.Add(new ChartArea("Analog Signs"));
            PointsOfSings.Name = "Sings";
            PointsOfSings.ChartType = SeriesChartType.Line;
            PointsOfSings.ChartArea = "Analog Signs";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            chart1.Series.Clear();
            int num;
            int.TryParse(textBoxInputCode.Text, out num);
            if((textBoxInputCode.Text.Length) % 4 != 0) {
                label2.Text = "wrong size!";
                return;
            }
            for (int i = 0; i < makeGraph(textBoxInputCode.Text).Length; i++)
            {
                PointsOfSings.Points.AddXY(i, getPoint(makeGraph(textBoxInputCode.Text)[i]));
                if (i < makeGraph(textBoxInputCode.Text).Length - 1)
                {
                    if (getPoint(makeGraph(textBoxInputCode.Text)[i + 1]) == 5)
                        PointsOfSings.Points.AddXY(i, 5);
                    if (getPoint(makeGraph(textBoxInputCode.Text)[i + 1]) == 0)
                        PointsOfSings.Points.AddXY(i, 0);
                    if (getPoint(makeGraph(textBoxInputCode.Text)[i + 1]) == 10)
                        PointsOfSings.Points.AddXY(i, 10);
                }
            }
            
            chart1.Series.Add(PointsOfSings);
        }
    }
}
