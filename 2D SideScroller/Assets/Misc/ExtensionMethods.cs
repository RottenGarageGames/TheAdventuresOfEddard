namespace Assets.Misc
{
    public static class ExtensionMethods
    {
        public static int ToInt(this bool value)
        {
            return value ? 1 : 0;
        }
    }
}
