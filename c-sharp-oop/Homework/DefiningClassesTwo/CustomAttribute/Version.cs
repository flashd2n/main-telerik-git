using System;

namespace CustomAttribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface | AttributeTargets.Enum | AttributeTargets.Method)]
    public class Version : Attribute
    {
        private double fullVersion;

        public Version(double version)
        {
            this.FullVersion = version;
        }

        public double FullVersion
        {
            get { return this.fullVersion; }
            private set { this.fullVersion = value; }
        }
    }
}
