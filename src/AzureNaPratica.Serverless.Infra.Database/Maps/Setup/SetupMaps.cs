using AzureNaPratica.Serverless.Infra.Database.Maps.Base;

namespace AzureNaPratica.Serverless.Infra.Database.Maps.Setup
{
    public static class SetupMaps
    {
        public static void ConfigureMaps()
        {
            BaseEventMap.Configure();
            BaseEntityMap.Configure();
            BaseEntityIdMap.Configure();


            CourseMap.Configure();
            StudentMap.Configure();
        }
    }
}
