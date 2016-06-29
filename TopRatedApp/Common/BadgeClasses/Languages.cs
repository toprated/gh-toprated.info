using System.Diagnostics;
using System.Linq;
using TopRatedApp.Enums;
using TopRatedApp.Interfaces;

namespace TopRatedApp.Common.BadgeClasses
{
    public static class Languages
    {
        public static ILanguage[] All = {
            new Language("ActionScript", "ActionScript",  "ActionScript", "#882B0F", Color.White, Color.Black, SectionType.ActionScript, Octokit.Language.ActionScript),//+
            new Language("C",            "C",             "C",            "#555555", Color.White, Color.Black, SectionType.C           , Octokit.Language.C),//+
            new Language("C#",           "csharp",        "C%23",         "#178600", Color.White, Color.Black, SectionType.CSharp      , Octokit.Language.CSharp),//+
            new Language("C++",          "cpp",           "C%2B%2B",      "#f34b7d", Color.White, Color.Black, SectionType.Cpp         , Octokit.Language.CPlusPlus),//+
            new Language("Clojure",      "Clojure",       "Clojure",      "#db5855", Color.White, Color.Black, SectionType.Clojure     , Octokit.Language.Clojure),//+
            new Language("CoffeeScript", "CoffeeScript",  "CoffeeScript", "#244776", Color.White, Color.Black, SectionType.CoffeeScript, Octokit.Language.CoffeeScript),//+
            new Language("CSS",          "CSS",           "CSS",          "#563d7c", Color.White, Color.Black, SectionType.Css         , Octokit.Language.Css),//+
            new Language("Go",           "Go",            "Go",           "#375eab", Color.White, Color.Black, SectionType.Go          , Octokit.Language.Go),//+
            new Language("Haskell",      "Haskell",       "Haskell",      "#29b544", Color.White, Color.Black, SectionType.Haskell     , Octokit.Language.Haskell),//+
            new Language("HTML",         "HTML",          "HTML",         "#e44b23", Color.White, Color.Black, SectionType.Html        , Octokit.Language.Unknown),//+
            new Language("Java",         "Java",          "Java",         "#b07219", Color.White, Color.Black, SectionType.Java        , Octokit.Language.Java),//+
            new Language("JavaScript",   "JavaScript",    "JavaScript",   "#f1e05a", Color.White, Color.Black, SectionType.JavaScript  , Octokit.Language.JavaScript),//+
            new Language("Lua",          "Lua",           "Lua",          "#000080", Color.White, Color.Black, SectionType.Lua         , Octokit.Language.Lua),//+
            new Language("Matlab",       "Matlab",        "Matlab",       "#bb92ac", Color.White, Color.Black, SectionType.Matlab      , Octokit.Language.Matlab),//+
            new Language("Objective-C",  "Objective-C",   "Objective-C",  "#438eff", Color.White, Color.Black, SectionType.ObjC        , Octokit.Language.ObjectiveC),//+
            new Language("Perl",         "Perl",          "Perl",         "#0298c3", Color.White, Color.Black, SectionType.Perl        , Octokit.Language.Perl),//+
            new Language("PHP",          "PHP",           "PHP",          "#4F5D95", Color.White, Color.Black, SectionType.Php         , Octokit.Language.Php),//+
            new Language("Python",       "Python",        "Python",       "#3572A5", Color.White, Color.Black, SectionType.Python      , Octokit.Language.Python),//+
            new Language("R",            "R",             "R",            "#198ce7", Color.White, Color.Black, SectionType.R           , Octokit.Language.R),//+
            new Language("Ruby",         "Ruby",          "Ruby",         "#701516", Color.White, Color.Black, SectionType.Ruby        , Octokit.Language.Ruby),//+
            new Language("Scala",        "Scala",         "Scala",        "#DC322F", Color.White, Color.Black, SectionType.Scala       , Octokit.Language.Scala),//+
            new Language("Shell",        "Shell",         "Shell",        "#89e051", Color.White, Color.Black, SectionType.Shell       , Octokit.Language.Shell),//+
            new Language("Swift",        "Swift",         "Swift",        "#ffac45", Color.White, Color.Black, SectionType.Swift       , Octokit.Language.Unknown),//+
            new Language("TeX",          "TeX",           "TeX",          "#3D6117", Color.White, Color.Black, SectionType.Tex         , Octokit.Language.TeX),//+
            new Language("TypeScript",   "TypeScript",    "TypeScript",   "#2b7489", Color.White, Color.Black, SectionType.Viml        , Octokit.Language.TypeScript),//+
            new Language("VimL",         "VimL",          "VimL",         "#199f4b", Color.White, Color.Black, SectionType.TypeScript  , Octokit.Language.VimL),//+

            new Language("Unknown",      "", "Unknown",   Color.Silver, Color.Black, Color.White, SectionType.Text, Octokit.Language.Unknown)//+
        };

        public static ILanguage UnknownLanguage => All.First(l => l.Name.Equals("Unknown"));

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