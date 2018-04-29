using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public interface IService
    {
        int servicID
        {
            get;
            set;
        }


        string serviceName
        {
            get;
            set;
        }

        string serviceType
        {
            get;
            set;
        }

        string City
        {
            get;
            set;
        }

        string country
        {
            get;
            set;
        }

        int Add(IService service);
        int Edit(int serviceID, IService service);
        int Delete(int serviceID);

    }
}
