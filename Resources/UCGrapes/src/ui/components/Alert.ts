import { AppConfig } from "../../AppConfig";

export class Alert {

    constructor(status: "error" | "success", message: string, duration: number = 5000) {
        const config = AppConfig.getInstance();
        if (config.displayMessageEvent !== undefined) {
            config.displayMessageEvent(this.capitalizeFirstLetter(status), status, message);
        } else {
            console.log('Alert function undefined')
        }
    }

    capitalizeFirstLetter(str: string): string {
        if (str.length === 0) {
            return ""; // Handle empty strings
        }
        return str.charAt(0).toUpperCase() + str.slice(1);
    }
}