using DataAccess;
using System;

namespace ConsloeUI
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderDetailDal orderDetailDal = new OrderDetailDal();
            orderDetailDal.GetAllByAll();
            
        }
    }
}
