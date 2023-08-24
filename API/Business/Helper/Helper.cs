namespace API.Business.Helper
{
    public class Helper
    {
        public static string ConvertToMoney<T>(T input)
        {
            string money = string.Format("đ{0:N0}", input).Replace(",", ".");
            return money;
        }
    }
}
