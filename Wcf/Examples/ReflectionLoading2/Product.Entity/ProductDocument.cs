using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Entity
{
    public class ProductDocument
    {
        public int DocumentId { get; set; }
        public String Title { get; set; }
        public String FileName { get; set; }
        public String FileExtension { get; set; }
        int Resision { get; set; }
        int ChangeNumber { get; set; }
        int Status { get; set; }
        String DocumentSummary { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}
