using Goomer.Data.Models;
using Goomer.Web.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Goomer.Web.Areas.Administration.Models
{
    public class EditUserViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public bool IsDeleted { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsAdmin { get; set; }
    }
}