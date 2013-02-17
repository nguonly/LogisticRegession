using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Math;

namespace LogisticRegession
{
  public class LogisticRegression
  {

    public double[] Compute(double[] input)
    {
      double[] logit = new double[input.Length];

      for(var i=0;i<input.Length;i++)
      {
        logit[i] = Sigmoid(input[i]);
      }

      return logit;
    }

    public double Sigmoid(double x)
    {
      return 1.0/(1.0 + Math.Exp(-x));
    }

    public double Sigmoid(double[] input, double[] weight)
    {
      double sum = 0;
      for (var i = 0; i < input.Length; i++)
      {
        var mbox = input[i] * weight[i];
        sum += mbox;
      }
      var prob = Sigmoid(sum);

      return prob;
    }

    public double[] GradientAscent(double[][] inputs, double[] outputs)
    {
      var maxCycle = 500;
      var errors = new double[inputs.Length];
      var weights = new double[inputs[0].Length];

      weights = weights.Add(1); // add 1 to vector
      
      var alpha = 0.001;
      for(var k=0;k<maxCycle;k++)
      {
        var h = Compute(inputs.Multiply(weights));
        errors = outputs.Subtract(h);
        weights = weights.Add(alpha.Multiply(inputs.Transpose().Multiply(errors)));
      }

      return weights;
    }

    public double Classify(double[] input, double[] weight)
    {
      var prob = Sigmoid(input, weight);
      return prob>0.5? 1.0:0.0;
    }

    public double[] StochasticGradientAscent0(double[][] inputs, double[] outputs)
    {
      var weights = new double[inputs[0].Length];

      weights = weights.Add(1);

      const double alpha = 0.01;
      for (var k = 0; k < inputs.Length; k++)
      {
        var h = Sigmoid(inputs[k], weights);
        var error = outputs[k] - h ;
        weights = weights.Add(inputs[k].Multiply(alpha*error));
      }

      return weights;
    }

    public double[] StochasticGradientAscent1(double[][] inputs, double[] outputs, int maxCycle=150)
    {
      var rand = new Random();
      var weights = new double[inputs[0].Length];

      weights = weights.Add(1); //Sum 1 to vector
      for(var j = 0;j<maxCycle;j++)
      {
        var dataIndex = new List<int>();
        dataIndex.AddRange(Enumerable.Range(0, inputs.Length));
        
        for(var i=0;i<inputs.Length;i++)
        {
          var alpha = 4/(1.0 + j + i) + 0.0001;
          var rankIndex = rand.Next(0, dataIndex.Count); //Random
          var idx = dataIndex[rankIndex];
          var h = Sigmoid(inputs[idx], weights);
          var error = outputs[idx] - h;
          weights = weights.Add(inputs[idx].Multiply(alpha*error));

          //Delete form dataIndex
          dataIndex.RemoveAt(rankIndex);
        }
      }

      return weights;
    }
  }
}
