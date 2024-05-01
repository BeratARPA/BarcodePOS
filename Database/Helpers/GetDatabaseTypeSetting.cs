namespace Database.Helpers
{
    public class GetDatabaseTypeSetting
    { 
        public static int Get()
        {
            return Properties.Settings.Default.DatabaseType;
        }
    }
}
