namespace Solutions.Strings
{
    internal class Task_0165
    {
        // #Two Pointers #String

        public int CompareVersion(string version1, string version2)
        {
            var version1Parts = version1.Split('.');
            var version2Parts = version2.Split('.');
            var n = Math.Min(version1Parts.Length, version2Parts.Length);

            for (var i = 0; i < n; i++)
            {
                var v1 = int.Parse(version1Parts[i]);
                var v2 = int.Parse(version2Parts[i]);
                if (v1 > v2)
                    return 1;
                else if (v1 < v2) 
                    return -1;
            }

            if (version1Parts.Length == version2Parts.Length)
                return 0;

            if (version1Parts.Length == n)
                for (var i = n; i < version2Parts.Length; i++)
                    if (int.Parse(version2Parts[i]) != 0)
                        return -1;

            if (version2Parts.Length == n)
                for (var i = n; i < version1Parts.Length; i++)
                    if (int.Parse(version1Parts[i]) != 0)
                        return 1;

            return 0;
        }
    }
}
