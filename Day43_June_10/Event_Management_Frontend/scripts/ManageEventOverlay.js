import fetchData from "../utilities/FetchData.js"
import { makeActiveTab } from './Profile.js'

const createEventOverlayTemplate = (formTitle, formSubmitHandler, disableStatusInput) => {
    const template = document.createElement("template")
    template.innerHTML =
        `
    <div class="event-overlay-container overlay-container">
        <form>
            <div class="form-title">${formTitle}</div>
            <div class="fields-container">
                <div class="inp-field">
                    <label for="eventName">Event Name</label>
                    <input id="eventName" name="eventName" type="text">
                    <div class="error-section"></div>
                </div>
                <div class="inp-field">
                    <label for="description">Event Description</label>
                    <textarea id="description" name="description"></textarea>
                    <div class="error-section"></div>
                </div>
                ${
                    disableStatusInput ? 
                     "" 
                     :
                     `
                     <div class="inp-field">
                        <label for="event-is-active">Event Status</label>
                        <input id="event-is-active" hidden name="isActive" type="checkbox"/>
                        <label for="event-is-active" class="event-status-container">
                            <img src="./assets/switch_enabled.svg" alt="">
                        </label>
                    </div>`
                     
                }
                
            </div>
            <div class="form-btn-container">
                <button type="button" class="cancel-btn btn">Cancel</button>
                <button type="submit" class="save-btn btn">Save</button>
            </div>
        </form>

    </div>
    `

    const content = template.content
    const cancelBtn = content.querySelector('.cancel-btn')
    const form = content.querySelector("form")
    const statusCheckbox = content.querySelector('input[name=isActive]')
    const statusIcon = content.querySelector(".event-status-container img")
    const matchCheckValueWithIcon = () => {
        if (statusCheckbox.checked) {
            statusIcon.src = "./assets/switch_enabled.svg"
        } else {
            statusIcon.src = "./assets/switch_disabled.svg"
        }
    }
    statusCheckbox?.addEventListener('input', matchCheckValueWithIcon)
    statusCheckbox && matchCheckValueWithIcon()
    cancelBtn.onclick = cancelEventOverlay

    form.onsubmit = formSubmitHandler

    document.body.appendChild(content)
}


const submitHandler = async (e, saveFuntion) => {
    e.preventDefault()
    const formElement = document.querySelector('.event-overlay-container form')
    const formdata = new FormData(formElement)
    const eventName = formdata.get('eventName')
    const description = formdata.get('description')
    const isActive = formdata.get('isActive')

    const eventNameErrorSection = formElement.querySelector("[name=eventName] + .error-section")
    const descriptionErrorSection = formElement.querySelector("[name=description] + .error-section")
    eventNameErrorSection.textContent = ""
    descriptionErrorSection.textContent = ""

    if (!eventName) {
        eventNameErrorSection.textContent = "EventName is required"
        return;
    }
    if (!description) {
        descriptionErrorSection.textContent = "Description is required"
        return;
    }

    await saveFuntion(eventName, description, isActive)

    cancelEventOverlay()
    makeActiveTab('adminManageEvents')

}

export const createEditEventOverlay = (eventDetails) => {
    const saveFunc = async (eventName, description, isActive) => {
        await fetchData(`/api/admin/events/${eventDetails.eventCategoryId}`, "PUT", {
            eventName,
            description,
            isActive: isActive === "on"
        })
    }
    createEventOverlayTemplate("Edit Event Details", (e) => submitHandler(e, saveFunc))
    const eventName = document.querySelector('.event-overlay-container [name=eventName]')
    const description = document.querySelector('.event-overlay-container [name=description]')
    const isActive = document.querySelector('.event-overlay-container [name=isActive]')
    eventName.value = eventDetails.eventName
    description.value = eventDetails.description
    if (eventDetails.isActive) {
        isActive.click()
    }
}

export const createAddEventOverlay = () => {
    const saveFunc = async (eventName, description, isActive) => {
        await fetchData(`/api/admin/events`, "POST", {
            eventName,
            description,
            isActive: isActive === "on"
        })
    }
    createEventOverlayTemplate("Create Event", (e) => submitHandler(e, saveFunc), true)
}


export const cancelEventOverlay = () => {
    const overlay = document.querySelector('.event-overlay-container')
    overlay?.remove()
}
