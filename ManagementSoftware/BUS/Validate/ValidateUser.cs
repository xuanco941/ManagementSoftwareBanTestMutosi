using System.Text;

namespace ManagementSoftware.BUS.Validate
{
    internal class ValidateUser
    {

        public static string FormatUsernamePassword(string usernameOrPassword)
        {
            //chữ thường và không có kí tự dấu, không có khoảng trống
             return utf8Convert(usernameOrPassword).ToLower().Replace(" ", string.Empty);
        }



        // chuyển tiếng việt có dấu thành không dấu
        private static string utf8Convert(string s)
        {
            string stFormD = s.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int ich = 0; ich < stFormD.Length; ich++)
            {
                System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[ich]);
                }
            }
            sb = sb.Replace('Đ', 'D');
            sb = sb.Replace('đ', 'd');
            return (sb.ToString().Normalize(NormalizationForm.FormD));
        }
    }
}
