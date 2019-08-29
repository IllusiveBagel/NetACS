using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;

namespace NetACS.Server.Services
{
    public class CalculatorService : ICalculatorService
    {
        public double Add(double x, double y) => x + y;
        public double Divide(double x, double y) => x / y;
        public double Multiply(double x, double y) => x * y;
        public double Subtract(double x, double y) => x - y;
    }

    [ServiceContract]
    public interface ICalculatorService
    {
        [OperationContract] double Add(double x, double y);
        [OperationContract] double Subtract(double x, double y);
        [OperationContract] double Multiply(double x, double y);
        [OperationContract] double Divide(double x, double y);
    }
}
