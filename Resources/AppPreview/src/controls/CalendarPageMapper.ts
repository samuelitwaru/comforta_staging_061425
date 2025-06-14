import { ThemeManager } from "./ThemeManager";

export class CalendarPageMapper {
  themeManager: ThemeManager;
      constructor() {
          this.themeManager = new ThemeManager();
      }
    private htmlData(): string {
        let pageData = `
        <div class="tbap-date-selector"
          style="background-color: ${this.themeManager.getThemeColor('backgroundColor') || '#5068a8'};">
          <span class="tbap-arrow">❮</span>
          <span class="tbap-date-text" id="current-date">${this.formatDate()}</span>
          <span class="tbap-arrow">❯</span>
        </div>
        <div class="tbap-schedule" id="schedule-container">
      `;
      
      for (let hour = 0; hour < 24; hour++) {
          const formattedHour = hour.toString().padStart(2, "0") + ":00";
          pageData += `
            <div class="tbap-time-slot">
              <div class="tbap-time">${formattedHour}</div>
              <div class="tbap-events"></div>
              ${hour === new Date().getHours() ? `
                <div class="tbap-current-time-indicator"></div>
                <div class="tbap-current-time-dot"></div>` : ''}
            </div>
          `;
      }    
      pageData += `</div>`;
    
      return pageData;
    }

    private formatDate(): string {
        const date: string = new Date().toLocaleDateString('en-GB', {
            day: "2-digit",
            month: "short",
            year: "numeric"
        }).replace(/(\d{2} \w{3}) (\d{4})/, "$1, $2");

        return date;
    }

    renderContent(container: HTMLElement): void { 
        const tempDiv = document.createElement('div');
        tempDiv.innerHTML = this.htmlData();
        
        while (tempDiv.firstChild) {
            container.appendChild(tempDiv.firstChild);
        }
    }
}