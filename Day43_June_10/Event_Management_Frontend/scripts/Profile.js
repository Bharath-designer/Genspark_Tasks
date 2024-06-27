import fetchData from '../utilities/FetchData.js'
import {
    onOrderListMount,
    onRequestDetailsMount,
    onRequestListMount,
    onScheduledEventListMount,
    onAdminManageEventMount,
    onAdminRequestMount,
    onAdminScheduledEventListMount
} from './MountEvents.js'

import {
    requestListMounted,
    ordersMounted,
    requestDetailsMounted,
    scheduledEventListMounted,
    adminScheduledEventListMounted
} from './MountedEvents.js'

const tabsOptions = {
    requests: {
        sectionTitle: "Requests",
        tabClassName: "request",
        onMount: onRequestListMount,
        onMounted: requestListMounted
    },
    requestDetails: {
        sectionTitle: "Request Details",
        tabClassName: "request",
        onMount: onRequestDetailsMount,
        onMounted: requestDetailsMounted
    },
    orders: {
        sectionTitle: "Orders",
        tabClassName: "order",
        onMount: onOrderListMount,
        onMounted: ordersMounted
    },
    scheduledEvents: {
        sectionTitle: "Scheduled Events",
        tabClassName: "scheduled-event",
        onMount: onScheduledEventListMount,
        onMounted: scheduledEventListMounted
    },
    adminManageEvents : {
        sectionTitle: "Manage Events",
        tabClassName: "manage-event",
        onMount: onAdminManageEventMount
    },
    adminRequests : {
        sectionTitle: "Requests",
        tabClassName: "admin-requests",
        onMount: onAdminRequestMount
    },
    adminScheduledEvents: {
        sectionTitle: "Scheduled Events",
        tabClassName: "scheduled-event",
        onMount: onAdminScheduledEventListMount,
        onMounted: adminScheduledEventListMounted
    },
}

let loading = false

export const makeActiveTab = async (tab, requestId) => {
    if (loading) return;
    loading = true
    const options = tabsOptions[tab]
    if (!options) throw new Error(`Tab '${tab}' options are not configured`);
    const profileSectionTitle = document.querySelector(".profile-section-title")
    const sectionTitle = options.sectionTitle
    profileSectionTitle.innerHTML = sectionTitle

    const tabs = document.querySelectorAll(".profile-tab-btn")
    tabs.forEach(element => {
        element.classList.remove("active")
    })

    const currentTabClassName = options.tabClassName
    const activeTab = document.querySelector(`.profile-tab-btn.${currentTabClassName}`)
    activeTab.classList.add("active")

    const rightContainer = document.querySelector(".profile-right")
    rightContainer.classList.add('loading')
    const profileContent = rightContainer.querySelector(".profile-list-container")
    profileContent?.remove()

    await options.onMount(rightContainer, requestId)
    if (options.onMounted) await options.onMounted(makeActiveTab);

    rightContainer.classList.remove('loading')
    loading = false
}

const validTabs = []

const addClickEventsToTabs = () => {
    const tabs = document.querySelectorAll(".profile-tab-btn")
    tabs.forEach(tab => {
        tab.addEventListener("click", () => {
            if (tab.dataset.tabName !== validTabs[0]) {
                const url = new URL(location)
                url.searchParams.set('tab', tab.dataset.tabName)
                history.replaceState(null, "", url)
            } else {
                const url = new URL(location)
                url.searchParams.delete('tab')
                history.replaceState(null, "", url)
            }
            makeActiveTab(tab.dataset.tabName)
        })
    })
}
    
const makeInitialTab = () => {
    const urlParams = new URLSearchParams(location.search)
    const tab = urlParams.get('tab')
    if (validTabs.includes(tab)) {
        makeActiveTab(tab)
    } else {
        makeActiveTab(validTabs[0])
    }
}


const navItems = {
    User: [
        {
            tabName: "requests",
            className: "request",
            displayName:"Requests"
        },
        {
            tabName: "orders",
            className: "order",
            displayName:"Orders"
        },
        {
            tabName: "scheduledEvents",
            className: "scheduled-event",
            displayName:"Scheduled Events"
        },
    ],
    Admin: [
        {
            tabName: "adminManageEvents",
            className: "manage-event",
            displayName:"Manage Events"
        },
        {
            tabName: "adminRequests",
            className: "admin-requests",
            displayName:"Requests"
        },
        {
            tabName: "adminScheduledEvents",
            className: "scheduled-event",
            displayName:"Scheduled Events"
        },
    ]
}

const makeTabsBasedOnRole = async () => {
    const navContainer = document.querySelector(".profile-section-links")
    navContainer.innerHTML = ""
    const data = await fetchData("/api/verify", "GET")
    const tabs = navItems[data.role]
    tabs.forEach(tab=>{
        validTabs.push(tab.tabName)
        const btn = document.createElement("button")
        btn.classList.add('profile-tab-btn', tab.className)
        btn.setAttribute('data-tab-name', tab.tabName)
        btn.textContent = tab.displayName
        navContainer.appendChild(btn)
    })

    addClickEventsToTabs()
    makeInitialTab()

}

makeTabsBasedOnRole()


let isNavOpen = false
const hamburgerIcon = document.querySelector(".hamburger-icon")
const profileLeft = document.querySelector(".profile-left")

const autoCloseFunc = (e) => {
    if (!e.target.closest('.profile-left') || e.target.closest('.profile-tab-btn')) {
        hamburgerIcon.click()
    }
}

hamburgerIcon.onclick = (e) => {
    e.stopPropagation()
    profileLeft.classList.toggle('hidden')
    isNavOpen = !isNavOpen
    if (isNavOpen) {
        hamburgerIcon.src = "./assets/white_close.svg"
        document.body.addEventListener('click', autoCloseFunc)
    } else {
        hamburgerIcon.src = "./assets/hamburger.svg"
        document.body.removeEventListener('click', autoCloseFunc)
    }
}

