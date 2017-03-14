namespace WebClientMVC.Models
{
    public class CalcModel
    {
        public double First { get; set; }
        public double Second { get; set; }
        public string Action { get; set; }

        public string Result()
        {
            string res = "";
            double result;
            switch (Action)
            {
                case "+":
                    result = (First + Second);
                    res = result.ToString();
                    break;
                case "-":
                    result = (First - Second);
                    res = result.ToString();
                    break;
                case "*":
                    result = (First * Second);
                    res = result.ToString();
                    break;
                case "/":
                    if (Second != 0)
                    {
                        result = (First / Second);
                        res = result.ToString();
                    }
                    else
                        res = "нельзя делить на 0!!!";
                    break;
                default:
                    res = "Выберите действие!";
                    break;

            }
            return res;
        }
    }
}