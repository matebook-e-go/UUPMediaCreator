﻿using System.Linq;

namespace UUPDownload.DownloadRequest
{
    public class Version
    {
        public ulong MajorVersion { get; set; }
        public ulong MinorVersion { get; set; }
        public ulong Build { get; set; }
        public ulong Revision { get; set; }

        public Version(ulong MajorVersion = 0, ulong MinorVersion = 0, ulong Build = 0, ulong Revision = 0)
        {
            this.MajorVersion = MajorVersion;
            this.MinorVersion = MinorVersion;
            this.Build = Build;
            this.Revision = Revision;
        }

        public static Version Parse(string versionStr)
        {
            ulong[] verArray = versionStr.Split(".").Select(x => ulong.Parse(x)).ToArray();
            return new Version(verArray[0], verArray[1], verArray[2], verArray[3]);
        }

        public static bool TryParse(string versionStr, out Version? version)
        {
            version = null;
            try
            {
                version = Parse(versionStr);
                return true;
            }
            catch { return false; }
        }

        public override bool Equals(object obj)
        {
            if (obj is Version ver)
                return MajorVersion == ver.MajorVersion && MinorVersion == ver.MinorVersion && Build == ver.Build && Revision == ver.Revision;
            return false;
        }

        public override string ToString()
        {
            return $"{MajorVersion}.{MinorVersion}.{Build}.{Revision}";
        }

        public override int GetHashCode()
        {
            return MajorVersion.GetHashCode() ^ MinorVersion.GetHashCode() ^ Build.GetHashCode() + Revision.GetHashCode();
        }

        public bool GreaterOrEqualThan(object obj)
        {
            if (obj is Version ver)
                return MajorVersion >= ver.MajorVersion && MinorVersion >= ver.MinorVersion && Build >= ver.Build && Revision >= ver.Revision;
            return false;
        }

        public bool GreaterThan(object obj)
        {
            if (obj is Version ver)
                return !Equals(ver) && GreaterOrEqualThan(obj);
            return false;
        }

        public bool LessOrEqualThan(object obj)
        {
            if (obj is Version ver)
                return MajorVersion <= ver.MajorVersion && MinorVersion <= ver.MinorVersion && Build <= ver.Build && Revision <= ver.Revision;
            return false;
        }

        public bool LessThan(object obj)
        {
            if (obj is Version ver)
                return !Equals(ver) && LessOrEqualThan(obj);
            return false;
        }
    }
}
