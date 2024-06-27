import fetchData from "../utilities/FetchData.js";
import { createQuotationRequestOverlay } from "./QuotationRequestOverlay.js";

let userRole = null

const getUserRole = async () => {
    const { isAuthenticated, success, data } = await fetchData("/api/verify", "GET", null, true)

    const navContainer = document.querySelector(".nav-right")
    navContainer.classList.remove("hidden");
    if (!isAuthenticated) {
        return console.error('Not authenticated')
    }
    if (!success) {
        return console.error("Something went wrong")
    }

    navContainer.classList.add("authenticated");
    userRole = data.role
}

const requestQuotationClickHandler = (e) => {
    const btnElement = e.currentTarget

    const { eventId } = btnElement.dataset

    if (userRole === null) {
        location.href = '/Login.html'
    }

    createQuotationRequestOverlay(eventId)

}

const makeEvents = async () => {
    try {
        await getUserRole()
        const { data: events } = await fetchData("/api/events", "GET", null, true)
        const container = document.querySelector(".service-elements-container")
        events.forEach(event => {
            const template = document.createElement("template")
            template.innerHTML =
                `
            <div  class="service-element">
            <div class="title">
                    ${event.eventName}
                    </div>
                    <div class="service-desc">
                    ${event.description}
                    </div>
                    ${userRole === 'Admin' ? "" :
                    `
                        <button data-event-id=${event.eventCategoryId} class="request-quotation-btn">
                        Request Quotation
                        </button>
                        `
                }
                        </div>
                        
        `
            const content = template.content
            const requestBtn = content.querySelector(".request-quotation-btn")
            if (requestBtn) requestBtn.onclick = requestQuotationClickHandler
            container.append(template.content)
        })
    } catch (error) {
        alert("Can't establish backend connection, some content might not be loaded")
    }
}

makeEvents()


const hamburgerIcon = document.querySelector(".hamburger-icon")
const navBar = document.querySelector(".profile-left")
const hamburgerImg = hamburgerIcon.querySelector("img")

let isNavOpen = false


const autoCloseFunc = (e) => {
    if (!e.target.closest('.mobile-nav-right') || e.target.closest('.nav-item')) {
        hamburgerIcon.click()
    }
}


hamburgerIcon.onclick = (e) => {
    e.stopPropagation()
    navBar.classList.toggle('hidden')
    isNavOpen = !isNavOpen
    if (isNavOpen) {
        if (userRole !== null) {
            navBar.classList.add("authenticated");
        }
        hamburgerImg.src = "./assets/white_close.svg"
        document.body.addEventListener('click', autoCloseFunc)
    } else {
        hamburgerImg.src = "./assets/hamburger.svg"
        document.body.removeEventListener('click', autoCloseFunc)
    }
}

