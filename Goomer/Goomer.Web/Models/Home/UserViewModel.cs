using Goomer.Data.Models;
using Goomer.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Goomer.Web.Models.Home
{
    public class UserViewModel : IMapFrom<User>
    {
        public string Name { get; set; }
    }
}