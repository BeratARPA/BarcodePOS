namespace Database.Helpers
{
    public class DatabaseTypeSettingHelper
    {
        public static int Get()
        {
            return Properties.Settings.Default.DatabaseType;
        }

        public static void Set(int parameter)
        {
            Properties.Settings.Default.DatabaseType = parameter;
            Properties.Settings.Default.Save();
        }
    }
}
