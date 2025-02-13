using System.ComponentModel;

namespace Backend.Domain.Enums
{
    public enum MuseumEnvironment
    {
        /// <summary>
        /// The museum is entirely indoors.
        /// </summary>
        [Description("Indoor museum")]
        Indoor,

        /// <summary>
        /// The museum is entirely outdoors.
        /// </summary>
        [Description("Outdoor museum")]
        Outdoor,

        /// <summary>
        /// The museum has both indoor and outdoor sections.
        /// </summary>
        [Description("Museum with both indoor and outdoor areas")]
        IndoorAndOutdoor
    }
}
