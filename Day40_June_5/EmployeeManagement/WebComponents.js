const template = document.createElement("template");
template.innerHTML =
    `
    <style>
    nav {
        display:flex;
        gap:2em;
        background: black;
        padding:1em;
        justify-content:center; 
    }

    a {
        text-decoration:none;
        color:white
    }
    </style>
    <nav>
        <a href="/">Home</a>
        <a href="AddEmployee.html">Add Employee</a>
    </nav>
`

class NavBar extends HTMLElement {
    constructor() {
        super()
        this.attachShadow({mode:"open"})

        this.shadowRoot.appendChild(template.content.cloneNode(true))
    }

}

customElements.define("nav-bar", NavBar)