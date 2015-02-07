namespace Boytrix.Logic.Business.Common
{
    public static class ExtensionMethods
    {
        public static bool IsNumericDatatype(this string obj)
        {
            switch (obj)
            {
                case "System.Boolean":
                case "System.Byte":
                case "System.SByte":
                case "System.UInt16":
                case "System.UInt32":
                case "System.UInt64":
                case "System.Int16":
                case "System.Int32":
                case "System.Int64":
                case "System.Decimal":
                case "System.Double":
                case "System.Single":
                    return true;
                default:
                    return false;
            }
        }
    }
}
