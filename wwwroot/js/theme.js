// Theme management
class ThemeManager {
    constructor() {
        this.theme = localStorage.getItem('theme') || 'dark';
        this.init();
    }

    init() {
        // Initialize theme switch
        const themeSwitch = document.getElementById('darkModeSwitch');
        if (themeSwitch) {
            // Set initial state
            themeSwitch.checked = this.theme === 'dark';
            
            // Add event listener
            themeSwitch.addEventListener('change', (e) => {
                this.toggleTheme();
            });
        }

        // Apply initial theme
        this.applyTheme();
    }

    toggleTheme() {
        this.theme = this.theme === 'dark' ? 'light' : 'dark';
        localStorage.setItem('theme', this.theme);
        this.applyTheme();
    }

    applyTheme() {
        document.documentElement.classList.toggle('dark', this.theme === 'dark');
        
        // Update switch state
        const themeSwitch = document.getElementById('darkModeSwitch');
        if (themeSwitch) {
            themeSwitch.checked = this.theme === 'dark';
        }

        // Update theme color meta tag
        const metaThemeColor = document.querySelector('meta[name="theme-color"]');
        if (metaThemeColor) {
            metaThemeColor.setAttribute('content', this.theme === 'dark' ? '#1a1a1a' : '#ffffff');
        }
    }
}

// Initialize theme manager when DOM is loaded
document.addEventListener('DOMContentLoaded', () => {
    window.themeManager = new ThemeManager();
});
