/**
 * @access public
 * @function
 * @returns {void}
 */
(function (): void {
    /**
     * @access private
     * @constant
     * @name ct
     * @type {HTMLLinkElement}
     */
    const ct: HTMLLinkElement = document.createElement('link');

    /**
     * @access private
     * @constant
     * @name url
     * @type {URL}
     */
    const url: URL = new URL('https://csswizardry.com/ct/ct.css');

    ct.crossOrigin = 'anonymous';

    ct.href = url.toString();

    ct.lang = 'en';

    ct.rel = 'stylesheet';

    ct.type = 'text/css';

    ct.classList.add('ct');

    document.head.appendChild(ct);
}());