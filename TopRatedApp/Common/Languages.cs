using System.Linq;
using TopRatedApp.Enums;
using TopRatedApp.Interfaces;

namespace TopRatedApp.Common
{
    public class Languages
    {
        public static ILanguage[] All = {
            new Language("ActionScript", "#882B0F", Color.White, SectionType.ActionScript),
            new Language("C",            "#555555", Color.White, SectionType.C           ),
            new Language("C#",           "#178600", Color.White, SectionType.CSharp      ),
            new Language("Cpp",          "#f34b7d", Color.White, SectionType.Cpp         ),
            new Language("Clojure",      "#db5855", Color.White, SectionType.Clojure     ),
            new Language("CoffeeScript", "#244776", Color.White, SectionType.CoffeeScript),
            new Language("Css",          "#563d7c", Color.White, SectionType.Css         ),
            new Language("Go",           "#375eab", Color.White, SectionType.Go          ),
            new Language("Haskell",      "#29b544", Color.White, SectionType.Haskell     ),
            new Language("Html",         "#e44b23", Color.White, SectionType.Html        ),
            new Language("Java",         "#b07219", Color.White, SectionType.Java        ),
            new Language("JavaScript",   "#f1e05a", Color.White, SectionType.JavaScript  ),
            new Language("Lua",          "#000080", Color.White, SectionType.Lua         ),
            new Language("Matlab",       "#bb92ac", Color.White, SectionType.Matlab      ),
            new Language("ObjC",         "#438eff", Color.White, SectionType.ObjC        ),
            new Language("Perl",         "#0298c3", Color.White, SectionType.Perl        ),
            new Language("Php",          "#4F5D95", Color.White, SectionType.Php         ),
            new Language("Python",       "#3572A5", Color.White, SectionType.Python      ),
            new Language("R",            "#198ce7", Color.White, SectionType.R           ),
            new Language("Ruby",         "#701516", Color.White, SectionType.Ruby        ),
            new Language("Scala",        "#DC322F", Color.White, SectionType.Scala       ),
            new Language("Shell",        "#89e051", Color.White, SectionType.Shell       ),
            new Language("Swift",        "#ffac45", Color.White, SectionType.Swift       ),
            new Language("Tex",          "#3D6117", Color.White, SectionType.Tex         ),
            new Language("Viml",         "#199f4b", Color.White, SectionType.TypeScript  ),
            new Language("TypeScript",   "#2b7489", Color.White, SectionType.Viml        )
        };

        public static ILanguage GetLangByName(string name)
        {
            return All.FirstOrDefault(l => l.Name.Equals(name));
        }

        public static ILanguage GetLangByType(SectionType sectionType)
        {
            return All.FirstOrDefault(l => l.SectionType.Equals(sectionType));
        }

    }
}