using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatRate.Model
{
    class MultiTaskEditDescriptor
    {
        public bool IsCategoryChanging { get; set; }
        public int CategoryId { get; set; }
        public int SubcategoryId { get; set; }
        public bool IsHoursChanging { get; set; }
        public bool IsHoursAdditive { get; set; }
        public float Hours { get; set; }
        public bool IsStandardChanging { get; set; }
        public bool IsStandardAdditive { get; set; }
        public float StandardAddOn { get; set; }
        public bool IsPremiumChanging { get; set; }
        public bool IsPremiumAdditive { get; set; }
        public float PremiumAddOn { get; set; }

        public MultiTaskEditDescriptor()
        {
            IsCategoryChanging = false;
            IsHoursChanging = false;
            IsHoursAdditive = false;
            IsStandardChanging = false;
            IsStandardAdditive = false;
            IsPremiumChanging = false;
            IsPremiumAdditive = false;
        }
    }
}
