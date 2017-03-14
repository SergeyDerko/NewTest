namespace WebClientMVC.Models
{
    public class User11
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Surname)}: {Surname}, {nameof(Patronymic)}: {Patronymic}";
        }
    }
}