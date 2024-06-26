import fetchData from "../utilities/FetchData.js";

const getUserRole = async () => {
    const {isAuthenticated, success, data} = await fetchData("/api/verify", "GET", null, true)

    const navContainer = document.querySelector(".nav-right")
    navContainer.classList.remove("hidden");
    if (!isAuthenticated) {
        return console.error('Not authenticated')
    }
    if (!success) {
        return console.error("Something went wrong")
    } 

    navContainer.classList.add("authenticated");
}


getUserRole()