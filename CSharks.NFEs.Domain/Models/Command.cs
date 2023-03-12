using CSharks.NFEs.Domain.Models.NF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharks.NFEs.Domain.Models
{
    public class Command
    {
        public Guid Id { get; set; }

        [Column(TypeName = "varchar(32)")]
        public string CommandName { get; set; } = string.Empty;

        [Column(TypeName = "varchar(16)")]
        public string Shortcut { get; set; } = string.Empty;

        [Column(TypeName = "varchar(255)")]
        public string ServiceDescription { get; set; } = string.Empty;

        public Service Service { get; set; } = new Service();

        public Tomador? Tomador{ get; set; }
    }
}
