import { AppVersionManager } from "./AppVersionManager";

export class ThemeManager {
  private version: AppVersionManager;

  homepage: any;
  constructor() {
    this.version = AppVersionManager.getInstance();
  }

  getTheme() {
    return this.version.theme;
  }

  getThemeIcons() {
    return this.version.theme?.Icons;
  }

  getThemeColors() {
    return this.version.theme?.Colors;
  }

  getThemeCtaColors() {
    return this.version.theme?.CtaColors;
  }

  getThemeColor(colorName: string): string | undefined {
    return this.getThemeColors()?.find((color) => color.ColorName === colorName)
      ?.ColorCode;
  }

  getThemeCtaColor(colorName: string) {
    if (!colorName) {
      colorName = "CtaColorOne";
    }
    return this.getThemeCtaColors()?.find(
      (color) =>
        color.CtaColorName.toLocaleLowerCase() === colorName.toLocaleLowerCase()
    )?.CtaColorCode;
  }

  getThemeIcon(iconName: string) {
    return this.getThemeIcons()?.find(
      (icon) =>
        icon.IconName.toLocaleLowerCase() === iconName.toLocaleLowerCase()
    )?.IconSVG;
  }
}
