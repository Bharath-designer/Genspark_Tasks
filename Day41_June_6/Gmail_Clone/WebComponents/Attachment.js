class MailAttachment extends HTMLElement {
    constructor() {
        super()
        this.attachShadow({ mode: "open" })
    }

    connectedCallback() {
        const attachmentAttribute = this.getAttribute('attachment-object');
        let attachmentObject = attachmentAttribute ? JSON.parse(attachmentAttribute) : {};

        const attachmentTemplate = document.createElement("template");

        attachmentTemplate.innerHTML =
            `
        <div class="mail-attachment">
            <span class="preview-icon"><img src="${attachmentObject.filetype === 'application/pdf' ? 'assets/pdf_preview.svg' : 'assets/image_preview.svg'}" alt=""></span>
            <span class="preview-filename ellipsis">${attachmentObject.filename}</span>
        </div>
        `

        this.shadowRoot.appendChild(attachmentTemplate.content.cloneNode(true))


        const styleElement = document.createElement("style");
        styleElement.textContent = 
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

        .mail-attachment {
            display: flex;
            gap: .3em;
            padding: .3em 1em;
            border: 1px solid #B3B2B3;
            font-size: .85em;
            align-items: center;
            border-radius: 50em;
        }

        .mail-attachment .preview-icon {
            display: flex;
        }

        .mail-attachment .preview-icon img {
            width: 1.2em;
        }

        .mail-attachment .preview-filename {
            width: 4em;
        }
        `

        this.shadowRoot.appendChild(styleElement)

    }
}

customElements.define('mail-attachment', MailAttachment)