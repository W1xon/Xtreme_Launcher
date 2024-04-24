using static Launcher_NFS_WPF_New.Model.FileManager;
namespace Launcher_NFS_WPF_New.Model
{
    internal class Params
    {
        public static string g_VSyncOn = "g_VSyncOn";
        public static string g_FSAALevel = "g_FSAALevel";
        public static string g_TextureFiltering = "g_TextureFiltering";
        public static string g_WorldLodLevel = "g_WorldLodLevel";
        public static string g_CarLodLevel = "g_CarLodLevel";
        public static string g_CarEnvironmentMapEnable = "g_CarEnvironmentMapEnable";
        public static string g_CarEnvironmentMapUpdateData = "g_CarEnvironmentMapUpdateData";
        public static string g_RoadReflectionEnable = "g_RoadReflectionEnable";
        public static string g_ShadowDetail = "g_ShadowDetail";
        public static string g_RainEnable = "g_RainEnable";
        public static string g_MotionBlurEnable = "g_MotionBlurEnable";
        public static string g_OverBrightEnable = "g_OverBrightEnable";
        public static string g_VisualTreatment = "g_VisualTreatment";
        public static string g_ParticleSystemEnable = "g_ParticleSystemEnable";

        public static void ChangeVSyncOn(int status)
        {
            ChangeParam(g_VSyncOn, status);
        }

        public static void ChangeFSAALevel(int status)
        {
            ChangeParam(g_FSAALevel, status);
        }

        public static void ChangeTextureFiltering(int status)
        {
            ChangeParam(g_TextureFiltering, status);
        }

        public static void ChangeWorldLodLevel(int status)
        {
            ChangeParam(g_WorldLodLevel, status);
        }

        public static void ChangeCarLodLevel(int status)
        {
            ChangeParam(g_CarLodLevel, status);
        }

        public static void ChangeCarEnvironmentMapEnable(int status)
        {
            ChangeParam(g_CarEnvironmentMapEnable, status);
        }

        public static void ChangeCarEnvironmentMapUpdateData(int status)
        {
            ChangeParam(g_CarEnvironmentMapUpdateData, status);
        }

        public static void ChangeRoadReflectionEnable(int status)
        {
            ChangeParam(g_RoadReflectionEnable, status);
        }

        public static void ChangeShadowDetail(int status)
        {
            ChangeParam(g_ShadowDetail, status);
        }

        public static void ChangeRainEnable(int status)
        {
            ChangeParam(g_RainEnable, status);
        }

        public static void ChangeMotionBlurEnable(int status)
        {
            ChangeParam(g_MotionBlurEnable, status);
        }

        public static void ChangeOverBrightEnable(int status)
        {
            ChangeParam(g_OverBrightEnable, status);
        }

        public static void ChangeVisualTreatment(int status)
        {
            ChangeParam(g_VisualTreatment, status);
        }
        public static void ChangeParticleSystemEnable(int status)
        {
            ChangeParam(g_ParticleSystemEnable, status);
        }
    }
}
