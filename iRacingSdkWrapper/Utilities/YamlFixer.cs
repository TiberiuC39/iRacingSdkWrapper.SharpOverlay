using System.IO;
using System.Linq;
using System.Text;

namespace iRacingSdkWrapper.Utilities
{
    public static class YamlFixer
    {
        public static string Fix(string yaml)
        {
            return FixYaml(yaml);
        }

        private static string FixYaml(string yaml)
        {
            string correctedString = string.Empty;

            // Quick hack: if there's more than 1 colon ":" in a line, keep only the first
            using (var reader = new StringReader(yaml))
            {
                var builder = new StringBuilder();
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.Count(c => c == ':') > 1)
                    {
                        var chars = line.ToCharArray();
                        bool foundFirst = false;
                        for (int i = 0; i < chars.Length; i++)
                        {
                            var c = chars[i];
                            if (c == ':')
                            {
                                if (!foundFirst)
                                {
                                    foundFirst = true;
                                    continue;
                                }
                                chars[i] = '-';
                            }
                        }
                        line = new string(chars);
                    }
                    builder.AppendLine(line);
                }
                correctedString = builder.ToString();
            }

            // Incorrect setup info dump fix: remove the setup info
            var indexOfSetup = correctedString.IndexOf("CarSetup:");
            if (indexOfSetup > 0)
            {
                correctedString = correctedString.Substring(0, indexOfSetup);
            }

            return correctedString;
        }
    }
}
