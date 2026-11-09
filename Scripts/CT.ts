(function (): void {
    const ct: HTMLLinkElement = document.createElement('link');
    const url: URL = new URL('https://csswizardry.com/ct/ct.css');

    ct.crossOrigin = 'anonymous';

    ct.href = url.toString();

    ct.lang = 'en';

    ct.rel = 'stylesheet';

    ct.type = 'text/css';

    ct.classList.add('ct');

    document.head.appendChild(ct);
}());