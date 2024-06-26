function parseCookie() {
    let result = {};

    let assignments = document.cookie.split(';');

    assignments.forEach(assignment => {
        assignment = assignment.trim();

        let parts = assignment.split('=');

        if (parts.length === 2) {
            let key = parts[0].trim();
            let value = parts[1].trim();

            result[key] = value;
        }
    });

    return result;
}

export default parseCookie