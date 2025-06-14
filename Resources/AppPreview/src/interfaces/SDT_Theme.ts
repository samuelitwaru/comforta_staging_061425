import { Colors } from "./Colors";
import { CtaColors } from "./CtaColors";
import { Icons } from "./Icons";

export interface SDT_Theme {
    ThemeFontFamily: string,
    Colors: Colors[];
    Icons: Icons[];
    CtaColors: CtaColors[];
}