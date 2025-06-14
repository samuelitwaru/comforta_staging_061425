export class HeaderComponent {
    header: HTMLElement;

    constructor() {
        this.header =  document.createElement('div');
        this.init();
    }

    private init() {
        this.header.classList.add('tbap-header');

        const clock = document.createElement('span');
        clock.id = 'clock';
        clock.innerText = '8:34 PM';
        
        const icons = document.createElement('span');
        icons.classList.add('icons');

        const signal = document.createElement('i');
        signal.classList.add('fas', 'fa-signal');

        const wifi = document.createElement('i');
        wifi.classList.add('fas', 'fa-wifi');
        
        const battery = document.createElement('i');
        battery.classList.add('fas', 'fa-battery');

        icons.appendChild(signal);
        icons.appendChild(wifi);
        icons.appendChild(battery);

        this.header.appendChild(clock);
        this.header.appendChild(icons);
    }

    render(container: HTMLElement) {
        container.appendChild(this.header);
    }
}