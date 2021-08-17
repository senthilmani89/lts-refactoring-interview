using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace RefactoringTest.ProductService
{
    public enum PromotionType
    {
        [Description("")]
        NoPromotion = 0,
        [Description("5PERCENTOFF")]
        FivePercentOffPromotion = 1,
        [Description("10PERCENTOFF")]
        TenPercentOffPromotion = 2,
        [Description("20PERCENTOFF")]
        TwentyPercentOffPromotion = 3

    }
}
