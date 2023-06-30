namespace WinFormsCTech
{
    public class ResponsibleExecutor
    {
        public string Name { get; private set; }
        public uint RKKCount { get; private set; }
        public uint AppealCount { get; private set; }

        public ResponsibleExecutor(string name, uint rKKCount, uint appealCount)
        {
            Name = name;
            RKKCount = rKKCount;
            AppealCount = appealCount;
        }

        public ResponsibleExecutor(ResponsibleExecutor responsibleExecutor)
        {
            Name = responsibleExecutor.Name;
            RKKCount = responsibleExecutor.RKKCount;
            AppealCount = responsibleExecutor.AppealCount;
        }

        public void RKKCountIncrement()
        {
            RKKCount++;
        }

        public void AppealCountIncrement()
        {
            AppealCount++;
        }
    }
}
