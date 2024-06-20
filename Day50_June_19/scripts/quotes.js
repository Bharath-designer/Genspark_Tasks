let data = []
const QUOTES_PER_PAGE = 5;
let currentIndex = 1
let sortBy = '-'

const fetchData = async () => {
    const rawData = await fetch(`https://dummyjson.com/quotes?limit=${QUOTES_PER_PAGE}&skip=${QUOTES_PER_PAGE * (currentIndex - 1)}`)
    data = await rawData.json()
}

const manipulateContainer = async () => {
    const quotesContainer = document.querySelector(".quotes")
    quotesContainer.innerHTML = "Loading quotes..."
    quotesContainer.innerHTML = ""
    data.quotes.forEach(quote => {
        const template = document.createElement("template")
        template.innerHTML =
            `
            <div class="quote">
                    <span class="value">
                       ${quote.quote}
                    </span>
                    <span class="author">- ${quote.author}</span>
                </div>
        `

        quotesContainer.appendChild(template.content)
    })

}

fetchData()
    .then(() => {
        manipulateContainer()
    })

const changePagination = async (option) => {
    if (option === 'next') {
        currentIndex++
    } else if (option == 'prev') {
        if (currentIndex == 1) return;
        currentIndex--
    }
    
    if (sortBy == '-') {
        clearInp()
        await fetchData()
        await manipulateContainer()
    } else {
        document.querySelector(".search-inp").value = ""
        const rawData = await fetch(`https://dummyjson.com/quotes`)
        data = await rawData.json()
        if (sortBy == 'asc') {
            data.quotes.sort((a, b) => a.author.localeCompare(b.author));
        } else {
            data.quotes.sort((a, b) => b.author.localeCompare(a.author));
        }
        const startIndex = (currentIndex - 1) * QUOTES_PER_PAGE;
        const endIndex = startIndex + QUOTES_PER_PAGE;
        data.quotes.splice(endIndex);
        data.quotes.splice(0, startIndex);
        await manipulateContainer()
    }
}


const clearInp = async () => {
    document.querySelector(".search-inp").value = ""
    await fetchData()
    await manipulateContainer()
}

const search = async () => {
    const searchText = document.querySelector(".search-inp").value

    const rawData = await fetch(`https://dummyjson.com/quotes`)
    const parsedData = await rawData.json()
    data = { quotes: parsedData.quotes.filter(element => element.quote.toLowerCase().includes(searchText.toLowerCase()) || element.author.toLowerCase().includes(searchText.toLowerCase())) }
    manipulateContainer();
}



const sort = async (value) => {
    const btn = document.querySelector(".sort-btn > button")
    sortBy = value
    if (sortBy == '-') {
        btn.textContent = "Sort"
        currentIndex = 1
        await fetchData()
        await manipulateContainer()
        return;
    }
    if (sortBy == 'asc') {
        btn.textContent = "A-Z"
    } else {
        btn.textContent = "Z-A"
    }
    currentIndex = 1
    changePagination()
}