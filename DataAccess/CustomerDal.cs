using DataAccess.Abstract;
using Entities;
using System;
using System.Data;
using System.Data.SqlClient;
using Xceed.Wpf.Toolkit;

namespace DataAccess
{
    public  class CustomerDal : EntityRepository<Customer, BupaAcıbademDatabase>, ICustomerDal
    {

    }

}
