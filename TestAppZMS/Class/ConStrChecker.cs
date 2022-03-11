using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace TestAppZMS.Class
{
    public interface IConStrChecker
    {
        ConStrCheckerResult CheckCon(string conStr);

    }

    public class MssqlConStrChecker: IConStrChecker
    {
        public ConStrCheckerResult CheckCon(string conStr)
        {
            try
            {
                using var con = new SqlConnection(conStr);
                con.Open();
                con.Close();
                return new ConStrCheckerResult(true);
            }
            catch (Exception ex)
            {
                return new ConStrCheckerResult(false, ex);
            }
        }
    }

    public class ConStrCheckerResult
    {
        public ConStrCheckerResult(bool Result, Exception Ex = null)
        {
            this.Result = Result;
            this.Ex = Ex;
        }
        public bool Result { get; set; }
        public Exception Ex { get; set; }
    }

}
