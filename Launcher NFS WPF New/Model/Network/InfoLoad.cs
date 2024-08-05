namespace Launcher_NFS.Model
{
    internal class InfoLoad
    {
        private long TotalWeight { get; }
        public long Size { get; set; }
        public int LoadFileCount { get; set; }
        public int FileCount { get; set; }
        public long CurrentSize { get; set; }
        public string FileName { get; set; }

        public InfoLoad(long totalWeightByte)
        {
            TotalWeight = totalWeightByte;
        }
        public InfoLoad(long totalWeightByte, int fileCount)
        {
            TotalWeight = totalWeightByte;
            FileCount = fileCount;
        }
        public string GetInfo()
        {
            return $"{Properties.Langs.Lang.infoLoadTextLoaded}: {Percent}% {Properties.Langs.Lang.infoLoadTextProgress}: {SizeMb}/{TotalWeightMb}Mb";
        }

        public string GetUpdateInfo()
        {
            return $"{Properties.Langs.Lang.infoLoadTextLoaded}: {PercentUpdate}% {Properties.Langs.Lang.infoLoadTextProgress}: {SizeUpdateMb}/{TotalWeightMb}Mb {Properties.Langs.Lang.infoLoadTextFiles}: {LoadFileCount}/{FileCount}";
        }
        private string SizeMb
        {
            get { return (CurrentSize / 1048576d).ToString("0.00"); }
        }
        private string SizeUpdateMb
        {
            get { return (Size / 1048576d).ToString("0.00"); }
        }


        private string TotalWeightMb
        {
            get { return (TotalWeight / 1048576d).ToString("0.00"); }
        }
        private string Percent
        {
            get { return (CurrentSize * 100d / TotalWeight).ToString("0.00"); }
        }
        private string PercentUpdate
        {
            get { return (Size * 100d / TotalWeight).ToString("0.00"); }
        }
    }
}