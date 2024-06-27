import fetchData from "../utilities/FetchData.js"
import { parseDate } from "../utilities/ParseDate.js";
import { statusMapWithClassName } from "../utilities/StatusMap.js";
import { generateRatingStars } from "../utilities/GeneratingRating.js";
import { createAddEventOverlay, createEditEventOverlay } from "./ManageEventOverlay.js";
import { createRespondToEventOverlay } from "./RespondToEventOverlay.js";

export const onRequestListMount = async (parentContainer) => {
    const data = await fetchData("/api/user/requests", "GET")

    const container = document.createElement("div")
    container.classList.add("profile-list-container", "list", "quotation-requests-container")
    data.forEach(request => {
        const requestElement = document.createElement("template")
        requestElement.innerHTML =
            `
            <div data-quotation-request-id=${request.quotationRequestId} class="profile-list pointer">
                    <div class="top-row">
                        <span class="list-title">${request.eventCategory}</span>
                        <span class="tag ${statusMapWithClassName[request.quotationStatus]}">${request.quotationStatus}</span>
                    </div>
                    <div class="inner-content">
                        <div class="data-row">
                            <div class="data-column">
                                <div class="data-cell">
                                    <div class="data-label">Event Start Date:</div>
                                    <div class="data-value">${parseDate(request.eventStartDate)}</div>
                                </div>
                            </div>
                            <div class="data-column">
                                <div class="data-cell">
                                    <div class="data-label">Event End Date:</div>
                                    <div class="data-value">${parseDate(request.eventEndDate)}</div>
                                </div>
                            </div>
                        </div>
                        <div class="data-row">
                            <div class="data-column">
                                <div class="data-cell">
                                    <div class="data-label">Venue Type:</div>
                                    <div class="data-value">${request.venueType}</div>
                                </div>
                            </div>
                            <div class="data-column">
                                <div class="data-cell">
                                    <div class="data-label">Food Preference Type:</div>
                                    <div class="data-value">${request.foodPreference}</div>
                                </div>
                            </div>
                        </div>
                        <div class="data-row">
                            <div class="data-cell">
                                <div class="data-label">Location Details:</div>
                                <div class="data-value">${request.locationDetails}</div>
                            </div>
                        </div>
                        <div class="data-row">
                            <div class="data-cell">
                                <div class="data-label">Special Instructions:</div>
                                <div class="data-value">${request.specialInstructions}</div>
                            </div>
                        </div>
                        <div class="data-row">
                            <div class="data-cell">
                                <div class="data-label">Catering Instructions:</div>
                                <div class="data-value">${request.cateringInstructions || "-"}</div>
                            </div>
                        </div>
                    </div>
                </div>
        `
        container.appendChild(requestElement.content)
    })
    parentContainer.appendChild(container);
}


export const onRequestDetailsMount = async (parentContainer, requestId) => {
    const data = await fetchData(`/api/user/requests/${requestId}`, "GET")
    const container = document.createElement("div")
    container.classList.add("profile-list-container", "quotation-requests-container")
    container.innerHTML =
        `
        <div class="request-details">
                    <div class="top-row">
                        <span class="list-title">${data.eventCategory}</span>
                        <span class="tag ${statusMapWithClassName[data.quotationStatus]}">${data.quotationStatus}</span>
                    </div>
                    <div class="inner-content">
                        <div class="data-row">
                            <div class="data-column">
                                <div class="data-cell">
                                    <div class="data-label">Event Start Date:</div>
                                    <div class="data-value">${parseDate(data.eventStartDate)}</div>
                                </div>
                            </div>
                            <div class="data-column">
                                <div class="data-cell">
                                    <div class="data-label">Event End Date:</div>
                                    <div class="data-value">${parseDate(data.eventEndDate)}</div>
                                </div>
                            </div>
                        </div>
                        <div class="data-row">
                            <div class="data-column">
                                <div class="data-cell">
                                    <div class="data-label">Venue Type:</div>
                                    <div class="data-value">${data.venueType}</div>
                                </div>
                            </div>
                            <div class="data-column">
                                <div class="data-cell">
                                    <div class="data-label">Food Preference Type:</div>
                                    <div class="data-value">${data.foodPreference}</div>
                                </div>
                            </div>
                        </div>
                        <div class="data-row">
                            <div class="data-cell">
                                <div class="data-label">Location Details:</div>
                                <div class="data-value">${data.locationDetails}</div>
                            </div>
                        </div>
                        <div class="data-row">
                            <div class="data-cell">
                                <div class="data-label">Special Instructions:</div>
                                <div class="data-value">${data.specialInstructions}</div>
                            </div>
                        </div>
                        <div class="data-row">
                            <div class="data-cell">
                                <div class="data-label">Catering Instructions:</div>
                                <div class="data-value">${data.cateringInstructions || "-"}</div>
                            </div>
                        </div>
                    </div>
                    ${data.quotationResponse ?
            `<div class="admin-response">
                        <div class="top-row">
                            <span class="list-title">Admin Response</span>
                            <span class="tag ${statusMapWithClassName[data.quotationResponse.requestStatus]}">
                                ${data.quotationResponse.requestStatus}
                            </span>
                        </div>
                        <div class="inner-content">
                        ${data.quotationResponse.requestStatus === "Accepted" ? `<div class="data-row">
                                <div class="data-cell">
                                    <div class="data-label">
                                        Quoted Amount:
                                    </div>
                                    <div class="data-value">
                                        ${data.quotationResponse.quotedAmount} ${data.quotationResponse.currency}
                                    </div>
                                </div>
                            </div>` : ""
            }    
                            <div class="response-message">
                            ${data.quotationResponse.responseMessage}
                            </div>
                            <div class="action-tags-container">
                            ${data.quotationResponse.clientResponse ?
                `           
                    ${data.quotationResponse.clientResponse.clientDecision === "Accepted" ?
                    `                
                    <div class="tag success">
                        <img src="./assets/green_tick.svg" alt="">
                        <span>Accepted</span>
                    </div>
                    ${data.quotationResponse.clientResponse.isPaid ?
                        `
                            <div class="tag warning">
                                <span>Paid</span>
                            </div>
                        ` :
                        `
                        <button data-order-id="${data.quotationResponse.clientResponse.orderId}" class="action-btn pay-now">
                            Pay Now
                        </button>
                        `
                    }
                    `
                    :
                    `
                                    <div class="tag fail">
                <img src="./assets/red_close.svg" alt="">
                <span>Rejected</span>
                </div>
                    `

                } 
                ` :
                `
                    ${data.quotationResponse.requestStatus === "Accepted" ?
                    `
                            <div 
                            data-quotation-response-id="${data.quotationResponse.quotationResponseId}" 
                            data-quotation-request-id="${data.quotationRequestId}" 
                            data-decision="Accepted" 
                            class="tag action success client-decision-btn">
                                <img src="./assets/green_tick.svg" alt="">
                                <span>Accept</span>
                            </div>
                            <div 
                            data-quotation-response-id="${data.quotationResponse.quotationResponseId}" 
                            data-quotation-request-id="${data.quotationRequestId}"
                            data-decision="Denied" 
                            class="tag action fail client-decision-btn">
                                <img src="./assets/red_close.svg" alt="">
                                <span>Reject</span>
                            </div>`
                    :
                    ``
                }
                `
            }
                            </div>
                        </div>
                    </div>
                </div>` :
            `
`
        }
    `

    parentContainer.appendChild(container)

}

export const onOrderListMount = async (parentContainer) => {
    const data = await fetchData("/api/user/orders", "GET")
    const container = document.createElement("div")
    container.classList.add("profile-list-container", "list", "order-list")
    data.forEach(order => {
        const requestElement = document.createElement("template")
        requestElement.innerHTML =
            `
        <div class="profile-list">
                    <div class="top-row">
                        <span class="list-title">${order.eventDetails.eventCategory}</span>
                        <span class="tag ${statusMapWithClassName[order.orderStatus]}">${order.orderStatus}</span>
                    </div>
                    <div class="inner-content">
                        <div class="data-row">
                            <div class="data-column">
                                <div class="data-cell">
                                    <div class="data-label">Event Start Date:</div>
                                    <div class="data-value">${parseDate(order.eventDetails.eventStartDate)}</div>
                                </div>
                            </div>
                            <div class="data-column">
                                <div class="data-cell">
                                    <div class="data-label">Event End Date:</div>
                                    <div class="data-value">${parseDate(order.eventDetails.eventEndDate)}</div>
                                </div>
                            </div>
                        </div>
                        <div class="data-row">
                            <div class="data-cell">
                                <div class="data-label">Amount:</div>
                                <div class="data-value">${order.totalAmount} ${order.currency}</div>
                            </div>
                        </div>
                        ${order.orderStatus !== "Completed" ?
                `<div class="order-action-btn">
                            <button data-order-id="${order.orderId}" class="action-btn pay-now">Pay Now</button>
                        </div>` : ""
            }
                    </div>
                </div>
        `
        container.appendChild(requestElement.content)
    })

    parentContainer.appendChild(container);


}
export const onScheduledEventListMount = async (parentContainer) => {
    const data = await fetchData("/api/user/events", "GET")
    const container = document.createElement("div")
    container.classList.add("profile-list-container", "list", "scheduled-event-list")
    data.forEach(event => {
        const requestElement = document.createElement("template")
        requestElement.innerHTML =
            `
                <div class="profile-list">
                    <div class="top-row">
                        <span class="list-title">${event.eventCategory}</span>
                        <span class="tag ${statusMapWithClassName[event.isCompleted ? "Completed" : "Pending"]}">${event.isCompleted ? "Completed" : "Not Completed"}</span>
                    </div>
                    <div class="inner-content">

                        <div class="data-row">
                            <div class="data-column">
                                <div class="data-cell">
                                    <div class="data-label">Event Start Date:</div>
                                    <div class="data-value">${parseDate(event.eventStartDate)}</div>
                                </div>
                            </div>
                            <div class="data-column">
                                <div class="data-cell">
                                    <div class="data-label">Event End Date:</div>
                                    <div class="data-value">${parseDate(event.eventEndDate)}</div>
                                </div>
                            </div>
                        </div>
                        <div class="data-row">
                            <div class="data-column">
                                <div class="data-cell">
                                    <div class="data-label">Venue Type:</div>
                                    <div class="data-value">${event.venueType}</div>
                                </div>
                            </div>
                            <div class="data-column">
                                <div class="data-cell">
                                    <div class="data-label">Food Preference Type:</div>
                                    <div class="data-value">${event.foodPreference}</div>
                                </div>
                            </div>
                        </div>
                        <div class="data-row">
                            <div class="data-cell">
                                <div class="data-label">Location Details:</div>
                                <div class="data-value">${event.locationDetails}</div>
                            </div>
                        </div>
                        <div class="data-row">
                            <div class="data-cell">
                                <div class="data-label">Special Instructions:</div>
                                <div class="data-value">${event.specialInstructions}</div>
                            </div>
                        </div>
                        <div class="data-row">
                            <div class="data-cell">
                                <div class="data-label">Catering Instructions:</div>
                                <div class="data-value">${event.cateringInstructions || "-"}</div>
                            </div>
                        </div>
                        ${event.isCompleted ?
                ""
                :
                `
                        <div class="scheduled-event-list-action-container">
                            <button data-scheduled-event-id=${event.scheduledEventId} class="mark-as-completed-btn action-btn">
                                Mark as Completed
                            </button>
                        </div>
                            `
            }
                    </div>
                </div>
                </div>
            `
        container.appendChild(requestElement.content)

    })
    parentContainer.appendChild(container);

}


export const onAdminManageEventMount = async (parentContainer) => {

    const data = await fetchData("/api/admin/events", "GET")
    const container = document.createElement("div")
    const profileSectionTitle = parentContainer.querySelector(".profile-section-title")
    const addEventBtn = document.createElement("button")
    addEventBtn.textContent = "Add Event"
    addEventBtn.classList.add("add-event-btn")
    addEventBtn.onclick = createAddEventOverlay
    profileSectionTitle.appendChild(addEventBtn)
    container.classList.add("profile-list-container", "list", "scheduled-event-list")
    data.forEach(event => {
        const requestElement = document.createElement("template")
        requestElement.innerHTML =
            `
                <div class="profile-list">
                    <div class="top-row">
                        <span class="list-title">${event.eventName}</span>
                        <span class="tag ${event.isActive ? 'success' : 'fail'}">${event.isActive ? 'Active' : 'Not Active'}</span>
                    </div>
                    <div class="event-inner-content">
                        <div class="desc">
                            ${event.description}
                        </div>
                        <span class="rating-container">
                            ${generateRatingStars(event.rating)}
                        </span>
                        <div class="action-btn-container">
                            <button data-event-category-id=${event.eventCategoryId} class="action-btn-admin edit-event-btn">
                                <img src="./assets/edit_icon.svg" alt="">
                                <span>Edit Event</span>
                            </button>
                            <button data-event-category-id=${event.eventCategoryId} class="action-btn-admin view-event-review-btn">
                                <img src="./assets/review_icon.svg" alt="">
                                <span>View Reviews</span>
                            </button>
                        </div>
                    </div>

                </div>
            `
        const requestElementContent = requestElement.content
        const editBtn = requestElementContent.querySelector(".edit-event-btn")
        editBtn.onclick = () => {
            createEditEventOverlay(event)
        }
        container.appendChild(requestElementContent)
    })
    parentContainer.appendChild(container);

}

const renderAdminRequests = (parentContainer, data, headerBtn) => {
    const container = document.createElement("div")
    container.classList.add("profile-list-container", "list", "quotation-requests-container")
    const profileSectionTitle = parentContainer.querySelector(".profile-section-title")
    profileSectionTitle.querySelector(".filter-request-btn")?.remove()
    profileSectionTitle.appendChild(headerBtn)

    data.forEach(request => {
        const requestElement = document.createElement("template")
        requestElement.innerHTML =
            `
            <div data-quotation-request-id=${request.quotationRequestId} class="profile-list">
                    <div class="top-row">
                        <span class="list-title">${request.eventCategory}</span>
                        <span class="tag ${statusMapWithClassName[request.quotationStatus]}">${request.quotationStatus}</span>
                    </div>
                    <div class="inner-content">
                        <div class="data-row">
                            <div class="data-column">
                                <div class="data-cell">
                                    <div class="data-label">Event Start Date:</div>
                                    <div class="data-value">${parseDate(request.eventStartDate)}</div>
                                </div>
                            </div>
                            <div class="data-column">
                                <div class="data-cell">
                                    <div class="data-label">Event End Date:</div>
                                    <div class="data-value">${parseDate(request.eventEndDate)}</div>
                                </div>
                            </div>
                        </div>
                        <div class="data-row">
                            <div class="data-column">
                                <div class="data-cell">
                                    <div class="data-label">Venue Type:</div>
                                    <div class="data-value">${request.venueType}</div>
                                </div>
                            </div>
                            <div class="data-column">
                                <div class="data-cell">
                                    <div class="data-label">Food Preference Type:</div>
                                    <div class="data-value">${request.foodPreference}</div>
                                </div>
                            </div>
                        </div>
                        <div class="data-row">
                            <div class="data-cell">
                                <div class="data-label">Location Details:</div>
                                <div class="data-value">${request.locationDetails}</div>
                            </div>
                        </div>
                        <div class="data-row">
                            <div class="data-cell">
                                <div class="data-label">Special Instructions:</div>
                                <div class="data-value">${request.specialInstructions}</div>
                            </div>
                        </div>
                        <div class="data-row">
                            <div class="data-cell">
                                <div class="data-label">Catering Instructions:</div>
                                <div class="data-value">${request.cateringInstructions || "-"}</div>
                            </div>
                        </div>
                        ${request.quotationStatus === 'Responded' ? "" :
                `
                            <div class="action-btn-container">
                                <button data-event-category-id='{event.eventCategoryId} 'class="action-btn respond-to-event-btn">
                                    <span>Respond</span>
                                </button>
                            </div>
                            `
            }
                    </div>
                </div>
        `
        const content = requestElement.content

        if (request.quotationStatus === "Initiated") {
            const respondBtn = content.querySelector(".respond-to-event-btn")
            respondBtn.onclick = () => createRespondToEventOverlay(request.quotationRequestId)
        }

        container.appendChild(content)
    })
    parentContainer.appendChild(container);
}

export const onAdminRequestMount = async (parentContainer) => {
    const data = await fetchData("/api/admin/quotations", "GET")

    const filterNewBtn = document.createElement("button")
    filterNewBtn.classList.add("filter-request-btn", "new-request-btn")
    filterNewBtn.textContent = "Show New"
    
    const showAllBtn = document.createElement("button")
    showAllBtn.classList.add("filter-request-btn", "all-request-btn")
    showAllBtn.textContent = "Show All"
    
    showAllBtn.onclick = () => {
        parentContainer.querySelector(".profile-list-container").remove()
        renderAdminRequests(parentContainer, data, filterNewBtn)
    }
    
    filterNewBtn.onclick = () => {
        parentContainer.querySelector(".profile-list-container").remove()
        const filteredData = data.filter(element=>element.quotationStatus === 'Initiated')
        renderAdminRequests(parentContainer, filteredData, showAllBtn)
    }
    
    renderAdminRequests(parentContainer, data, filterNewBtn)
}


export const onAdminScheduledEventListMount = async (parentContainer) => {
    const data = await fetchData("/api/admin/events/scheduled", "GET")
    const container = document.createElement("div")
    container.classList.add("profile-list-container", "list", "scheduled-event-list")
    data.forEach(event => {
        const requestElement = document.createElement("template")
        requestElement.innerHTML =
            `
                <div class="profile-list">
                    <div class="top-row">
                        <span class="list-title">${event.eventCategory}</span>
                        <span class="tag ${statusMapWithClassName[event.isCompleted ? "Completed" : "Pending"]}">${event.isCompleted ? "Completed" : "Not Completed"}</span>
                    </div>
                    <div class="inner-content">

                        <div class="data-row">
                            <div class="data-column">
                                <div class="data-cell">
                                    <div class="data-label">Event Start Date:</div>
                                    <div class="data-value">${parseDate(event.eventStartDate)}</div>
                                </div>
                            </div>
                            <div class="data-column">
                                <div class="data-cell">
                                    <div class="data-label">Event End Date:</div>
                                    <div class="data-value">${parseDate(event.eventEndDate)}</div>
                                </div>
                            </div>
                        </div>
                        <div class="data-row">
                            <div class="data-column">
                                <div class="data-cell">
                                    <div class="data-label">Venue Type:</div>
                                    <div class="data-value">${event.venueType}</div>
                                </div>
                            </div>
                            <div class="data-column">
                                <div class="data-cell">
                                    <div class="data-label">Food Preference Type:</div>
                                    <div class="data-value">${event.foodPreference}</div>
                                </div>
                            </div>
                        </div>
                        <div class="data-row">
                            <div class="data-cell">
                                <div class="data-label">Location Details:</div>
                                <div class="data-value">${event.locationDetails}</div>
                            </div>
                        </div>
                        <div class="data-row">
                            <div class="data-cell">
                                <div class="data-label">Special Instructions:</div>
                                <div class="data-value">${event.specialInstructions}</div>
                            </div>
                        </div>
                        <div class="data-row">
                            <div class="data-cell">
                                <div class="data-label">Catering Instructions:</div>
                                <div class="data-value">${event.cateringInstructions || "-"}</div>
                            </div>
                        </div>
                        ${event.isCompleted ?
                ""
                :
                `
                        <div class="scheduled-event-list-action-container">
                            <button data-scheduled-event-id=${event.scheduledEventId} class="mark-as-completed-btn action-btn">
                                Mark as Completed
                            </button>
                        </div>
                            `
            }
                    </div>
                </div>
                </div>
            `
        container.appendChild(requestElement.content)

    })
    parentContainer.appendChild(container);

}