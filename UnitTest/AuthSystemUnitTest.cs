using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAuthSystem.Application.DTOs.Account;

namespace UnitTest
{

    [TestClass]
    public class AccountController
    {
        [TestMethod]       
        private List<MetricStatisticDTO> GetStatictics()
        {
            var test = new List<MetricStatisticDTO>();
            test.Add(new MetricStatisticDTO { Id = '3A1A2E17-D31C-4EAD-895A-11A42A6311D9', startDate = "2021-11-19", endDate = "2021-11-19", metric="hour", isSuccess=true });
            test.Add(new MetricStatisticDTO { Id = '3A1A2E17-D31C-4EAD-895A-11A42A6311D9', startDate = "2021-11-19", endDate = "2021-11-19", metric= "month", isSuccess=true });
            test.Add(new MetricStatisticDTO { Id = '3A1A2E17-D31C-4EAD-895A-11A42A6311D9', startDate = "2021-11-19", endDate = "2021-11-19", metric= "year", isSuccess=true });
            
            return test;
        } 
        private List<UserLoginAttemptsDTO> GetUserLoginAttemptsByEmail()
        {
            var test = new List<MetricStatisticDTO>();
            test.Add(new MetricStatisticDTO {  email = "halfheart6767@yahoo.com"});
            test.Add(new MetricStatisticDTO {  email = "superadmin@gmail.com" });
            test.Add(new MetricStatisticDTO {  email = "basicuser@gmail.com" });
            
            return test;
        }
        private UserDTO generatesnewrandom()
        {
            var test = new UserDTO();
            test.Id= '3A1A2E17-D31C-4EAD-895A-11A42A6311D9'

            return test;
        }
    }
}
