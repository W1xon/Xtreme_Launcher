namespace Launcher_NFS.Model
{
    internal class InfoLoad
    {
        public long totalWeight;
        public long size;
        public int loadFileCount;
        public long currentSize;
        public string fileName;

        public InfoLoad(int totalWeightByte)
        {
            totalWeight = totalWeightByte;
        }
        public InfoLoad(int totalWeightByte, int loadFileCount)
        {
            totalWeight = totalWeightByte;
            this.loadFileCount = loadFileCount;
        }
        public string Percent
        {
            get { return (currentSize * 100 / totalWeight).ToString("0.00"); }
        }
        public string SizeMb
        {
            get { return (currentSize / 1048576d).ToString("0.00"); }
        }
        public string TotalWeightMb
        {
            get { return (totalWeight / 1048576d).ToString("0.00"); }
        }
    }
}