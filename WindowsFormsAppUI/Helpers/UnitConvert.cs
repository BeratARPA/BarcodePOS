using System;

namespace WindowsFormsAppUI.Helpers
{
    public class UnitConvert
    {
        public static int MmToPixel(double mm)
        {
            mm = mm * 3.7795;
            return Convert.ToInt32(mm);
        }

        public static int PrintTypeToMM(PrintType printType)
        {
            return printType == PrintType.MM80 ? 80 : 58;
        }

        public static string UnitOfMeasureToString(int unitOfMeasureIndex)
        {
            switch (unitOfMeasureIndex)
            {
                case 0:
                    return "KG";
                case 1:
                    return "AD";
                case 2:
                    return "CL";
                default:
                    return "AD";                  
            }
        }
    }
}
