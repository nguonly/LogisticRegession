using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.Math;
using Accord.Statistics.Formats;
using ZedGraph;

namespace LogisticRegession
{
  public partial class Form1 : Form
  {
    private double[] _weight;
    string[] _sourceColumns;
    public Form1()
    {
      InitializeComponent();
    }


    public void CreateScatterplot(ZedGraphControl zgc, double[,] graph)
    {
      GraphPane myPane = zgc.GraphPane;
      myPane.CurveList.Clear();

      // Set the titles
      myPane.Title.IsVisible = false;
      myPane.XAxis.Title.Text = _sourceColumns[0];
      myPane.YAxis.Title.Text = _sourceColumns[1];


      // Classification problem
      PointPairList list1 = new PointPairList(); // Z = -1
      PointPairList list2 = new PointPairList(); // Z = +1
      for (int i = 0; i < graph.GetLength(0); i++)
      {
        if (graph[i, 2] == 0)
          list1.Add(graph[i, 0], graph[i, 1]);
        if (graph[i, 2] == 1)
          list2.Add(graph[i, 0], graph[i, 1]);
      }

      // Add the curve
      LineItem myCurve = myPane.AddCurve("G1", list1, Color.Blue, SymbolType.Diamond);
      myCurve.Line.IsVisible = false;
      myCurve.Symbol.Border.IsVisible = false;
      myCurve.Symbol.Fill = new Fill(Color.Blue);

      myCurve = myPane.AddCurve("G2", list2, Color.Green, SymbolType.Diamond);
      myCurve.Line.IsVisible = false;
      myCurve.Symbol.Border.IsVisible = false;
      myCurve.Symbol.Fill = new Fill(Color.Green);


      // Fill the background of the chart rect and pane
      //myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0f);
      //myPane.Fill = new Fill(Color.White, Color.SlateGray, 45.0f);
      myPane.Fill = new Fill(Color.WhiteSmoke);
      
      zgc.AxisChange();
      zgc.Invalidate();
    }

    public void CreateRegressPlot(ZedGraphControl zgc, double[,] graph, double[] weights)
    {
      GraphPane myPane = zgc.GraphPane;
      myPane.CurveList.Clear();

      // Set the titles
      myPane.Title.IsVisible = false;
      myPane.XAxis.Title.Text = _sourceColumns[0];
      myPane.YAxis.Title.Text = _sourceColumns[1];


      // Classification problem
      PointPairList list1 = new PointPairList(); // Z = -1
      PointPairList list2 = new PointPairList(); // Z = +1
      for (int i = 0; i < graph.GetLength(0); i++)
      {
        if (graph[i, 2] == 0)
          list1.Add(graph[i, 0], graph[i, 1]);
        if (graph[i, 2] == 1)
          list2.Add(graph[i, 0], graph[i, 1]);
      }

      // Add the curve
      LineItem myCurve = myPane.AddCurve("G1", list1, Color.Blue, SymbolType.Diamond);
      myCurve.Line.IsVisible = false;
      myCurve.Symbol.Border.IsVisible = false;
      myCurve.Symbol.Fill = new Fill(Color.Blue);

      myCurve = myPane.AddCurve("G2", list2, Color.Green, SymbolType.Diamond);
      myCurve.Line.IsVisible = false;
      myCurve.Symbol.Border.IsVisible = false;
      myCurve.Symbol.Fill = new Fill(Color.Green);

      var list3 = new PointPairList();
      for (var i = -3; i <= 3;i++ )
      {
        var y = -(weights[0] + weights[1]*i)/weights[2];
        list3.Add(i, y);
      }
      myCurve = myPane.AddCurve("L", list3, Color.Black, SymbolType.Circle);
      myCurve.Line.IsVisible = true;
        
          // Fill the background of the chart rect and pane
        //myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0f);
        //myPane.Fill = new Fill(Color.White, Color.SlateGray, 45.0f);
        myPane.Fill = new Fill(Color.WhiteSmoke);

      zgc.AxisChange();
      zgc.Invalidate();
    }

    private void btnOpen_Click_1(object sender, EventArgs e)
    {
      if (openFileDialog.ShowDialog(this) == DialogResult.OK)
      {
        string filename = openFileDialog.FileName;
        string extension = Path.GetExtension(filename);
        if (extension == ".xls" || extension == ".xlsx")
        {
          ExcelReader db = new ExcelReader(filename, true, false);
          TableSelectDialog t = new TableSelectDialog(db.GetWorksheetList());

          if (t.ShowDialog(this) == DialogResult.OK)
          {
            DataTable tableSource = db.GetWorksheet(t.Selection);

            double[,] sourceMatrix = tableSource.ToMatrix(out _sourceColumns);

            // Detect the kind of problem loaded.
            if (sourceMatrix.GetLength(1) == 2)
            {
              MessageBox.Show("Missing class column.");
            }
            else
            {
              this.dgvLearningSource.DataSource = tableSource;

              var inputs = sourceMatrix.Submatrix(0, sourceMatrix.GetLength(0) - 1, 1, 3);
              CreateScatterplot(graphInput, inputs);
            }
          }
        }
      }
    }

    private void btnAnalyze_Click(object sender, EventArgs e)
    {
      var regression = new LogisticRegression();

      double[,] sourceMatrix;
      double[,] inputs;
      double[] labels;

      GetData(out sourceMatrix, out inputs, out labels);

      _weight = regression.GradientAscent(inputs.ToArray(), labels);

      var aaa = sourceMatrix.Submatrix(0, sourceMatrix.GetLength(0) - 1, 1, 3);
      CreateRegressPlot(graphInput, aaa, _weight);
    }

    private void GetData(out double[, ] sourceMatrix, out double[,] inputs, out double[] lables)
    {
      sourceMatrix = (dgvLearningSource.DataSource as DataTable).ToMatrix(out _sourceColumns);
      var numCol = sourceMatrix.GetRow(0).Length;
      inputs = sourceMatrix.Submatrix(0, sourceMatrix.GetLength(0) - 1, 0, numCol - 2);

      //Get only the label outputs
      lables = new double[sourceMatrix.GetLength(0)];
      for(var i=0;i<lables.Length; i++)
      {
        lables[i] = (int)sourceMatrix[i, numCol-1];
      }
    }

    private void GetData(DataGridView dgv, out double[,] sourceMatrix, out double[,] inputs, out double[] lables)
    {
      sourceMatrix = (dgv.DataSource as DataTable).ToMatrix(out _sourceColumns);
      var numCol = sourceMatrix.GetRow(0).Length;
      inputs = sourceMatrix.Submatrix(0, sourceMatrix.GetLength(0) - 1, 0, numCol - 2);

      //Get only the label outputs
      lables = new double[sourceMatrix.GetLength(0)];
      for (var i = 0; i < lables.Length; i++)
      {
        lables[i] = (int)sourceMatrix[i, numCol - 1];
      }
    }

    private void cmdTest_Click(object sender, EventArgs e)
    {
      var x1 = Convert.ToDouble(txtX1.Text);
      var x2 = Convert.ToDouble(txtX2.Text);

      var input = new[]{1, x1,x2};
      var regression = new LogisticRegression();
      var cls = regression.Classify(input, _weight);
      var s = cls == 0.0 ? "Blue" : "Green";
      MessageBox.Show("Class = " + s);
    }

    private void btnStochastic0_Click(object sender, EventArgs e)
    {
      var regression = new LogisticRegression();

      double[,] sourceMatrix;
      double[,] inputs;
      double[] labels;

      GetData(out sourceMatrix, out inputs, out labels);

      _weight = regression.StochasticGradientAscent0(inputs.ToArray(), labels);

      var aaa = sourceMatrix.Submatrix(0, sourceMatrix.GetLength(0) - 1, 1, 3);
      CreateRegressPlot(graphInput, aaa, _weight);
    }

    private void btnStochastic1_Click(object sender, EventArgs e)
    {
      var regression = new LogisticRegression();

      double[,] sourceMatrix;
      double[,] inputs;
      double[] labels;

      GetData(out sourceMatrix, out inputs, out labels);

      _weight = regression.StochasticGradientAscent1(inputs.ToArray(), labels);

      var aaa = sourceMatrix.Submatrix(0, sourceMatrix.GetLength(0) - 1, 1, 3);
      CreateRegressPlot(graphInput, aaa, _weight);
    }

    private void btnHorseColic_Click(object sender, EventArgs e)
    {
      

      if (openFileDialog.ShowDialog(this) == DialogResult.OK)
      {
        string filename = openFileDialog.FileName;
        string extension = Path.GetExtension(filename);
        if (extension == ".xls" || extension == ".xlsx")
        {
          ExcelReader db = new ExcelReader(filename, true, false);
          TableSelectDialog t = new TableSelectDialog(db.GetWorksheetList());

          if (t.ShowDialog(this) == DialogResult.OK)
          {
            DataTable tableSource = db.GetWorksheet(t.Selection);

            double[,] sourceMatrix = tableSource.ToMatrix(out _sourceColumns);

            // Detect the kind of problem loaded.
            if (sourceMatrix.GetLength(1) == 2)
            {
              MessageBox.Show("Missing class column.");
            }
            else
            {
              this.dgvLearningSource.DataSource = tableSource;

              var testSource = db.GetWorksheet("HorseColicTest");
              this.dgvTest.DataSource = testSource;
              //var inputs = sourceMatrix.Submatrix(0, sourceMatrix.GetLength(0) - 1, 1, 3);
              //CreateScatterplot(graphInput, inputs);
            }
          }
        }
      }

      
      
    }

    private void btnHorseColicMultiTest_Click(object sender, EventArgs e)
    {
      var errorSum = 0.0;
      var numTest = 10;
      for (var i = 0; i < numTest; i++)
      {
        errorSum += HorseColicTest();
      }

      var errorRate = (double) errorSum/numTest;
      MessageBox.Show(string.Format("Average Test = {0}", errorRate));
    }

    private void btnHorseColicTest_Click(object sender, EventArgs e)
    {

      var errorRate = HorseColicTest();
      MessageBox.Show("Error Rate=" + errorRate);
    }

    private double HorseColicTest()
    {
      double[,] sourceMatrix;
      double[,] inputs;
      double[] labels;

      GetData(dgvTest, out sourceMatrix, out inputs, out labels);
      var regression = new LogisticRegression();
      _weight = regression.StochasticGradientAscent1(inputs.ToArray(), labels);
      var errorCount = 0;
      for (var i = 0; i < inputs.GetLength(0); i++)
      {
        var output = regression.Classify(inputs.GetRow(i), _weight);
        if (output != labels[i]) errorCount++;
      }
      var errorRate = (double)errorCount / inputs.GetLength(0);

      return errorRate;
    }

  }
}
