const getData = async () => {
    const rawData = await fetch("data.json")
    return await rawData.json()
}

const getMailData = async () => {
    const scrollableContent = document.querySelector(".scrollable-content");
    const data = (await getData()).emails

    data.forEach((email, index)=>{
        const mailElement = document.createElement("mail-element");
        mailElement.setAttribute('mail-object', JSON.stringify(email));
        scrollableContent.appendChild(mailElement)
    })

}


getMailData()