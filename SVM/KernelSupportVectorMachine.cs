using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Statistics.Kernels;

namespace LogisticRegession
{
  [Serializable]
  public class KernelSupportVectorMachine : SupportVectorMachine
  {

    private IKernel kernel;


    /// <summary>
    ///   Creates a new Kernel Support Vector Machine.
    /// </summary>
    /// 
    /// <param name="kernel">The chosen kernel for the machine.</param>
    /// <param name="inputs">The number of inputs for the machine.</param>
    /// 
    /// <remarks>
    ///   If the number of inputs is zero, this means the machine
    ///   accepts a indefinite number of inputs. This is often the
    ///   case for kernel vector machines using a sequence kernel.
    /// </remarks>
    /// 
    public KernelSupportVectorMachine(IKernel kernel, int inputs)
      : base(inputs)
    {
      if (kernel == null) throw new ArgumentNullException("kernel");

      this.kernel = kernel;
    }

    /// <summary>
    ///   Gets or sets the kernel used by this machine.
    /// </summary>
    /// 
    public IKernel Kernel
    {
      get { return kernel; }
      set { kernel = value; }
    }

    /// <summary>
    ///   Computes the given input to produce the corresponding output.
    /// </summary>
    /// 
    /// <remarks>
    ///   For a binary decision problem, the decision for the negative
    ///   or positive class is typically computed by taking the sign of
    ///   the machine's output.
    /// </remarks>
    /// 
    /// <param name="inputs">An input vector.</param>
    /// <returns>The output for the given input.</returns>
    /// 
    public override double Compute(double[] inputs)
    {
      double s = Threshold;

      for (int i = 0; i < SupportVectors.Length; i++)
      {
        var kernelFunc = kernel.Function(SupportVectors[i], inputs);
        s += Weights[i]*kernelFunc;
      }

      return s;
    }
  }
}
