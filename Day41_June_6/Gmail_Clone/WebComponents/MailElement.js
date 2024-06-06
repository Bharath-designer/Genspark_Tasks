import { randomColor } from "../Utilities/RandomColor.js"

class MailElement extends HTMLElement {
    constructor() {
        super()

        this.attachShadow({ mode: "open" });
    }

    connectedCallback() {
        const dataAttribute = this.getAttribute('mail-object');
        let dataObject = dataAttribute ? JSON.parse(dataAttribute) : {};

        const mailTemplate = document.createElement("template");

        mailTemplate.innerHTML =
            `
            <div class="mail-row${dataObject.isRead ? ' new' : ''}">
                <div class="mail-profile">
                ${dataObject.profileImg ?
                `<img src="${dataObject.profileImg}" alt="">` :
                `<span class="letter-profile-logo">${dataObject.username[0]}</span>`
            }
                </div>
                <div class="mail-content">
                    <div class="mail-username ellipsis">
                        ${dataObject.username}
                        </div>
                    <div class="mail-subject ellipsis">
                        ${dataObject.subject}
                    </div>
                    <div class="mail-body ellipsis">
                        ${dataObject.body}
                    </div>
                    <div class="mail-attachment-container">
                        
                    </div>
                </div>
                <div class="mail-date">
                    <span class="date">${dataObject.emailTime}</span>
                    <span class="star-icon">
                        <img src="${dataObject.isStared ? 'assets/star_filled.svg' : 'assets/star_outlined.svg'}" alt="">
                    </span>
                </div>
            </div> 
            `

        this.shadowRoot.appendChild(mailTemplate.content.cloneNode(true));

        if (dataObject.attachments.length > 0) {
            const attachmentContainer = this.shadowRoot.querySelector('.mail-attachment-container')
            for (let i = 0; i < Math.min(2, dataObject.attachments.length); i++) {
                const attachmentElement = document.createElement('mail-attachment');
                attachmentElement.setAttribute('attachment-object', JSON.stringify(dataObject.attachments[i]))
                attachmentContainer.appendChild(attachmentElement)
            }
            if (dataObject.attachments.length > 2) {
                const template = document.createElement("template")
                template.innerHTML =
                    `<span class="extra-attachment-count">
                        +${dataObject.attachments.length - 2}
                    </span>
                    `
                attachmentContainer.appendChild(template.content.cloneNode(true))

            }
        }


        const mailStyle = document.createElement("style")
        mailStyle.textContent =
            `
            * {
                margin: 0;
                padding: 0;
                box-sizing: border-box;
            }

            .ellipsis {
                overflow: hidden;
                text-overflow: ellipsis;
                white-space: nowrap;
            }

            .mail-row {
                display: flex;
                gap: .5em;
                padding: 1em .5em;
                border-radius: 2px;
                cursor: pointer;
            }
            .mail-row.new {
                color: #606267;
            }
            .mail-row:hover {
                background: rgb(235, 235, 235);
            }

            .mail-row .mail-profile {
                display: flex;
                align-items:flex-start;
            }
            
            .mail-row .letter-profile-logo {
                width: 2.8em;
                aspect-ratio: 1;
                display:flex;
                justify-content:center;
                align-items:center;
                background-color: ${randomColor()};
                border-radius: 50%;
                color:black;
                font-weight:500;
                color:white;
            }

            .mail-row .mail-profile img {
                width: 2.8em;
                border-radius: 50%;
                aspect-ratio: 1;
            }

            .mail-row .mail-content {
                margin-left: .5em;
                flex: 1;
                overflow: hidden;
                display: flex;
                flex-direction: column;
                gap: .2em;
            }

            .mail-row .mail-username {
                font-weight: bold;
            }

            .mail-row.new .mail-username {
                font-weight:500;
            }

            .mail-row .mail-subject {
                font-size: .875em;
                color: #292929;
                font-weight: 500;
            }
            .mail-row.new .mail-subject {
                color: #606267;
            }

            .mail-row .mail-body {
                font-size: .875em;
                color: #5D5C5D;
            }

            .mail-row .mail-attachment-container {
                display: flex;
                white-space: nowrap;
                gap: .5em;
                margin-top: .5em;
                align-items:center;
            }

            .mail-row .extra-attachment-count {
                font-weight:500;
                color: #5D5C5D;
                font-size: .875em
            }

            .mail-row .mail-date {
                display: flex;
                flex-direction: column;
                gap: 1em;    
            }


            .mail-row .date {
                font-size: .75em;
            }

            .mail-row .star-icon {
                display: flex;
                justify-content: flex-end;
            }
            .mail-row .star-icon img{
                width: 1.4em;
                cursor: pointer;
            }
        `
        this.shadowRoot.appendChild(mailStyle)
    }
}

customElements.define('mail-element', MailElement)