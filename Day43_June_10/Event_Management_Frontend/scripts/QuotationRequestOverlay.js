import fetchData from "../utilities/FetchData.js"

const createQuotationRequestOverlayTemplate = (formTitle, formSubmitHandler) => {
    const template = document.createElement("template")
    template.innerHTML =
        `
    <div class="respond-to-event-overlay-container overlay-container">
        <form class="respond-to-event-form">
            <div class="form-title">${formTitle}</div>
            <div class="fields-container">
                <div class="inp-field">
                    <label for="venueType">Venue Type</label>
                    <select id="venueType" name="venueType" type="text">
                        <option value="" selected disabled>Select venue type</option>
                        <option value="PrivateVenue">Private Venue</option>
                        <option value="OwnVenue">Own Venue</option>
                    </select>
                    <div class="error-section"></div>
                </div>
                <div class="inp-field">
                    <label for="foodPreference">Food Preference</label>
                    <select id="foodPreference" name="foodPreference" type="text">
                        <option value="" selected disabled>Select food preference</option>
                        <option value="NoFood">No Food</option>
                        <option value="Veg">Veg</option>
                        <option value="NonVeg">NonVeg</option>
                        <option value="Both">Both</option>
                    </select>
                    <div class="error-section"></div>
                </div>
                <div class="inp-field catering-instruction">
                    <label for="cateringInstructions">Catering Instructions</label>
                    <textarea id="cateringInstructions" name="cateringInstructions"></textarea>
                    <div class="error-section"></div>
                </div>
                <div class="inp-field">
                    <label for="locationDetails">Location Details</label>
                    <textarea id="locationDetails" name="locationDetails"></textarea>
                    <div class="error-section"></div>
                </div>
                <div class="inp-field">
                    <label for="specialInstructions">Special Instructions</label>
                    <textarea id="specialInstructions" name="specialInstructions"></textarea>
                    <div class="error-section"></div>
                </div>
                <div class="inp-field">
                    <label for="eventStartDate">Event Start Date</label>
                    <input type="datetime-local" id="eventStartDate" name="eventStartDate"></input>
                    <div class="error-section"></div>
                </div>
                <div class="inp-field">
                    <label for="eventEndDate">Event End Date</label>
                    <input type="datetime-local" id="eventEndDate" name="eventEndDate"></input>
                    <div class="error-section"></div>
                </div>
                
            </div>
            <div class="form-btn-container">
                <button type="button" class="cancel-btn btn">Cancel</button>
                <button type="submit" class="save-btn btn">Save</button>
            </div>
        </form>

    </div>
    `

    const content = template.content
    const form = content.querySelector("form")
    const foodPreference = form.querySelector("[name=foodPreference]")

    foodPreference.addEventListener("input", () => {
        if (foodPreference.value !== "NoFood") {
            form.classList.add("show-catering-detail")
        } else {
            form.classList.remove("show-catering-detail")
        }
    })


    const cancelBtn = content.querySelector('.cancel-btn')
    cancelBtn.onclick = cancelQuotationRequestOverlay

    form.onsubmit = formSubmitHandler

    document.body.appendChild(content)
}


const submitHandler = async (e, saveFuntion) => {
    e.preventDefault()
    console.log('clicked');
    const formElement = document.querySelector('.respond-to-event-overlay-container form')
    const formdata = new FormData(formElement)

    const venueType = formdata.get('venueType')
    const foodPreference = formdata.get('foodPreference')
    const cateringInstructions = formdata.get('cateringInstructions')
    const locationDetails = formdata.get('locationDetails')
    const specialInstructions = formdata.get('specialInstructions')
    const eventStartDate = formdata.get('eventStartDate')
    const eventEndDate = formdata.get('eventEndDate')

    const venueTypeErrorSection = formElement.querySelector("[name=venueType] + .error-section")
    const foodPreferenceErrorSection = formElement.querySelector("[name=foodPreference] + .error-section")
    const cateringInstructionsErrorSection = formElement.querySelector("[name=cateringInstructions] + .error-section")
    const locationDetailsErrorSection = formElement.querySelector("[name=locationDetails] + .error-section")
    const specialInstructionsErrorSection = formElement.querySelector("[name=specialInstructions] + .error-section")
    const eventStartDateErrorSection = formElement.querySelector("[name=eventStartDate] + .error-section")
    const eventEndDateErrorSection = formElement.querySelector("[name=eventEndDate] + .error-section")

    venueTypeErrorSection.textContent = ""
    foodPreferenceErrorSection.textContent = ""
    cateringInstructionsErrorSection.textContent = ""
    locationDetailsErrorSection.textContent = ""
    specialInstructionsErrorSection.textContent = ""
    eventStartDateErrorSection.textContent = ""
    eventEndDateErrorSection.textContent = ""

    if (!venueType) {
        venueTypeErrorSection.textContent = "Venue Type is required"
        return;
    }
    if (!foodPreference) {
        foodPreferenceErrorSection.textContent = "Food Preference is required"
        return;
    }
    if (foodPreference !== "NoFood" && !cateringInstructions) {
        cateringInstructionsErrorSection.textContent = "Catering Instructions is required"
        return;
    }
    if (!locationDetails) {
        locationDetailsErrorSection.textContent = "Location Details is required"
        return;
    }
    if (!specialInstructions) {
        specialInstructionsErrorSection.textContent = "Special Instructions is required"
        return;
    }
    if (!eventStartDate) {
        eventStartDateErrorSection.textContent = "Event Start Date is required"
        return;
    }
    if (!eventEndDate) {
        eventEndDateErrorSection.textContent = "Event End Date is required"
        return;
    }


    console.log(eventEndDate);

    await saveFuntion({
        venueType,
        foodPreference,
        cateringInstructions,
        locationDetails,
        specialInstructions,
        eventStartDate,
        eventEndDate
    })

    cancelQuotationRequestOverlay()
    location.href = "/Profile.html"
}

export const createQuotationRequestOverlay = (eventCategoryId) => {
    const saveFunc = async (payload) => {
        await fetchData(`/api/quotation/request`, "POST", { eventCategoryId, ...payload },)
    }
    createQuotationRequestOverlayTemplate("Create quotation request", (e) => submitHandler(e, saveFunc))
}


export const cancelQuotationRequestOverlay = () => {
    const overlay = document.querySelector('.respond-to-event-overlay-container')
    overlay?.remove()
}
