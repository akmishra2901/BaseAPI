using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseAPI.BusinessServices.Interface;

namespace BaseAPI.BusinessServices
{
    public class BaseService : IBaseService
    {
        public BaseService() {

        }

        public dynamic GetBaseTestResult() {

            return new
            {
               Id = 1,
               Name = "Ashish",
               Age = 30,
               Mobile= "9911770292"
            };
        }
    }
}
