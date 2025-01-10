// Loader functionality
const loader = {
    show() {
        const overlay = document.getElementById('loader-overlay');
        if (overlay) {
            overlay.classList.add('active');
        }
    },
    hide() {
        const overlay = document.getElementById('loader-overlay');
        if (overlay) {
            overlay.classList.remove('active');
        }
    }
};

// Show loader before form submission
document.addEventListener('DOMContentLoaded', function() {
    const forms = document.querySelectorAll('form');
    forms.forEach(form => {
        form.addEventListener('submit', function() {
            loader.show();
        });
    });

    // Hide loader when page is fully loaded
    window.addEventListener('load', function() {
        loader.hide();
    });

    // Hide loader when pressing back button
    window.addEventListener('pageshow', function(event) {
        if (event.persisted) {
            loader.hide();
        }
    });
});
