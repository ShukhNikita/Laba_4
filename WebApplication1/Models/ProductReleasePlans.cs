using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class ProductReleasePlans
    {
        public int Id { get; set; }

        public int CompanyId { get; set; }
        public int ProductionTypeId { get; set; }
        public ProductReleasePlans(int ProductionTypeId, int CompanyId, int YearInfo, int QuarterInfo,double ActualOutputVolume, double PlannedOutputVolume)
        {
            this.ProductionTypeId = ProductionTypeId;
            this.CompanyId = CompanyId;
            this.YearInfo = YearInfo;
            this.QuarterInfo = QuarterInfo;
            this.ActualOutputVolume = ActualOutputVolume;
            this.PlannedOutputVolume = PlannedOutputVolume;

        }
        public double PlannedOutputVolume { get; set; }

        public double ActualOutputVolume { get; set; }

        public int QuarterInfo { get; set; }

        public int YearInfo { get; set; }
    }
}
