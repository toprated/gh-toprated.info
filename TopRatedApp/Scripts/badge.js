var BuildType;
(function (BuildType) {
    BuildType[BuildType["Full"] = 0] = "Full";
    BuildType[BuildType["InsideSvg"] = 1] = "InsideSvg";
})(BuildType || (BuildType = {}));
var SectionPosition;
(function (SectionPosition) {
    SectionPosition[SectionPosition["Left"] = 0] = "Left";
    SectionPosition[SectionPosition["Right"] = 1] = "Right";
    SectionPosition[SectionPosition["Middle"] = 2] = "Middle";
})(SectionPosition || (SectionPosition = {}));
var SectionType;
(function (SectionType) {
    SectionType[SectionType["Text"] = 0] = "Text";
    SectionType[SectionType["Triangle"] = 1] = "Triangle";
    SectionType[SectionType["ActionScript"] = 2] = "ActionScript";
    SectionType[SectionType["C"] = 3] = "C";
    SectionType[SectionType["CSharp"] = 4] = "CSharp";
    SectionType[SectionType["Cpp"] = 5] = "Cpp";
    SectionType[SectionType["Clojure"] = 6] = "Clojure";
    SectionType[SectionType["CoffeeScript"] = 7] = "CoffeeScript";
    SectionType[SectionType["Css"] = 8] = "Css";
    SectionType[SectionType["Go"] = 9] = "Go";
    SectionType[SectionType["Haskell"] = 10] = "Haskell";
    SectionType[SectionType["Html"] = 11] = "Html";
    SectionType[SectionType["Java"] = 12] = "Java";
    SectionType[SectionType["JavaScript"] = 13] = "JavaScript";
    SectionType[SectionType["Lua"] = 14] = "Lua";
    SectionType[SectionType["Matlab"] = 15] = "Matlab";
    SectionType[SectionType["ObjC"] = 16] = "ObjC";
    SectionType[SectionType["Perl"] = 17] = "Perl";
    SectionType[SectionType["Php"] = 18] = "Php";
    SectionType[SectionType["Python"] = 19] = "Python";
    SectionType[SectionType["R"] = 20] = "R";
    SectionType[SectionType["Ruby"] = 21] = "Ruby";
    SectionType[SectionType["Scala"] = 22] = "Scala";
    SectionType[SectionType["Shell"] = 23] = "Shell";
    SectionType[SectionType["Swift"] = 24] = "Swift";
    SectionType[SectionType["Tex"] = 25] = "Tex";
    SectionType[SectionType["TypeScript"] = 26] = "TypeScript";
    SectionType[SectionType["Viml"] = 27] = "Viml";
})(SectionType || (SectionType = {}));
var Theme;
(function (Theme) {
    Theme[Theme["Light"] = 0] = "Light";
    Theme[Theme["Dark"] = 1] = "Dark";
    Theme[Theme["Custom"] = 2] = "Custom";
})(Theme || (Theme = {}));
class Color {
}
Color.silver = "#f2f2f2";
Color.darkGrey = "#595959";
Color.gray = "#808080";
Color.white = "#FFF";
Color.black = "#000";
Color.gold = "#FFD700";
class FontStyle {
    constructor(fFamily, fSize, fColor, fShadowColor) {
        this.fontFamily = fFamily;
        this.fontSize = fSize;
        this.fontColor = fColor;
        this.fontShadowColor = fShadowColor;
    }
}
class SectionStyle {
    constructor(fStyle, bcgColor) {
        this.fontStyle = fStyle;
        this.backgroundColor = bcgColor;
    }
}
class BadgeStyle {
    constructor() {
        this.indent = 5;
        this.radius = 3;
        const commonFontStyle = new FontStyle("Verdana", 11, Color.black, Color.gray);
        const commonBcgColor = Color.silver;
        this.commonTextStyle = new SectionStyle(commonFontStyle, commonBcgColor);
    }
}
class DarkBadgeStyle {
    constructor() {
        this.indent = 5;
        this.radius = 3;
        const commonFontStyle = new FontStyle("DejaVu Sans,Verdana,Geneva,sans-serif", 11, Color.white, Color.black);
        const commonBcgColor = Color.darkGrey;
        this.commonTextStyle = new SectionStyle(commonFontStyle, commonBcgColor);
    }
}
class Languages {
    static getLangByName(langName) {
        return this.all.find(l => l.name === langName);
    }
    static getLangByType(sectionType) {
        return this.all.find(l => l.sectionType === sectionType);
    }
}
Languages.all = [
    { name: "ActionScript", color: "#882B0F", textColor: Color.white, sectionType: SectionType.ActionScript },
    { name: "C", color: "#555555", textColor: Color.white, sectionType: SectionType.C },
    { name: "C#", color: "#178600", textColor: Color.white, sectionType: SectionType.CSharp },
    { name: "Cpp", color: "#f34b7d", textColor: Color.white, sectionType: SectionType.Cpp },
    { name: "Clojure", color: "#db5855", textColor: Color.white, sectionType: SectionType.Clojure },
    { name: "CoffeeScript", color: "#244776", textColor: Color.white, sectionType: SectionType.CoffeeScript },
    { name: "Css", color: "#563d7c", textColor: Color.white, sectionType: SectionType.Css },
    { name: "Go", color: "#375eab", textColor: Color.white, sectionType: SectionType.Go },
    { name: "Haskell", color: "#29b544", textColor: Color.white, sectionType: SectionType.Haskell },
    { name: "Html", color: "#e44b23", textColor: Color.white, sectionType: SectionType.Html },
    { name: "Java", color: "#b07219", textColor: Color.white, sectionType: SectionType.Java },
    { name: "JavaScript", color: "#f1e05a", textColor: Color.white, sectionType: SectionType.JavaScript },
    { name: "Lua", color: "#000080", textColor: Color.white, sectionType: SectionType.Lua },
    { name: "Matlab", color: "#bb92ac", textColor: Color.white, sectionType: SectionType.Matlab },
    { name: "ObjC", color: "#438eff", textColor: Color.white, sectionType: SectionType.ObjC },
    { name: "Perl", color: "#0298c3", textColor: Color.white, sectionType: SectionType.Perl },
    { name: "Php", color: "#4F5D95", textColor: Color.white, sectionType: SectionType.Php },
    { name: "Python", color: "#3572A5", textColor: Color.white, sectionType: SectionType.Python },
    { name: "R", color: "#198ce7", textColor: Color.white, sectionType: SectionType.R },
    { name: "Ruby", color: "#701516", textColor: Color.white, sectionType: SectionType.Ruby },
    { name: "Scala", color: "#DC322F", textColor: Color.white, sectionType: SectionType.Scala },
    { name: "Shell", color: "#89e051", textColor: Color.white, sectionType: SectionType.Shell },
    { name: "Swift", color: "#ffac45", textColor: Color.white, sectionType: SectionType.Swift },
    { name: "Tex", color: "#3D6117", textColor: Color.white, sectionType: SectionType.Tex },
    { name: "Viml", color: "#199f4b", textColor: Color.white, sectionType: SectionType.TypeScript },
    { name: "TypeScript", color: "#2b7489", textColor: Color.white, sectionType: SectionType.Viml }
];
class LightBadgeStyle {
    constructor() {
        this.indent = 5;
        this.radius = 3;
        const commonFontStyle = new FontStyle("DejaVu Sans,Verdana,Geneva,sans-serif", 11, Color.black, Color.gray);
        const commonBcgColor = Color.silver;
        this.commonTextStyle = new SectionStyle(commonFontStyle, commonBcgColor);
    }
}
class UrlHelper {
    getParameter(name) {
        name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
        const regexS = `[\\?&]${name}=([^&#]*)`;
        const regex = new RegExp(regexS);
        const results = regex.exec(window.location.href);
        if (results == null)
            return "";
        else
            return results[1];
    }
    getTheme() {
        const themeString = this.getParameter("theme");
        switch (themeString) {
            case "dark":
                return Theme.Dark;
            case "light":
                return Theme.Light;
            default:
                return Theme.Light;
        }
    }
    getUserName() {
        return this.getParameter("user");
    }
    getRepoName() {
        return this.getParameter("repo");
    }
}
HTMLElement.prototype.setWidth = function (value) {
    this.setAttribute("width", String(value));
    return this;
};
HTMLElement.prototype.setHeight = function (value) {
    this.setAttribute("height", String(value));
    return this;
};
SVGSVGElement.prototype.setWidth = function (value) {
    this.setAttribute("width", String(value));
    return this;
};
SVGSVGElement.prototype.setHeight = function (value) {
    this.setAttribute("height", String(value));
    return this;
};
SVGTextElement.prototype.setX = function (value) {
    this.setAttribute("x", String(value));
    return this;
};
SVGTextElement.prototype.setY = function (value) {
    this.setAttribute("y", String(value));
    return this;
};
SVGTextElement.prototype.fontFamily = function (value) {
    this.setAttribute("font-family", value);
    return this;
};
SVGTextElement.prototype.fontSize = function (value) {
    this.setAttribute("font-size", String(value));
    return this;
};
SVGTextElement.prototype.fill = function (value) {
    this.setAttribute("fill", value);
    return this;
};
SVGTextElement.prototype.fillOpacity = function (value) {
    this.setAttribute("fill-opacity", value);
    return this;
};
SVGTextElement.prototype.getTextRect = function (caller = undefined) {
    const el = this;
    let rect;
    const svg = document.createElementNS("http://www.w3.org/2000/svg", "svg");
    svg.appendChild(el);
    if (document.body === null) {
        document.getElementById(caller.id).appendChild(svg);
        rect = el.getBBox();
        document.getElementById(caller.id).removeChild(svg);
    }
    else {
        document.body.appendChild(svg);
        rect = el.getBBox();
        document.body.removeChild(svg);
    }
    return rect;
};
    SVGRectElement.prototype.setX = function (value) {
        this.setAttribute("x", String(value));
        return this;
    };
    SVGRectElement.prototype.setY = function (value) {
        this.setAttribute("y", String(value));
        return this;
    };
    SVGRectElement.prototype.setRx = function (value) {
        this.setAttribute("rx", String(value));
        return this;
    };
    SVGRectElement.prototype.setRy = function (value) {
        this.setAttribute("ry", String(value));
        return this;
    };
    SVGRectElement.prototype.setR = function (value) {
        this
            .setRx(value)
            .setRy(value);
        return this;
    };
    SVGRectElement.prototype.setWidth = function (value) {
        this.setAttribute("width", String(value));
        return this;
    };
    SVGRectElement.prototype.setHeight = function (value) {
        this.setAttribute("height", String(value));
        return this;
    };
    SVGRectElement.prototype.fill = function (value) {
        this.setAttribute("fill", value);
        return this;
    };
    class SvgTextElementHelper {
        constructor(el) {
            this.e = el;
            this.txt = el.textContent;
            this.fontname = el.getAttribute("font-family");
            this.fontsize = el.getAttribute("font-size");
        }
        getWidthOfText() {
            const c = document.createElement("canvas");
            const ctx = c.getContext("2d");
            ctx.font = this.fontsize + "px" + this.fontname;
            const length = ctx.measureText(this.txt).width;
            console.log("w = " + length);
            return length;
        }
    }
    class SvgTagsHelper {
        static createSvg(id = "") {
            const el = document.createElementNS("http://www.w3.org/2000/svg", "svg");
            if (id !== "") {
                el.id = id;
            }
            return el;
        }
        static createRect(id = "") {
            const el = document.createElementNS("http://www.w3.org/2000/svg", "rect");
            if (id !== "") {
                el.id = id;
            }
            return el;
        }
        static p(x, y) {
            return x + " " + y + " ";
        }
        static createLinearGradient(id, x1, y1, x2, y2, offset1, offset2, stopColor1, stopColor2, opacity = "0.2") {
            const el = document.createElementNS("http://www.w3.org/2000/svg", "linearGradient");
            el.setAttribute("id", id);
            el.setAttribute("x1", x1);
            el.setAttribute("x2", x2);
            el.setAttribute("y1", y1);
            el.setAttribute("y2", y2);
            const stop1 = document.createElementNS("http://www.w3.org/2000/svg", "stop");
            stop1.setAttribute("offset", offset1);
            stop1.setAttribute("stop-color", stopColor1);
            stop1.setAttribute("stop-opacity", opacity);
            const stop2 = document.createElementNS("http://www.w3.org/2000/svg", "stop");
            stop2.setAttribute("offset", offset2);
            stop2.setAttribute("stop-color", stopColor2);
            stop2.setAttribute("stop-opacity", opacity);
            el.appendChild(stop1);
            el.appendChild(stop2);
            return el;
        }
        static createSection(sectionPosition, x, y, w, h, r, color) {
            switch (sectionPosition) {
                case SectionPosition.Left:
                    return this.createRoundedRect(x, y, w + 1, h, r, 0, 0, r, color);
                case SectionPosition.Right:
                    return this.createRoundedRect(x, y, w, h, 0, r, r, 0, color);
                case SectionPosition.Middle:
                    return this.createRoundedRect(x, y, w + 1, h, 0, 0, 0, 0, color);
                default:
                    throw Error("Unknown SectionType!");
            }
        }
        static createSimpleRoundedRect(x, y, w, h, r, color) {
            return this.createRoundedRect(x, y, w, h, r, r, r, r, color);
        }
        static createRoundedRect(x, y, w, h, r1, r2, r3, r4, color) {
            const el = document.createElementNS("http://www.w3.org/2000/svg", "path");
            let path = `M${this.p(x + r1, y)}`;
            path += `L${this.p(x + w - r2, y)}Q${this.p(x + w, y)}${this.p(x + w, y + r2)}`;
            path += `L${this.p(x + w, y + h - r3)}Q${this.p(x + w, y + h)}${this.p(x + w - r3, y + h)}`;
            path += `L${this.p(x + r4, y + h)}Q${this.p(x, y + h)}${this.p(x, y + h - r4)}`;
            path += `L${this.p(x, y + r1)}Q${this.p(x, y)}${this.p(x + r1, y)}`;
            path += "Z";
            el.setAttribute("d", path);
            el.setAttribute("fill", color);
            return el;
        }
        static createText(text = "") {
            const el = document.createElementNS("http://www.w3.org/2000/svg", "text");
            if (text !== "") {
                el.textContent = text;
            }
            return el;
        }
        static createG(id = "") {
            const el = document.createElementNS("http://www.w3.org/2000/svg", "g");
            if (id !== "") {
                el.id = id;
            }
            return el;
        }
        static getRectText(text, fontStyle, caller = undefined) {
            const rect = this
                .createText(text)
                .fontFamily(fontStyle.fontFamily)
                .fontSize(fontStyle.fontSize)
                .fill(fontStyle.fontColor)
                .getTextRect(caller);
            return rect;
        }
        }
        class BadgeSectionHelper {
        static getSectionPosition(currentSectionNumber, badgeSectionsCount) {
            if (currentSectionNumber === 1) {
                return SectionPosition.Left;
            }
            else if (currentSectionNumber >= 1 && currentSectionNumber < badgeSectionsCount) {
                return SectionPosition.Middle;
            }
            else if (currentSectionNumber === badgeSectionsCount) {
                return SectionPosition.Right;
            }
            throw Error(`Can not get SectionType for section ${currentSectionNumber} of total ${badgeSectionsCount} sections.`);
        }
        static checkBadgeSection(section) {
            if (section.type === undefined || section.type.toString() === "Text") {
                section.type = SectionType.Text;
            }
            return section;
        }
        static checkBadgeStyle(section, badgeStyle) {
            if (section.type === SectionType.Text || section.type === undefined) {
                return badgeStyle;
            }
            const lang = Languages.getLangByType(section.type);
            if (section.text === undefined) {
                section.text = lang.name;
            }
            badgeStyle.commonTextStyle.backgroundColor = lang.color;
            badgeStyle.commonTextStyle.fontStyle.fontColor = lang.textColor;
            badgeStyle.commonTextStyle.fontStyle.fontShadowColor = "black";
            return badgeStyle;
        }
        static getSectionText(section, sectionWidth, sectionHeight, badgeWidth, fontStyle) {
            const sectionTextGroup = SvgTagsHelper.createG("section-text-group");
            const sectionText = SvgTagsHelper.createText(section.text);
            sectionText
                .fontFamily(fontStyle.fontFamily)
                .fontSize(fontStyle.fontSize)
                .fill(fontStyle.fontColor)
                .setX(badgeWidth + sectionWidth / 2)
                .setY(sectionHeight / 2);
            sectionText.setAttribute("text-anchor", "middle");
            sectionText.setAttribute("alignment-baseline", "central");
            const sectionTextShadow = SvgTagsHelper.createText(section.text);
            sectionTextShadow
                .fontFamily(fontStyle.fontFamily)
                .fontSize(fontStyle.fontSize)
                .fill(fontStyle.fontShadowColor)
                .fillOpacity("0.4")
                .setX(badgeWidth + sectionWidth / 2 + 0.5)
                .setY(sectionHeight / 2 + 0.5);
            sectionTextShadow.setAttribute("text-anchor", "middle");
            sectionTextShadow.setAttribute("alignment-baseline", "central");
            sectionTextGroup.appendChild(sectionTextShadow);
            sectionTextGroup.appendChild(sectionText);
            return sectionTextGroup;
        }
        static getSection(section, currentSection, sectionsCount, badgeWidth, badgeHeight, badgeStyle, caller) {
            section = this.checkBadgeSection(section);
            badgeStyle = this.checkBadgeStyle(section, badgeStyle);
            const sectionGroup = SvgTagsHelper.createG("section-group");
            const sectionPosition = BadgeSectionHelper.getSectionPosition(currentSection, sectionsCount);
            const fontStyle = badgeStyle.commonTextStyle.fontStyle;
            const sectionTextRect = SvgTagsHelper.getRectText(section.text, fontStyle, caller);
            const sectionWidth = badgeStyle.indent * 2 + sectionTextRect.width;
            const sectionHeight = badgeStyle.indent * 2 + sectionTextRect.height;
            const sectionTextGroup = this.getSectionText(section, sectionWidth, sectionHeight, badgeWidth, fontStyle);
            if (section.bcgColor === undefined) {
                section.bcgColor = badgeStyle.commonTextStyle.backgroundColor;
            }
            const sectionRect = SvgTagsHelper.createSection(sectionPosition, badgeWidth, 0, sectionWidth, sectionHeight, badgeStyle.radius, section.bcgColor);
            sectionGroup.appendChild(sectionRect);
            sectionGroup.appendChild(sectionTextGroup);
            return {
                node: sectionGroup,
                rect: {
                    height: sectionHeight,
                    width: sectionWidth,
                    x: badgeWidth,
                    y: 0
                }
            };
        }
    }
    class Badge {
        constructor() {
            this.urlHelper = new UrlHelper();
            this.theme = this.urlHelper.getTheme();
            const badgeStyle = this.getStyle();
            this.style = badgeStyle;
        }
        setHtmlTarget(target) {
            this.targetHtmlElement = target;
        }
        setSvgTarget(target) {
            this.targetSvgElement = target;
        }
        setCaller(caller) {
            this.caller = caller;
        }
        getStyle() {
            let style;
            switch (this.theme) {
                case Theme.Dark:
                    style = new DarkBadgeStyle();
                    break;
                case Theme.Light:
                    style = new LightBadgeStyle();
                    break;
                default:
                    style = new LightBadgeStyle();
                    break;
            }
            return style;
        }
        buildSvg(badgeStyle, badgeData, buildType) {
            const badgeMainGroup = SvgTagsHelper.createG("main-group");
            let badgeWidth = 0;
            let badgeHeight = 0;
            const sectionsCount = badgeData.sections.length;
            let currentSection = 0;
            for (let section of badgeData.sections) {
                currentSection++;
                const sectionResult = BadgeSectionHelper
                    .getSection(section, currentSection, sectionsCount, badgeWidth, badgeHeight, badgeStyle, this.caller);
                badgeWidth += sectionResult.rect.width;
                if (badgeHeight < sectionResult.rect.height) {
                    badgeHeight = sectionResult.rect.height;
                }
                badgeMainGroup.appendChild(sectionResult.node);
            }
            const gradienId = "badge-gradient-id";
            const badgeGradient = SvgTagsHelper.createLinearGradient(gradienId, "0%", "0%", "0%", "90%", "10%", "90%", "white", "black", "0.1");
            const badgeGradientRect = SvgTagsHelper.createSimpleRoundedRect(0, 0, badgeWidth, badgeHeight, badgeStyle.radius, `url(#${gradienId})`);
            badgeMainGroup.appendChild(badgeGradientRect);
            switch (buildType) {
                case BuildType.Full:
                    {
                        const badge = SvgTagsHelper.createSvg("svg-badge");
                        badge.appendChild(badgeGradient);
                        badge.appendChild(badgeMainGroup);
                        badge
                            .setWidth(badgeWidth)
                            .setHeight(badgeHeight);
                        this.targetHtmlElement.appendChild(badge);
                        break;
                    }
                case BuildType.InsideSvg:
                    {
                        this.targetSvgElement.appendChild(badgeGradient);
                        this.targetSvgElement.appendChild(badgeMainGroup);
                        this.targetSvgElement
                            .setWidth(badgeWidth)
                            .setHeight(badgeHeight);
                        break;
                    }
                default:
                    throw Error("Unknown BuildType!");
            }
        }
        buildBadgeByData(data, buildType) {
            this.buildSvg(this.style, data, buildType);
        }
        buildBadgeFromJson(badgeDataPath, buildType) {
            let data;
            const req = new XMLHttpRequest();
            req.open("get", badgeDataPath, true);
            req.send();
            req.onreadystatechange = () => {
                if (req.readyState !== 4)
                    return;
                if (req.status !== 200) {
                    console.log(`Error while loading .json data! Request status: ${req.status} : ${req.statusText}`);
                }
                else {
                    data = JSON.parse(req.responseText);
                    this.buildSvg(this.style, data, buildType);
                }
            };
        }
        buildBadgeFromJsons(badgeStylePath, badgeDataPath, buildType) {
            let data;
            let style;
            const req1 = new XMLHttpRequest();
            req1.open("get", badgeDataPath, true);
            req1.send();
            req1.onreadystatechange = () => {
                if (req1.readyState !== 4)
                    return;
                if (req1.status !== 200) {
                    console.log(`Error while loading .json data! Request status: ${req1.status} : ${req1.statusText}`);
                }
                else {
                    data = JSON.parse(req1.responseText);
                    const req2 = new XMLHttpRequest();
                    req2.open("get", badgeStylePath, true);
                    req2.send();
                    req2.onreadystatechange = () => {
                        if (req2.readyState !== 4)
                            return;
                        if (req2.status !== 200) {
                            console.log(`Error while loading .json style! Request status: ${req2.status} : ${req2.statusText}`);
                        }
                        else {
                            style = JSON.parse(req2.responseText);
                            this.buildSvg(style, data, buildType);
                        }
                    };
                }
            };
        }
    }
    function buildBadgeById(id, dataPath = "./badgeData.json") {
        const target = document.getElementById(id);
        const badge = new Badge();
        badge.setHtmlTarget(target);
        badge.buildBadgeFromJson(dataPath, BuildType.Full);
    }
        function buildBadgeInsideSvg(svgId, dataPath = "./badgeData.json") {
            const target = document.getElementById(svgId);
            const badge = new Badge();
            badge.setSvgTarget(target);
            badge.buildBadgeFromJson(dataPath, BuildType.InsideSvg);
        }
            function buildSvgBadge(el, dataPath = "./badgeData.json") {
                const badge = new Badge();
                badge.setSvgTarget(el);
                badge.setCaller(el);
                badge.buildBadgeFromJson(dataPath, BuildType.InsideSvg);
            }
                function buildSvgBadgeFullJson(el, dataPath = "./badgeData.json", stylePath = "./badgeStyle.json") {
                    const badge = new Badge();
                    badge.setSvgTarget(el);
                    badge.setCaller(el);
                    badge.buildBadgeFromJsons(stylePath, dataPath, BuildType.InsideSvg);
                }
                    function myLanguageBadge(el) {
                        const badge = new Badge();
                        const user = badge.urlHelper.getUserName();
                        const repo = badge.urlHelper.getRepoName();
                        const reqUrl = `https://api.github.com/repos/${user}/${repo}`;
                        var lang;
                        const req = new XMLHttpRequest();
                        req.open("get", reqUrl, true);
                        req.send();
                        req.onreadystatechange = () => {
                            if (req.readyState !== 4)
                                return;
                            if (req.status !== 200) {
                                console.log(`Error while loading .json data! Request status: ${req.status} : ${req.statusText}`);
                            }
                            else {
                                lang = JSON.parse(req.responseText)["language"];
                                const sectionType = SectionType.CSharp;
                                badge.setSvgTarget(el);
                                badge.setCaller(el);
                                const data = {
                                    sections: [
                                        {
                                            type: SectionType.Text,
                                            text: "language",
                                            bcgColor: undefined
                                        },
                                        {
                                            type: sectionType,
                                            text: undefined,
                                            bcgColor: undefined
                                        }
                                    ]
                                };
                                badge.buildBadgeByData(data, BuildType.InsideSvg);
                            }
                        };
                    }
                    function languageBadge(el, langName) {
                        const badge = new Badge();
                        badge.setSvgTarget(el);
                        badge.setCaller(el);
                        const lang = Languages.getLangByName(langName);
                        const langSectionType = lang.sectionType;
                        const data = {
                            sections: [
                                {
                                    type: SectionType.Text,
                                    text: "language",
                                    bcgColor: undefined
                                },
                                {
                                    type: langSectionType,
                                    text: undefined,
                                    bcgColor: undefined
                                }
                            ]
                        };
                        badge.buildBadgeByData(data, BuildType.InsideSvg);
                    }
                    //# sourceMappingURL=badge.js.map