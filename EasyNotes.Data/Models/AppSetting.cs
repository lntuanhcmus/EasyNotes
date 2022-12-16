using EasyNotes.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyNotes.Data.Models
{
    public class AppSetting: EntityBaseWithTypedId<string>
    {
        public AppSetting()
        {

        }

        public AppSetting(string id)
        {
            Id = id;
        }
        public string Value { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }


    }
}
