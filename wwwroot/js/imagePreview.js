// Generic client-side image preview for inputs.
// Usage:
// - Add class="image-preview" and data-preview-target="#previewId" to file inputs
// - Backward-compatible: supports id="photoInput" with img id="preview"
(function () {
    function setupInput(input, previewSelector) {
        const previewEl = previewSelector ? document.querySelector(previewSelector) : null;

        input.addEventListener('change', function () {
            const file = this.files && this.files[0];
            if (!file) {
                if (previewEl) {
                    previewEl.style.display = 'none';
                    previewEl.src = '';
                }
                return;
            }

            if (!file.type || !file.type.startsWith('image/')) {
                if (previewEl) {
                    previewEl.style.display = 'none';
                    previewEl.src = '';
                }
                return;
            }

            const reader = new FileReader();
            reader.onload = function (e) {
                if (previewEl) {
                    previewEl.src = e.target.result;
                    previewEl.style.display = 'block';
                }
            };
            reader.readAsDataURL(file);
        });
    }

    document.addEventListener('DOMContentLoaded', function () {
        // Support legacy ids
        const oldInput = document.getElementById('photoInput');
        const oldPreview = document.getElementById('preview');
        if (oldInput && oldPreview) {
            setupInput(oldInput, '#preview');
        }

        // Inputs using class + data attribute
        document.querySelectorAll('input[type="file"].image-preview').forEach(input => {
            const target = input.getAttribute('data-preview-target') || null;
            setupInput(input, target);
        });

        // Inputs that only declare data-preview-target
        document.querySelectorAll('input[type="file"][data-preview-target]').forEach(input => {
            const target = input.getAttribute('data-preview-target') || null;
            setupInput(input, target);
        });
    });
})();