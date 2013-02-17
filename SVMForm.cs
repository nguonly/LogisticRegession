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
using Accord.Statistics.Kernels;
using ZedGraph;

namespace LogisticRegession
{
  public partial class SVMForm : Form
  {
    private double[] _weight;
    string[] _sourceColumns;
    private SVM _svm;
    public SVMForm()
    {
      InitializeComponent();

      _svm = new SVM();
    }

    private void btnOpen_Click(object sender, EventArgs e)
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

              var inputs = sourceMatrix.Submatrix(0, sourceMatrix.GetLength(0) - 1, 0, 2);
              CreateScatterplot(graphInput, inputs);
            }
          }
        }
      }
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
        if (graph[i, 2] == -1)
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

    public void CreateScatterplot(ZedGraphControl zgc, double[,] graph, SupportVectorMachine svm)
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
        if (graph[i, 2] == -1)
          list1.Add(graph[i, 0], graph[i, 1]);
        if (graph[i, 2] == 1)
          list2.Add(graph[i, 0], graph[i, 1]);
      }

      var list3 = new PointPairList();
      var list_up = new PointPairList();
      var list_down = new PointPairList();
      double x, y = 0.0, y_down = 0.0,y_up = 0.0;
      for (var i = -2; i < 12; i++)
      {
        var a = -svm.Weights[0]/svm.Weights[1];
        y = a*i - svm.Threshold/svm.Weights[1];
        var b = svm.SupportVectorsTwoSides[0];
        y_up = a*i + (b[1] - a*b[0]);
        list3.Add(i, y);
        list_up.Add(i, y_up);

        b = svm.SupportVectorsTwoSides[1];
        y_down = a*i + (b[1] - a*b[0]);
        list_down.Add(i, y_down);
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

      myCurve = myPane.AddCurve("L", list3, Color.Black, SymbolType.Circle);
      myCurve.Line.IsVisible = true;

      myCurve = myPane.AddCurve("L", list_up, Color.Black, SymbolType.Circle);
      myCurve.Line.IsVisible = true;

      myCurve = myPane.AddCurve("L", list_down, Color.Black, SymbolType.Circle);
      myCurve.Line.IsVisible = true;

      // Fill the background of the chart rect and pane
      //myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0f);
      //myPane.Fill = new Fill(Color.White, Color.SlateGray, 45.0f);
      myPane.Fill = new Fill(Color.WhiteSmoke);

      zgc.AxisChange();
      zgc.Invalidate();
    }

    private void btnSimpleSMO_Click(object sender, EventArgs e)
    {
      double[,] sourceMatrix;
      double[,] inputs;
      int[] labels;

      GetData(out sourceMatrix, out inputs, out labels);

      //_svm.SimpleSMO(inputs, labels);
      // Perform classification
      SequentialMinimalOptimization smo;

      // Creates the Support Vector Machine using the selected kernel
      //svm = new KernelSupportVectorMachine(kernel, 2);
      SupportVectorMachine svm = new SupportVectorMachine(2);

      // Creates a new instance of the SMO Learning Algorithm
      smo = new SequentialMinimalOptimization(svm, inputs.ToArray(), labels);

      // Set learning parameters
      smo.Complexity =1.0;
      smo.Tolerance = 0.001;


      bool converged = true;

      try
      {
        // Run
        double error = smo.Run();
      }
      catch 
      {
        converged = false;
      }

      var a = sourceMatrix.Submatrix(0, sourceMatrix.GetLength(0) - 1, 0, 2);
      CreateScatterplot(graphInput, a, svm);
    }

    private void GetData(out double[,] sourceMatrix, out double[,] inputs, out int[] lables)
    {
      sourceMatrix = (dgvLearningSource.DataSource as DataTable).ToMatrix(out _sourceColumns);

      inputs = sourceMatrix.Submatrix(0, sourceMatrix.GetLength(0) - 1, 0, 1);

      //Get only the label outputs
      lables = new int[sourceMatrix.GetLength(0)];
      for (var i = 0; i < lables.Length; i++)
      {
        lables[i] = (int)sourceMatrix[i, 2];
      }
    }

    private void SVMForm_Load(object sender, EventArgs e)
    {
      
    }

    private void btnKernel_Click(object sender, EventArgs e)
    {
      double[,] sourceMatrix;
      double[,] inputs;
      int[] labels;

      GetData(out sourceMatrix, out inputs, out labels);

      //_svm.SimpleSMO(inputs, labels);
      // Perform classification
      SequentialMinimalOptimization smo;
      var kernel = new Gaussian(1.2236000);
      // Creates the Support Vector Machine using the selected kernel
      var svm = new KernelSupportVectorMachine(kernel, 2);
      //SupportVectorMachine svm = new SupportVectorMachine(2);

      // Creates a new instance of the SMO Learning Algorithm
      smo = new SequentialMinimalOptimization(svm, inputs.ToArray(), labels);

      // Set learning parameters
      smo.Complexity = 1.0;
      smo.Tolerance = 0.001;


      bool converged = true;

      try
      {
        // Run
        double error = smo.Run();
      }
      catch
      {
        converged = false;
      }

      //var a = sourceMatrix.Submatrix(0, sourceMatrix.GetLength(0) - 1, 0, 2);
      //CreateScatterplot(graphInput, a, svm);

      var ranges = Matrix.Range(sourceMatrix);
      double[][] map = Matrix.CartesianProduct(
          Matrix.Interval(ranges[0], 0.05),
          Matrix.Interval(ranges[1], 0.05));

      var result = map.Apply(svm.Compute).Apply(Math.Sign);

      var graph2 = map.ToMatrix().InsertColumn(result.ToDouble());

      CreateDecisionBoundaryplot(graphInput, graph2, sourceMatrix);
    }

    public void CreateKernelplot(ZedGraphControl zgc, double[,] graph, SupportVectorMachine svm)
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
        if (graph[i, 2] == -1)
          list1.Add(graph[i, 0], graph[i, 1]);
        if (graph[i, 2] == 1)
          list2.Add(graph[i, 0], graph[i, 1]);
      }

      var list3 = new PointPairList();
      var list_up = new PointPairList();
      var list_down = new PointPairList();
      double x, y = 0.0, y_down = 0.0, y_up = 0.0;
      for (var i = -2; i < 12; i++)
      {
        var a = -svm.Weights[0] / svm.Weights[1];
        y = a * i - svm.Threshold / svm.Weights[1];
        var b = svm.SupportVectorsTwoSides[0];
        y_up = a * i + (b[1] - a * b[0]);
        list3.Add(i, y);
        list_up.Add(i, y_up);

        b = svm.SupportVectorsTwoSides[1];
        y_down = a * i + (b[1] - a * b[0]);
        list_down.Add(i, y_down);
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

      myCurve = myPane.AddCurve("L", list3, Color.Black, SymbolType.Circle);
      myCurve.Line.IsVisible = true;

      myCurve = myPane.AddCurve("L", list_up, Color.Black, SymbolType.Circle);
      myCurve.Line.IsVisible = true;

      myCurve = myPane.AddCurve("L", list_down, Color.Black, SymbolType.Circle);
      myCurve.Line.IsVisible = true;

      // Fill the background of the chart rect and pane
      //myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0f);
      //myPane.Fill = new Fill(Color.White, Color.SlateGray, 45.0f);
      myPane.Fill = new Fill(Color.WhiteSmoke);

      zgc.AxisChange();
      zgc.Invalidate();
    }

    public void CreateDecisionBoundaryplot(ZedGraphControl zgc, double[,] graph, double[,] sourceMatrix)
    {
      GraphPane myPane = zgc.GraphPane;
      myPane.CurveList.Clear();

      // Set the titles
      myPane.Title.IsVisible = false;
      myPane.XAxis.Title.Text = _sourceColumns[0];
      myPane.YAxis.Title.Text = _sourceColumns[1];

      var list3 = new PointPairList();
      var list4 = new PointPairList();
      for (var i = 0; i < sourceMatrix.GetLength(0); i++)
      {
        if (sourceMatrix[i, 2] == -1) list3.Add(sourceMatrix[i, 0], sourceMatrix[i, 1]);
        if (sourceMatrix[i, 2] == 1) list4.Add(sourceMatrix[i, 0], sourceMatrix[i, 1]);

      }

      // Add the curve
      LineItem myCurve = myPane.AddCurve("G3", list3, Color.Blue, SymbolType.Diamond);
      myCurve.Line.IsVisible = false;
      myCurve.Symbol.Border.IsVisible = false;
      myCurve.Symbol.Fill = new Fill(Color.Blue);
      myCurve.Symbol.Size = 10;

      myCurve = myPane.AddCurve("G4", list4, Color.Red, SymbolType.Diamond);
      myCurve.Line.IsVisible = false;
      myCurve.Symbol.Border.IsVisible = false;
      myCurve.Symbol.Fill = new Fill(Color.Red);
      myCurve.Symbol.Size = 10;

      // Classification problem
      PointPairList list1 = new PointPairList(); // Z = -1
      PointPairList list2 = new PointPairList(); // Z = +1
      for (int i = 0; i < graph.GetLength(0); i++)
      {
        if (graph[i, 2] == -1)
          list1.Add(graph[i, 0], graph[i, 1]);
        if (graph[i, 2] == 1)
          list2.Add(graph[i, 0], graph[i, 1]);
      }

      // Add the curve
      myCurve = myPane.AddCurve("G1", list1, Color.Aqua, SymbolType.Diamond);
      myCurve.Line.IsVisible = false;
      myCurve.Symbol.Border.IsVisible = false;
      myCurve.Symbol.Fill = new Fill(Color.Aqua);

      myCurve = myPane.AddCurve("G2", list2, Color.Yellow, SymbolType.Diamond);
      myCurve.Line.IsVisible = false;
      myCurve.Symbol.Border.IsVisible = false;
      myCurve.Symbol.Fill = new Fill(Color.Yellow);



      // Fill the background of the chart rect and pane
      //myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0f);
      //myPane.Fill = new Fill(Color.White, Color.SlateGray, 45.0f);
      myPane.Fill = new Fill(Color.WhiteSmoke);

      zgc.AxisChange();
      zgc.Invalidate();
    }
  }
}
