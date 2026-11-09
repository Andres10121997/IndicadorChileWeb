(function (): void {
    const ct: HTMLLinkElement = document.createElement('link');

    ct.href = 'https://csswizardry.com/ct/ct.css';

    ct.rel = 'stylesheet';

    ct.type = 'text/css';

    ct.classList.add('ct');

    document.head.appendChild(ct);
}());