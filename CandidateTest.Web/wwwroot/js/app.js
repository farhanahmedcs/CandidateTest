window.appInterop = {
    confirmDelete: async function (title, text) {
        const result = await Swal.fire({
            title: title,
            text: text,
            icon: "warning",
            showCancelButton: true,
            confirmButtonText: "Yes, delete",
            cancelButtonText: "Cancel",
            reverseButtons: true
        });

        return result.isConfirmed;
    },

    showSuccess: async function (title, text) {
        await Swal.fire({
            icon: "success",
            title: title,
            text: text,
            timer: 1500,
            showConfirmButton: false
        });
    },

    showError: async function (title, text) {
        await Swal.fire({
            icon: "error",
            title: title,
            text: text
        });
    },

    initializeTooltips: function () {
        const elements = document.querySelectorAll('[data-bs-toggle="tooltip"]');

        elements.forEach(el => {
            const existing = bootstrap.Tooltip.getInstance(el);
            if (existing) {
                existing.dispose();
            }

            new bootstrap.Tooltip(el);
        });
    }
};