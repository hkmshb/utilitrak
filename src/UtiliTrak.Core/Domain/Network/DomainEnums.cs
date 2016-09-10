namespace Hazeltek.UtiliTrak.Domain.Network
{
    public enum Voltage
    {
        None = 0,

        /// <summary>
        /// Represents 0.415KV
        /// </summary>
        LVOLT = 1,

        /// <summary>
        /// Represents 11KV
        /// </summary>
        MVOLTL = 2,

        /// <summary>
        /// Represents 33KV
        /// </summary>
        MVOLTH = 3,
        
        /// <summary>
        /// Represents 132KV
        /// </summary>
        HVOLTL = 4,

        /// <summary>
        /// Represents 330KV
        /// </summary>
        HVOLTH = 5
    }

    public enum VoltageRatio
    {
        None = 0,

        /// <summary>
        /// Represents 11/0.415KV
        /// </summary>
        MVOLTL_LVOLT  = 1, 

        /// <summary>
        /// Represents 33/0.415KV
        /// </summary>
        MVOLTH_LVOLT = 2,

        /// <summary>
        /// Represents 33/11KV
        /// </summary>
        MVOLTH_MVOLTL = 3,

        /// <summary>
        /// Represents 132/11KV
        /// </summary>
        HVOLTL_MVOLTL = 4,

        /// <summary>
        /// Represents 132/33KV
        /// </summary>
        HVOLTL_MVOLTH = 5,

        /// <summary>
        /// Represents 330/132KV
        /// </summary>
        HVOLTH_HVOLTL = 6
    }


    internal enum StationType
    {
        Transmission = 1,
        Injection    = 2,
        Distribution = 3
    }

    internal enum PowerLineType
    {
        Feeder  = 1,
        Upriser = 2
    }
}