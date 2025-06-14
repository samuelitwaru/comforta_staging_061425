import { ThemeManager } from "./ThemeManager";

export default class MyActivityPageMapper {
    themeManager: ThemeManager;
    constructor() {
        this.themeManager = new ThemeManager();
    }
    renderContent(container: HTMLElement): void {  
        
        const chatContainer = document.createElement('div');
        chatContainer.className = 'tbap-chat-container';

        const toggleButtons = document.createElement('div');
        toggleButtons.className = 'tbap-toggle-buttons';

        const messageButton = document.createElement('button');
        messageButton.style.backgroundColor = this.themeManager.getThemeColor('backgroundColor') || '#5068a8';
        messageButton.style.borderRadius = '6px';
        messageButton.innerText = 'Messages';

        const requestButton = document.createElement('button');
        requestButton.style.backgroundColor = '#e1e1e1';
        requestButton.style.borderRadius = '6px';
        requestButton.style.color = '#262626'
        requestButton.innerText = 'Requests';
        
        toggleButtons.appendChild(messageButton);
        toggleButtons.appendChild(requestButton);

        const chatBody = document.createElement('div');
        chatBody.className = 'tbap-chat-body';
        chatBody.innerText = "No messages yet";

        chatContainer.appendChild(toggleButtons);
        chatContainer.appendChild(chatBody); 
        
        container.appendChild(chatContainer);
    }
}
