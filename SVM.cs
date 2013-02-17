using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Math;

namespace LogisticRegession
{
  public class SVM
  {

    public void SimpleSMO(double[,] dataMatrix, double[] classLabels)
    {
      var C = 0.6;
      var tolerance = 0.001;
      var maxIter = 40;
      double b = 0.0;
      var iter = 0;
      var m = dataMatrix.GetLength(0);
      var labelMat = classLabels.ToMatrix().Transpose();
      var alphas = (new double[m]).Add(1).ToMatrix().Transpose();
      double L, H;
      //while(iter<maxIter)
      //{
      //  var alphaPairsChanged = 0;

        for(var i=0;i<m;i++)
        {
      var wi = alphas.ElementwiseMultiply(labelMat).Transpose();
      var Xi = dataMatrix.Multiply(dataMatrix.GetRow(i).Transpose());
      var fXi = wi.Multiply(Xi).Trace() + b;
      var Ei = fXi - labelMat[i,0];
      var ri = labelMat[i, 0]*Ei;
      if((ri < -tolerance && alphas[i,0] < C) || (ri > tolerance && alphas[i,0] >0))
      {
        var j = selectJrand(i, m);
        var wj = alphas.ElementwiseMultiply(labelMat).Transpose();
        var Xj = dataMatrix.Multiply((dataMatrix.GetRow(j).Transpose()));
        var fXj = wj.Multiply(Xj).Trace() + b;
        var Ej = fXj - labelMat[j, 0];

        var alphasIold = alphas[i, 0];
        var alphasJold = alphas[j, 0];
        if(labelMat[i,0] != labelMat[j,0])
        {
          L = Math.Max(0, alphas[j, 0] - alphas[i, 0]);
          H = Math.Min(C, C + alphas[j, 0] - alphas[i, 0]);
        }else
        {
          L = Math.Max(0, alphas[j, 0] + alphas[i, 0] - C);
          H = Math.Min(C, alphas[j, 0] + alphas[i, 0]);
        }
        if(L==H) continue;

      }
        }
      //}

    }

    private int selectJrand(int i, int m)
    {
      var j = i;
      var rand = new Random();
      while(j==i)
      {
        j = rand.Next(0, m);
      }

      return j;
    }


  }
}
