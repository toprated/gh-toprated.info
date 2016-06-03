using System.Diagnostics;
using System.Linq;
using TopRatedApp.Enums;
using TopRatedApp.Interfaces;

namespace TopRatedApp.Common
{
    public class Languages
    {
        public static ILanguage[] All = {
            new Language("ActionScript", "#882B0F", Color.White, Color.Black, SectionType.ActionScript),//+
            new Language("C",            "#555555", Color.White, Color.Black, SectionType.C           ),//+
            new Language("C#",           "#178600", Color.White, Color.Black, SectionType.CSharp      ),//+
            new Language("C++",          "#f34b7d", Color.White, Color.Black, SectionType.Cpp         ),//+
            new Language("Clojure",      "#db5855", Color.White, Color.Black, SectionType.Clojure     ),//+
            new Language("CoffeeScript", "#244776", Color.White, Color.Black, SectionType.CoffeeScript),//+
            new Language("CSS",          "#563d7c", Color.White, Color.Black, SectionType.Css         ),//+
            new Language("Go",           "#375eab", Color.White, Color.Black, SectionType.Go          ),//+
            new Language("Haskell",      "#29b544", Color.White, Color.Black, SectionType.Haskell     ),//+
            new Language("HTML",         "#e44b23", Color.White, Color.Black, SectionType.Html        ),//+
            new Language("Java",         "#b07219", Color.White, Color.Black, SectionType.Java        ),//+
            new Language("JavaScript",   "#f1e05a", Color.White, Color.Black, SectionType.JavaScript  ),//+
            new Language("Lua",          "#000080", Color.White, Color.Black, SectionType.Lua         ),//+
            new Language("Matlab",       "#bb92ac", Color.White, Color.Black, SectionType.Matlab      ),//+
            new Language("Objective-C",  "#438eff", Color.White, Color.Black, SectionType.ObjC        ),//+
            new Language("Perl",         "#0298c3", Color.White, Color.Black, SectionType.Perl        ),//+
            new Language("PHP",          "#4F5D95", Color.White, Color.Black, SectionType.Php         ),//+
            new Language("Python",       "#3572A5", Color.White, Color.Black, SectionType.Python      ),//+
            new Language("R",            "#198ce7", Color.White, Color.Black, SectionType.R           ),//+
            new Language("Ruby",         "#701516", Color.White, Color.Black, SectionType.Ruby        ),//+
            new Language("Scala",        "#DC322F", Color.White, Color.Black, SectionType.Scala       ),//+
            new Language("Shell",        "#89e051", Color.White, Color.Black, SectionType.Shell       ),//+
            new Language("Swift",        "#ffac45", Color.White, Color.Black, SectionType.Swift       ),//+
            new Language("TeX",          "#3D6117", Color.White, Color.Black, SectionType.Tex         ),//+
            new Language("VimL",         "#199f4b", Color.White, Color.Black, SectionType.TypeScript  ),//+
            new Language("TypeScript",   "#2b7489", Color.White, Color.Black, SectionType.Viml        )//+
        };

        public static ILanguage UnknownLanguage = new Language("Unknown", Color.Silver, Color.White, Color.Black,
            SectionType.Text);

        public static ILanguage GetLangByName(string name)
        {
            Debug.WriteLine($"Getting ILanguage: {name}");
            return All.FirstOrDefault(l => l.Name.Equals(name)) ?? UnknownLanguage;
        }

        public static ILanguage GetLangByType(SectionType sectionType)
        {
            return All.FirstOrDefault(l => l.SectionType.Equals(sectionType)) ?? UnknownLanguage;
        }

    }
}